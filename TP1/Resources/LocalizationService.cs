// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocalizationService.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The localization service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Resources
{
    using System.Globalization;
    using System.Resources;

    /// <summary>
    ///     The resource service.
    /// </summary>
    public class LocalizationService
    {
        #region Fields

        /// <summary>
        ///     The culture.
        /// </summary>
        private readonly CultureInfo culture;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizationService"/> class.
        /// </summary>
        /// <param name="culture">
        /// The culture.
        /// </param>
        public LocalizationService(CultureInfo culture)
        {
            this.culture = culture;
            this.Manager = new ResourceManager("Resources.Language", this.GetType().Assembly);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LocalizationService" /> class.
        /// </summary>
        public LocalizationService()
        {
            this.culture = CultureInfo.CurrentCulture;
            this.Manager = new ResourceManager("Resources.Language", this.GetType().Assembly);
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     The manager.
        /// </summary>
        public ResourceManager Manager { get; private set; }

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
                return this.Manager.GetString(name, this.culture);
            }
        }

        #endregion
    }
}