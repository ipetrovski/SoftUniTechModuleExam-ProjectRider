namespace ProjectRider.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    [ValidateInput(false)]
    public class ProjectController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using(var context = new ProjectRiderDbContext())
            {
                List<Project> projects = context.Projects.ToList();

                return View(projects);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            using(var context = new ProjectRiderDbContext())
            {
                context.Projects.Add(project);
                context.SaveChanges();

                return this.Redirect("/");
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            using(var context = new ProjectRiderDbContext())
            {
                Project projectFromDB = context.Projects.Find(id);

                return View(projectFromDB);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Project project)
        {
            using(var context = new ProjectRiderDbContext())
            {
                Project projectFromDB = context.Projects.Find(id);

                projectFromDB.Title = project.Title;
                projectFromDB.Description = project.Description;
                projectFromDB.Budget = project.Budget;

                context.SaveChanges();

                return Redirect("/");

            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            using (var context = new ProjectRiderDbContext())
            {
                Project projectFromDB = context.Projects.Find(id);

                return View(projectFromDB);

            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Project reportModel)
        {
            using (var context = new ProjectRiderDbContext())
            {
                Project projectFromDB = context.Projects.Find(id);

                context.Projects.Remove(projectFromDB);
                context.SaveChanges();

                return Redirect("/");

            }
        }
    }
}