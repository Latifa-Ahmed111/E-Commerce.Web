using Azure.Core.Serialization;
using Microsoft.AspNetCore.Http;
using Shared.ErorrModels;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace E_Commerce.Web.CustomMiddleWares
{
    public class CustomExceptionMiddleWare
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomExceptionMiddleWare> logger;

        public  CustomExceptionMiddleWare(RequestDelegate Next,ILogger<CustomExceptionMiddleWare> logger)
        {
            next = Next;
            this.logger = logger;
        }


        public async  Task Invoke(HttpContext httpcontext )
        {

            try
            {
                await next.Invoke(httpcontext);
            }

            catch (Exception ex)
            {
                //Forbackend
                logger.LogError(ex,"Somthing Wrong ");

                //set the status code
                httpcontext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                //set  content type for response 
                httpcontext.Response.ContentType = "application/json";
                //response object   
                var Response = new ErrorTOReturn()
                {
                    StatusCode = httpcontext.Response.StatusCode,
                    ErrorMessage = ex.Message,


                };
                var ResponseToReturn = JsonSerializer.Serialize(Response);
                 await httpcontext.Response.WriteAsJsonAsync(ResponseToReturn);
                //return object as json 



            }
         
        }
        
    }
}
