using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UIAccess;
using UIAccess.WebControls;

namespace SpecFlowPoc.PocPages.Utils
{
    public class Wait
    {
        private WebDriverPlugin thisWebDriver;
        private string thisGuiMapPath;

        public Wait(WebDriverPlugin webDriver, string completeGuiMapPath)
        {
            thisWebDriver = webDriver;
            thisGuiMapPath = completeGuiMapPath;
        }

        public bool IsPresent<T>(string logicalName, int waitBeforeCheck, int timeout) where T : WebControl
        {
            Thread.Sleep(waitBeforeCheck);

            T Ctrl = null;

            if (null == thisWebDriver.WaitForControl<T>(thisGuiMapPath, logicalName,
                                                timeout))
            {
                return false;
            }

            return true;
        }

        public T GetHtmlControl<T>(string GUIMap, string LogicalName) where T : WebControl
        {
            T Ctrl = null;

            Ctrl = thisWebDriver.WaitForControl<T>(GUIMap, LogicalName,
                                                Config.PageClassSettings.Default.MaxTimeoutValue);
            if (Ctrl == null)
            {
                //throw new GUIException(LogicalName, "Element not found on the Screen");
            }
            return Ctrl;
        }

        public T GetHtmlControl<T>(string logicalName) where T : WebControl
        {
            return GetHtmlControl<T>(thisGuiMapPath, logicalName);
        }

    }
}
