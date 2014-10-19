namespace TP1.Controllers
{
    using System.Web.Http;

    using DataAccess.Repositories;
    using DataAccess.Repositories.Interfaces.Async;

    using Services.Factories;

    public class BaseApiController : ApiController
    {
        #region Fields

        /// <summary>
        ///     The project convert factory.
        /// </summary>
        private ProjectConvertFactory projectConvertFactory;

        /// <summary>
        ///     The project repository.
        /// </summary>
        private IProjectRepositoryAsync projectRepositoryAsync;

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the project convert factory.
        /// </summary>
        public ProjectConvertFactory ProjectConvertFactory
        {
            get
            {
                return this.projectConvertFactory = this.projectConvertFactory ?? new ProjectConvertFactory();
            }
        }

        /// <summary>
        ///     Gets the project repository.
        /// </summary>
        public IProjectRepositoryAsync ProjectRepositoryAsync
        {
            get
            {
                return this.projectRepositoryAsync = this.projectRepositoryAsync ?? new ProjectRepositoryAsync();
            }
        }

        #endregion
    }
}
