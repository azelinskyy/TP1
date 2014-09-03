namespace AutomationTests.Infrastructure
{
    using OpenQA.Selenium;

    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickElement(By selector)
        {
            this.driver.FindElement(selector).Click();
        }

        public void SetValueIntoInputElement(By selector, string value)
        {
            this.driver.FindElement(selector).SendKeys(value);
        }

        public bool IsElementVisible(By selector)
        {
            return this.driver.FindElement(selector).Displayed;
        }
    }
}
