// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasePage.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The base page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutomationTests.Infrastructure
{
    using OpenQA.Selenium;

    /// <summary>
    /// The base page.
    /// </summary>
    public abstract class BasePage
    {
        #region Fields

        /// <summary>
        /// The driver.
        /// </summary>
        private readonly IWebDriver driver;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The driver.
        /// </param>
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The click element.
        /// </summary>
        /// <param name="selector">
        /// The selector.
        /// </param>
        public void ClickElement(By selector)
        {
            this.driver.FindElement(selector).Click();
        }

        /// <summary>
        /// The is element visible.
        /// </summary>
        /// <param name="selector">
        /// The selector.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsElementVisible(By selector)
        {
            return this.driver.FindElement(selector).Displayed;
        }

        /// <summary>
        /// The set value into input element.
        /// </summary>
        /// <param name="selector">
        /// The selector.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void SetValueIntoInputElement(By selector, string value)
        {
            this.driver.FindElement(selector).SendKeys(value);
        }

        #endregion
    }
}