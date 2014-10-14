using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model.DomainModels;
using Model.DTOs;

namespace TP1.Controllers
{
    public class ProjectController : BaseApiController
    {
        // GET api/project
        public IHttpActionResult GetProject()
        {
            return Ok();
        }

        // GET api/project/5
        public IHttpActionResult GetProject(int id)
        {
            try
            {
                var data = this.ProjectConvertFactory.FromModel(this.ProjectRepository.GetById(id));
                return this.Ok(data);
            }
            catch
            {
                return this.NotFound();
            }
        }

        // POST api/project
        public IHttpActionResult PostProject([FromBody]ProjectDto project)
        {
            Project entity = this.ProjectConvertFactory.ToModel(project);
            entity.DateAdded = DateTime.Today;
            this.ProjectRepository.Add(entity);

           // return this.Request.CreateResponse(HttpStatusCode.Created);
            return this.Created<ProjectDto>(Request.RequestUri + entity.Id.ToString(CultureInfo.InvariantCulture), this.ProjectConvertFactory.FromModel(entity));
        }

        // PUT api/project/5
        public IHttpActionResult PutProject(int id, [FromBody]ProjectDto project)
        {
            Project entity = this.ProjectConvertFactory.ToModel(project);
            this.ProjectRepository.Update(entity);

            return this.Ok();
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
