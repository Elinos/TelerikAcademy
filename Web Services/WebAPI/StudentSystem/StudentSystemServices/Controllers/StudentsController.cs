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

    public class StudentsController : ApiController
    {
        private readonly StudentsSystemData data = new StudentsSystemData();

        [HttpGet]
        public IQueryable<StudentTemplate> GetAllStudents()
        {
            return this.data.Students.All().Select(StudentTemplate.FromStudent);
        }

        [HttpGet]
        public HttpResponseMessage GetStudentById(int id)
        {
            var requestedStudentFromDb = this.data.Students.SearchFor(s => s.Id == id).FirstOrDefault();
            if (requestedStudentFromDb == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, "Student not found!");
            }

            var studentToReturn = new StudentTemplate
            {
                FirstName = requestedStudentFromDb.FirstName,
                LastName = requestedStudentFromDb.LastName
            };

            return this.Request.CreateResponse(HttpStatusCode.OK, studentToReturn);
        }

        [HttpPost]
        public HttpResponseMessage AddStudent(StudentTemplate student)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            var newStudentToAdd = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                AdditionalInformation = new StudentInfo()
            };

            this.data.Students.Add(newStudentToAdd);
            this.data.SaveChanges();

            var response = this.Request.CreateResponse<StudentTemplate>(HttpStatusCode.Created, student);

            string uri = this.Url.Link("DefaultApi", new { id = newStudentToAdd.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage UpdateStudent(int id, StudentTemplate updatedStudent)
        {
            var requestedStudentFromDb = this.data.Students.SearchFor(s => s.Id == id).FirstOrDefault();
            if (requestedStudentFromDb == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, "Student not found!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            requestedStudentFromDb.FirstName = updatedStudent.FirstName;
            requestedStudentFromDb.LastName = updatedStudent.LastName;
            this.data.Students.Update(requestedStudentFromDb);
            this.data.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK, "Student updated!");
        }

        [HttpDelete]
        public HttpResponseMessage DeleteStudent(int id)
        {
            var requestedStudentFromDb = this.data.Students.SearchFor(s => s.Id == id).FirstOrDefault();
            if (requestedStudentFromDb == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, "Student not found!");
            }

            this.data.Students.Delete(requestedStudentFromDb);
            this.data.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK, "Student deleted!");
        }
    }
}