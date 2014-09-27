// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Company.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The company.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Model.DomainModels
{
    /// <summary>
    ///     The company.
    /// </summary>
    public class Company : DomainModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}