namespace TP1.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Model.DomainModels;
    using Model.DTOs;

    public class ProjectController : BaseApiController
    {
        // GET api/project
        public HttpResponseMessage GetProject()
        {
            HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.Created);

            return response;
        }

        // GET api/project/5
        public HttpResponseMessage GetProject(int id)
        {
            try
            {
                var data = this.ProjectConvertFactory.FromModel(this.ProjectRepository.GetById(id));
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }

        // POST api/project
        public HttpResponseMessage PostProject([FromBody]ProjectDto project)
        {
            Project entity = this.ProjectConvertFactory.ToModel(project);
            entity.DateAdded = DateTime.Today;
            this.ProjectRepository.Add(entity);

            return this.Request.CreateResponse(HttpStatusCode.Created);
        }

        // PUT api/project/5
        public HttpResponseMessage PutProject(int id, [FromBody]ProjectDto project)
        {
            Project entity = this.ProjectConvertFactory.ToModel(project);
            this.ProjectRepository.Update(entity);

            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/project/5
        public HttpResponseMessage DeleteProject(int id)
        {
            Project projectToRemove = this.ProjectRepository.GetById(id);
            this.ProjectRepository.Remove(projectToRemove);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
