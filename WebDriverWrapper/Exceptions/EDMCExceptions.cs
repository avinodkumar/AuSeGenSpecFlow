using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverWrapper
{
    public class EDMCExceptions : Exception
    {
        private static log4net.ILog Logger =
                  log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()
                  .DeclaringType);

        public EDMCExceptions()
            :base()
        {

        }

        public EDMCExceptions(Exception innerException)
            : base()
        {
            Logger.Error(string.Format("Error occured at: {0}", innerException.TargetSite));
        }


        public EDMCExceptions(string methodName, Exception innerException)
            : base(methodName,innerException)
        {
            Logger.Error(string.Format("Error occured in method : {0}", methodName));
        }

        public EDMCExceptions(string errorMessage)
            :base(errorMessage)
        {

        }

        public EDMCExceptions(string methodName, string message, Exception innerException)
            : base(message,innerException)
        {
            Logger.Error(string.Format("Error occured in method: {0}", methodName));
        }

        public EDMCExceptions(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
