// --------------------------------------------------------------------------------------------------------------------
// <copyright file="City.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The city.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Model.DomainModels
{
    /// <summary>
    ///     The city.
    /// </summary>
    public class City
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// String reprosentations of the city name
        /// </summary>
        /// <returns>
        /// Name of the city <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return this.Name;
        }

        #endregion
    }
}