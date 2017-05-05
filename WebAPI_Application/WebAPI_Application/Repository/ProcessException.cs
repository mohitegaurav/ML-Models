using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WebAPI_Application.Repository
{
    public class ProcessException : Exception
    {
        public ProcessException(string message)
            : base(message)
        {

        }
    }

    public class ProcessExceptionFilterAttribute : ExceptionFilterAttribute, IExceptionFilter
    {
        string filePath = string.Empty;

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            filePath = AppDomain.CurrentDomain.BaseDirectory + @"\Exception.txt";
            System.IO.StreamWriter objSWriter = new System.IO.StreamWriter(filePath, true);
            objSWriter.WriteLine(string.Format("Date & Time:{0}, Exception:{1}", DateTime.Now, actionExecutedContext.Exception));

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Exception Logged into file."),
                ReasonPhrase = "Exception has been handled in file."
            };


            //Create the Error Response
            actionExecutedContext.Response = response;
        }
    }
}