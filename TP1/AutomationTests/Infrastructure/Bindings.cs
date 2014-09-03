namespace AutomationTests.Infrastructure
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    using TechTalk.SpecFlow;

    /// <summary>
    /// The global steps.
    /// </summary>
    [Binding]
    public class Bindings
    {
        /// <summary>
        /// Steps that should be done before scenario run.
        /// </summary>
        [BeforeScenario()]
        public static void BeforeScenarioRun()
        {
            // Initialize driver.
            IWebDriver driver = new FirefoxDriver(new FirefoxBinary(), new FirefoxProfile(), TimeSpan.FromMinutes(3));
            
            ScenarioContext.Current["CurrentDriver"] = driver;
        }


        /// <summary>
        /// Steps that should be done before test run.
        /// </summary>
        [AfterScenario()]
        public static void AfterTestRun()
        {
            
        }
    }
}
