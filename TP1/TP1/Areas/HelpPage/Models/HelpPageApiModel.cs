// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelpPageApiModel.cs" company="Team Alpha Solutions">
//   Copyright � 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The model that represents an API displayed on the help page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TP1.Areas.HelpPage.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net.Http.Headers;
    using System.Web.Http.Description;

    /// <summary>
    ///     The model that represents an API displayed on the help page.
    /// </summary>
    public class HelpPageApiModel
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="HelpPageApiModel" /> class.
        /// </summary>
        public HelpPageApiModel()
        {
            this.SampleRequests = new Dictionary<MediaTypeHeaderValue, object>();
            this.SampleResponses = new Dictionary<MediaTypeHeaderValue, object>();
            this.ErrorMessages = new Collection<string>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the <see cref="ApiDescription" /> that describes the API.
        /// </summary>
        public ApiDescription ApiDescription { get; set; }

        /// <summary>
        ///     Gets the error messages associated with this model.
        /// </summary>
        public Collection<string> ErrorMessages { get; private set; }

        /// <summary>
        ///     Gets the sample requests associated with the API.
        /// </summary>
        public IDictionary<MediaTypeHeaderValue, object> SampleRequests { get; private set; }

        /// <summary>
        ///     Gets the sample responses associated with the API.
        /// </summary>
        public IDictionary<MediaTypeHeaderValue, object> SampleResponses { get; private set; }

        #endregion
    }
}