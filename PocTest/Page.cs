using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocPages.PageClasses;

namespace SpecFlowPoc.PocTest
{
    public class Page
    {
        private List<object> utilsList = new List<object>();

        public Page(TestBase testBase)
        {
            utilsList.Add(testBase.WebDriver);
            utilsList.Add(testBase.KeyBoardSimulator);
            utilsList.Add(testBase.DBValidation);
            utilsList.Add(testBase.AutoIT);
        }

        private LinkLandingPage linkLandingPage;
        public LinkLandingPage MyLinkLandingPage
        {
            get
            {
                if (null == linkLandingPage)
                {
                    linkLandingPage = new LinkLandingPage(utilsList);
                }
                return linkLandingPage;
            }
        }

        private LinkLoginPage linkLoginPage;
        public LinkLoginPage MyLinkLoginPage
        {
            get
            {
                if (null == linkLoginPage)
                {
                    linkLoginPage = new LinkLoginPage(utilsList);
                }
                return linkLoginPage;
            }
        }

    }
}
