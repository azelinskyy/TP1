namespace TP1.Controllers
{
    using System.Web.Http;

    using DataAccess.Repositories;

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
        private ProjectRepository projectRepository;

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
        public ProjectRepository ProjectRepository
        {
            get
            {
                return this.projectRepository = this.projectRepository ?? new ProjectRepository();
            }
        }

        #endregion
    }
}
