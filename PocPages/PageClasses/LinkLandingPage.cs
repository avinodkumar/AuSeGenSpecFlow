using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowPoc.PocPages;
using UIAccess.WebControls;

namespace PocPages.PageClasses
{
   public class LinkLandingPage : PageBase
    {
        private string guiMap;
        private List<object> utilityList;

        public LinkLandingPage(List<object> utilsList)
            : base(utilsList, "LandingPage.xml")
        {
            guiMap = string.Concat(GuiMapPath, "LandingPage.xml");
            utilityList = utilsList;
        }

        public WebImage ProfileImg
        {
            get
            {
                return GetHtmlControl<WebImage>("ProfileImg");
            }
        }

        public WebLink ProfileName
        {
            get
            {
                return GetHtmlControl<WebLink>("ProfileName");
            }
        }


        public WebButton SignoutBut
        {
            get
            {
                return GetHtmlControl<WebButton>("SignoutBut");
            }
        }



    }
}
