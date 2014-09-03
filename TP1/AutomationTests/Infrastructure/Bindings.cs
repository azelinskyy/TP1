// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bindings.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The global steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutomationTests.Infrastructure
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    using TechTalk.SpecFlow;

    /// <summary>
    ///     The global steps.
    /// </summary>
    [Binding]
    public class Bindings
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Steps that should be done before test run.
        /// </summary>
        [AfterScenario]
        public static void AfterTestRun()
        {
        }

        /// <summary>
        ///     Steps that should be done before scenario run.
        /// </summary>
        [BeforeScenario]
        public static void BeforeScenarioRun()
        {
            // Initialize driver.
            IWebDriver driver = new FirefoxDriver(new FirefoxBinary(), new FirefoxProfile(), TimeSpan.FromMinutes(3));

            ScenarioContext.Current["CurrentDriver"] = driver;
        }

        #endregion
    }
}