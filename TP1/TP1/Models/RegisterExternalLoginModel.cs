﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterExternalLoginModel.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The register external login model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The register external login model.
    /// </summary>
    public class RegisterExternalLoginModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the external login data.
        /// </summary>
        public string ExternalLoginData { get; set; }

        /// <summary>
        ///     Gets or sets the user name.
        /// </summary>
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        #endregion
    }
}