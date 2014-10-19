namespace TP1.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
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
        public async Task<HttpResponseMessage> GetProject(int id)
        {
            try
            {
                var data = this.ProjectConvertFactory.FromModel(await this.ProjectRepositoryAsync.GetByIdAsync(id));
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }

        // POST api/project
        public async Task<HttpResponseMessage> PostProject([FromBody]ProjectDto project)
        {
            Project entity = this.ProjectConvertFactory.ToModel(project);
            entity.DateAdded = DateTime.Today;
            await this.ProjectRepositoryAsync.AddAsync(entity);
            return this.Request.CreateResponse(HttpStatusCode.Created);
        }

        // PUT api/project/5
        public async Task<HttpResponseMessage> PutProject(int id, [FromBody]ProjectDto project)
        {
            Project entity = this.ProjectConvertFactory.ToModel(project);
            await this.ProjectRepositoryAsync.UpdateAsync(entity);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/project/5
        public async Task<HttpResponseMessage> DeleteProject(int id)
        {
            Project projectToRemove = await this.ProjectRepositoryAsync.GetByIdAsync(id);
            await this.ProjectRepositoryAsync.RemoveAsync(projectToRemove);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
