using System;
using SpecFlowPoc.PocTest;
using TechTalk.SpecFlow;
using NUnit.Framework;


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
                Assert.True(Page.MyLinkLoginPage.UserNameTxtBox.Visible,"Improper Loading");
            });
        }
        
        [Given(@"Login with (.*) and (.*) into Linkedin")]
        public void GivenLoginWithAndIntoLinkedin(string p0, string p1)
        {
            Runner.DoStep("Login with Credentials", () =>
            {
                Page.MyLinkLoginPage.UserNameTxtBox.SendKeys(p0);
                Page.MyLinkLoginPage.PasswordTxtBox.SendKeys(p1);
            });            
        }
        
        [When(@"I press Signin button")]
        public void WhenIPressSigninButton()
        {
            Runner.DoStep("Clicking on SignIn Button", () =>
            {
                Page.MyLinkLoginPage.SignOnBut.Click();
            });            
        }

        [Then(@"validating the (.*) User name")]
        public void ThenValidatingTheLogin(string p0)
        {
            Runner.DoStep("Validating the Landing page", () =>
            {
                Page.MyLinkLandingPage.ProfileImg.Action.MoveToElement();
                Assert.True(Page.MyLinkLandingPage.ProfileName.Text.Contains(p0), "Not the expeced login");
                Page.MyLinkLandingPage.SignoutBut.Click();
            });            
        }               

    }
}
