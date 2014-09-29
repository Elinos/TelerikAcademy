using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Web.Http;
using Ninject;
using System.Reflection;
using Exam.Data;

[assembly: OwinStartup(typeof(Exam.WebAPI.Startup))]

namespace Exam.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }
        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IExamData>().To<ExamData>().WithConstructorArgument("context", c => new ExamDbContext());
        }
    }
}
