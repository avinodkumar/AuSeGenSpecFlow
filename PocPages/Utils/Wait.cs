using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAccess;
using UIAccess.WebControls;

namespace SpecFlowPoc.PocPages.Utils
{
    public class Wait
    {
        private WebDriverPlugin thisWebDriver;

        private string thisGuiMapPath;


        public Wait(WebDriverPlugin webDriver, string completeGraphicalUserInterfaceMapPath)
        {
            thisWebDriver = webDriver;
            thisGuiMapPath = completeGraphicalUserInterfaceMapPath;
        }


        //public T GetControl<T>(string guiMap, string logicalName) where T: WebControl
        //{
        //    T ctrl = null;
        //    ctrl = thisWebDriver.WaitForControl<T>(guiMap,logicalName,)
        //}

    }
}
