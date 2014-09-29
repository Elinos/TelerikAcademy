namespace StudentSystemServices.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystemServices.Models;

    public class HomeworksController : ApiController
    {
        private readonly StudentsSystemData data = new StudentsSystemData();

        [HttpGet]
        public IQueryable<HomeworkTemplate> GetAllHomeworks()
        {
            return this.data.Homeworks.All().Select(HomeworkTemplate.FromHomework);
        }

        [HttpGet]
        public HttpResponseMessage GetHomeworkById(int id)
        {
            var requestedHomeworkFromDb = this.data.Homeworks.SearchFor(s => s.Id == id).FirstOrDefault();
            if (requestedHomeworkFromDb == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, "Homework not found!");
            }

            var homeworkToReturn = new HomeworkTemplate
            {
                FileUrl = requestedHomeworkFromDb.FileUrl,
                TimeSent = requestedHomeworkFromDb.TimeSent
            };

            return this.Request.CreateResponse(HttpStatusCode.OK, homeworkToReturn);
        }

        [HttpPost]
        public HttpResponseMessage AddHomework(HomeworkTemplate homework)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            var newHomeworkToAdd = new Homework
            {
                FileUrl = homework.FileUrl,
                TimeSent = DateTime.Now
            };

            this.data.Homeworks.Add(newHomeworkToAdd);
            this.data.SaveChanges();

            var response = this.Request.CreateResponse<HomeworkTemplate>(HttpStatusCode.Created, homework);

            string uri = this.Url.Link("DefaultApi", new { id = newHomeworkToAdd.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage UpdateHomework(int id, HomeworkTemplate updatedHomework)
        {
            var requestedHomeworkFromDb = this.data.Homeworks.SearchFor(s => s.Id == id).FirstOrDefault();
            if (requestedHomeworkFromDb == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, "Homework not found!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            requestedHomeworkFromDb.FileUrl = updatedHomework.FileUrl;
            this.data.Homeworks.Update(requestedHomeworkFromDb);
            this.data.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK, "Homework updated!");
        }

        [HttpDelete]
        public HttpResponseMessage DelateHomework(int id)
        {
            var requestedHomeworkFromDb = this.data.Homeworks.SearchFor(s => s.Id == id).FirstOrDefault();
            if (requestedHomeworkFromDb == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, "Homework not found!");
            }

            this.data.Homeworks.Delete(requestedHomeworkFromDb);
            this.data.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK, "Homework deleted!");
        }
    }
}