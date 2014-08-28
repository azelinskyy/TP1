// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserProfile.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The user profile.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Model.UserModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    ///     The user profile.
    /// </summary>
    [Table("UserProfile")]
    public class UserProfile
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the user id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        ///     Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        #endregion
    }
}