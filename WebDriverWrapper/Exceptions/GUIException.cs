using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper;

namespace WebDriverWrapper
{
    public class GUIException : EDMCExceptions
    {
        enum ErrorType
        {
            InvalidSelectorException,
            NoSuchElementException,
            NoSuchFrameException,
            StaleElementReferenceException,
            TimeoutException,
            WebDriverException
        }

        enum MethodName
        {
            GetHtmlControl,
            TestFixture,
            WaitForControl
        }

        private static log4net.ILog Logger =
                  log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()
                  .DeclaringType);

        public GUIException(Exception innerException)
            :base(innerException)
        {
            Logger.Debug("Inside GUI Exception class");
        }

        public GUIException(string message)
            :base()
        {
            if (message.Contains("Element not found") || message.Contains("object is not set"))
            {
                Logger.Error("Failed to find the element on screen");
                throw new NoSuchElementException("Failed to find the element on screen");
            }
            else
            {
                Logger.Error(message);
            }
        }

        public GUIException(string element , string message)
            :base()
        {
            if (message.Contains("Element not found"))
            {
                Logger.Error(string.Concat("Failed to find the element with logical name [", element , "] on the screen!!"));
                throw new NoSuchElementException(string.Concat("Failed to find the element with logical name [", element, "] on the screen!!"));
            }
            else
            {
                Logger.Error(message);
            }
        }

        public GUIException(string element, Exception innerException)
            :base(innerException)
        {
            string exceptionString = innerException.GetType().ToString();
            string methodName = innerException.TargetSite.Name;
            string exceptionMessage = "";
            string messgaeType = innerException.GetType().Name;

            switch (innerException.GetType().Name)
            {
                case "NullReferenceException":
                case "StaleElementReferenceException":
                case "NoSuchElementException":
                case "TimeoutException":
                case "WebDriverException":
                case "InvalidSelectorException":
                case "WebDriverTimeoutException":
                    switch (methodName)
                    {
                        case "TestFixture": case "GetHtmlControl":
                            exceptionMessage = string.Concat("Seems browser is timed Out or closed and hence the Element [", element, "] is not found!!");
                            Logger.Error(string.Concat(exceptionString , exceptionMessage));
                            throw new TimeoutException(exceptionString + exceptionMessage);
                        case "WaitForControl":
                        case "WaitForEleVisible":
                            exceptionMessage = string.Concat("Failed to find the element with logical name [", element, "] on the screen!!");
                            Logger.Error(string.Concat(exceptionString, exceptionMessage));
                            throw new TimeoutException(exceptionString + exceptionMessage);
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
