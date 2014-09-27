// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConvertFactory.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The ConvertFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Services.Factories
{
    using Model.DomainModels;

    /// <summary>
    /// The ConvertFactory interface.
    /// </summary>
    /// <typeparam name="T1">
    /// </typeparam>
    /// <typeparam name="T2">
    /// </typeparam>
    public interface IConvertFactory<T1, T2>
        where T1 : DomainModel where T2 : class
    {
        #region Public Methods and Operators

        /// <summary>
        /// The from model.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="T2"/>.
        /// </returns>
        T2 FromModel(T1 model);

        /// <summary>
        /// The to model.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="T1"/>.
        /// </returns>
        T1 ToModel(T2 obj);

        #endregion
    }
}