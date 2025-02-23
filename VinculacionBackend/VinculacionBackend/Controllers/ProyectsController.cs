using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using VinculacionBackend.Entities;
using System.Web.Http.Cors;
using System.Web.OData;
using VinculacionBackend.Models;
using VinculacionBackend.Repositories;
using VinculacionBackend.Services;

namespace VinculacionBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectsController : ApiController
    {
        private readonly ProjectServices _services;

        public ProjectsController(ProjectServices services)
        {
            _services = services;
        }

        // GET: api/Projects
        [Route("api/Projects")]
        [CustomAuthorize(Roles = "Admin,Professor,Student")]
        [EnableQuery]
        public IQueryable<Project> GetProjects()
        {
            return _services.All();
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        [Route("api/Projects/{projectId}")]
        [CustomAuthorize(Roles = "Admin,Professor,Student")]
        public IHttpActionResult GetProject(long projectId)
        {
            Project project = _services.Find(projectId);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        [Route("api/Projects/Students/{projectId}")]
        [CustomAuthorize(Roles = "Admin,Professor,Student")]
        public IQueryable<User> GetProjectStudents(long projectId)
        {
            return _services.GetProjectStudents(projectId);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        [Route("api/Projects/{projectId}")]
        public IHttpActionResult PutProject(long projectId, ProjectModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tmpProject = _services.UpdateProject(projectId, model);
            
            if (tmpProject == null)
            {
                return NotFound();
            }
            
            return Ok(tmpProject);
        }

        // POST: api/Projects
        [Route("api/Projects")]
        [ResponseType(typeof(Project))]
        [CustomAuthorize(Roles = "Admin,Professor")]
        public IHttpActionResult PostProject(ProjectModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var project= new Project();
            project.Name = model.Name;
            project.Description = model.Description;
            _services.Add(project);
            return Ok(project);
        }

        // DELETE: api/Projects/5
        [Route("api/Projects/{projectId}")]
        [CustomAuthorize(Roles = "Admin")]
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(long projectId)
        {
            Project project = _services.Delete(projectId);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }
    }
}