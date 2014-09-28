// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResourceService.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The resource service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Resources
{
    using System;
    using System.Globalization;
    using System.Resources;

    /// <summary>
    /// The resource service.
    /// </summary>
    public class ResourceService
    {
        #region Fields

        /// <summary>
        /// The culture.
        /// </summary>
        private readonly CultureInfo culture;

        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ResourceManager manager;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceService"/> class.
        /// </summary>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <exception cref="NotSupportedException">
        /// </exception>
        public ResourceService(CultureInfo culture)
        {
            this.culture = culture;
            if (culture.Name.Equals("uk-UA"))
            {
                this.manager = Language_ua.ResourceManager;
            }
            else if (culture.Name.Equals("en-US"))
            {
                this.manager = languages_us.ResourceManager;
            }
            else if (culture.Name.Equals("de-DE"))
            {
                //// this.manager = Language_de.ResourceManager;
            }
            else
            {
                throw new NotSupportedException("Not supported languages");
            }
        }

        #endregion

        #region Public Indexers

        /// <summary>
        /// Returns the localized string for proper culture.
        /// </summary>
        /// <param name="name">
        /// The name of localized string.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string this[string name]
        {
            get
            {
                return this.manager.GetString(name, this.culture);
            }
        }

        #endregion
    }
}