using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exam.Data;

namespace Exam.WebAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        private IExamData data;

        public BaseApiController(IExamData data)
        {
            this.data = data;
        }

        protected IExamData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}
