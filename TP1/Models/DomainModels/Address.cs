﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The address.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Model.DomainModels
{
    /// <summary>
    ///     The address.
    /// </summary>
    public class Address : DomainModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the address string.
        /// </summary>
        public string AddressString { get; set; }

        #endregion
    }
}