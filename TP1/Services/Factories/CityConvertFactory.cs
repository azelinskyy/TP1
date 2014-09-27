// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CityConvertFactory.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The company convert factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Services.Factories
{
    using Model.DomainModels;
    using Model.DTOs;

    /// <summary>
    ///     The company convert factory.
    /// </summary>
    public class CityConvertFactory : IConvertFactory<City, CityDto>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The from model.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="CityDto"/>.
        /// </returns>
        public CityDto FromModel(City model)
        {
            return new CityDto { Name = model.Name };
        }

        /// <summary>
        /// The to model.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="Company"/>.
        /// </returns>
        public City ToModel(CityDto obj)
        {
            return new City { Name = obj.Name };
        }

        #endregion
    }
}