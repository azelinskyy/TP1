// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseScenario.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The base scenario.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutomationTests.Infrastructure
{
    using OpenQA.Selenium;

    using TechTalk.SpecFlow;

    /// <summary>
    /// The base scenario.
    /// </summary>
    public abstract class BaseScenario
    {
        #region Public Properties

        /// <summary>
        /// Gets the web driver.
        /// </summary>
        public IWebDriver WebDriver
        {
            get
            {
                return (IWebDriver)ScenarioContext.Current["CurrentDriver"];
            }
        }

        #endregion
    }
}