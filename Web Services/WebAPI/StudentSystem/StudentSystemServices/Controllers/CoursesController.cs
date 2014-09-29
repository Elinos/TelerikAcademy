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

    public class CoursesController : ApiController
    {
        private readonly StudentsSystemData data = new StudentsSystemData();

        [HttpGet]
        public IQueryable<CourseTemplate> GetAllCourses()
        {
            return this.data.Courses.All().Select(CourseTemplate.FromCourse);
        }

        [HttpGet]
        public HttpResponseMessage GetCourseById(int id)
        {
            var requestedCourseFromDb = this.data.Courses.SearchFor(s => s.Id == id).FirstOrDefault();
            if (requestedCourseFromDb == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, "Course not found!");
            }

            var courseToReturn = new CourseTemplate
            {
                Name = requestedCourseFromDb.Name,
                Description = requestedCourseFromDb.Description
            };

            return this.Request.CreateResponse(HttpStatusCode.OK, courseToReturn);
        }

        [HttpPost]
        public HttpResponseMessage AddCourse(CourseTemplate course)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            var newCourseToAdd = new Course
            {
                Name = course.Name,
                Description = course.Description
            };

            this.data.Courses.Add(newCourseToAdd);
            this.data.SaveChanges();

            var response = this.Request.CreateResponse<CourseTemplate>(HttpStatusCode.Created, course);

            string uri = this.Url.Link("DefaultApi", new { id = newCourseToAdd.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage UpdateCourse(int id, CourseTemplate updatedCourse)
        {
            var requestedCourseFromDb = this.data.Courses.SearchFor(s => s.Id == id).FirstOrDefault();
            if (requestedCourseFromDb == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, "Course not found!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            requestedCourseFromDb.Name = updatedCourse.Name;
            requestedCourseFromDb.Description = updatedCourse.Description;
            this.data.Courses.Update(requestedCourseFromDb);
            this.data.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK, "Course updated!");
        }

        [HttpDelete]
        public HttpResponseMessage DelateCourse(int id)
        {
            var requestedCourseFromDb = this.data.Courses.SearchFor(s => s.Id == id).FirstOrDefault();
            if (requestedCourseFromDb == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, "Course not found!");
            }

            this.data.Courses.Delete(requestedCourseFromDb);
            this.data.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK, "Course deleted!");
        }
    }
}