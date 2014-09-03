
namespace AutomationTests.Infrastructure
{
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;

    public abstract class BaseScenario
    {
        public IWebDriver WebDriver
        {
            get
            {
                return (IWebDriver)ScenarioContext.Current["CurrentDriver"];
            }
        }
    }
}
