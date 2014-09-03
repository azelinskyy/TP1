// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainFeatureSteps.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The main feature steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutomationTests
{
    using AutomationTests.Infrastructure;
    using AutomationTests.Wrappers;

    using NUnit.Framework;

    using OpenQA.Selenium;

    using TechTalk.SpecFlow;

    /// <summary>
    /// The main feature steps.
    /// </summary>
    [Binding]
    public class MainFeatureSteps : BaseScenario
    {
        #region Fields

        /// <summary>
        /// The index page.
        /// </summary>
        private IndexPage indexPage;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The given i have navigated to the site.
        /// </summary>
        [Given(@"I have navigated to the site")]
        public void GivenIHaveNavigatedToTheSite()
        {
            this.indexPage = new IndexPage(this.WebDriver);
            this.WebDriver.Navigate().GoToUrl(BaseConfigurationResource.SiteAddress);
        }

        /// <summary>
        /// The then the title should be displayed on the screen.
        /// </summary>
        [Then(@"the title should be displayed on the screen")]
        public void ThenTheTitleShouldBeDisplayedOnTheScreen()
        {
            Assert.IsTrue(this.indexPage.IsElementVisible(By.TagName("header")));
        }

        #endregion
    }
}