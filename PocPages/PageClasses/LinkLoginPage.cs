using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowPoc.PocPages;
using UIAccess.WebControls;

namespace PocPages.PageClasses
{
    public class LinkLoginPage : PageBase
    {
        private string guiMap;
        private List<object> utilityList;

        public LinkLoginPage(List<object> utilsList)
            : base(utilsList, "LoginPage.xml")
        {
            guiMap = string.Concat(GuiMapPath, "LoginPage.xml");
            utilityList = utilsList;
        }

        public WebEditBox UserNameTxtBox
        {
            get
            {
                return GetHtmlControl<WebEditBox>("UserNameTxtBox");
            }
        }

        public WebImage LinkedinImage
        {
            get
            {
                return GetHtmlControl<WebImage>("LinkedinImage");
            }
        }
         
        public WebEditBox PasswordTxtBox
        {
            get
            {
                return GetHtmlControl<WebEditBox>("PasswordTxtBox");
            }
        }

        public WebButton SignOnBut
        {
            get
            {
                return GetHtmlControl<WebButton>("SignOnBut");
            }
        }



    }
}
