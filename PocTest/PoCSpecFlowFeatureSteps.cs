using System;
using SpecFlowPoc.PocTest;
using TechTalk.SpecFlow;

namespace PocTest
{
    [Binding]
    public class PoCSpecFlowFeatureSteps : TestBase
    {
        [Given(@"I am on Linkeding page")]
        public void GivenIAmOnLinkedingPage()
        {
            Runner.DoStep("Linkedin Page", () =>
            {
                //Page.MyLinkLoginPage.UserNameTxtBox.SendKeys("");
            });
        }
        
        [Given(@"Login with (.*) and (.*) into Linkedin")]
        public void GivenLoginWithAndIntoLinkedin(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press Signin button")]
        public void WhenIPressSigninButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"validating the login")]
        public void ThenValidatingTheLogin()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
