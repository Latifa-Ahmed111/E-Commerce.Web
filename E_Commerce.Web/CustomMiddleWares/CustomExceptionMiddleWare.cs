using Azure.Core.Serialization;
using DomainLayer.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Shared.ErorrModels;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace E_Commerce.Web.CustomMiddleWares
{
    //public class CustomExceptionMiddleWare
    //{
    //    private readonly RequestDelegate next;
    //    private readonly ILogger<CustomExceptionMiddleWare> logger;

    //    public  CustomExceptionMiddleWare(RequestDelegate Next,ILogger<CustomExceptionMiddleWare> logger)
    //    {
    //        next = Next;
    //        this.logger = logger;
    //    }


    //    public async  Task Invoke(HttpContext httpcontext )
    //    {

    //        try
    //        {
    //            await next.Invoke(httpcontext);
    //        }

    //        catch (Exception ex)
    //        {
    //            //Forbackend
    //            logger.LogError(ex,"Somthing Wrong ");

    //            //set the status code
    //            httpcontext.Response.StatusCode = ex switch
    //            {
    //                NotFoundException => StatusCodes.Status404NotFound, 
    //                _ => StatusCodes.Status500InternalServerError       
    //            };
    //            //set  content type for response 
    //            httpcontext.Response.ContentType = "application/json";
    //            //response object   
    //            var Response = new ErrorTOReturn()
    //            {
    //                StatusCode = httpcontext.Response.StatusCode,
    //                ErrorMessage = ex.Message,


    //            };
    //            await httpcontext.Response.WriteAsJsonAsync(Response);
    //            //return object as json 



    //        }

    //    }

    //}

    public class CustomExceptionMiddleWare
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomExceptionMiddleWare> logger;

        public CustomExceptionMiddleWare(RequestDelegate Next, ILogger<CustomExceptionMiddleWare> logger)
        {
            next = Next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpcontext)
        {
            try
            {
                await next.Invoke(httpcontext);
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                logger.LogError(ex, "Something went wrong");

                // Set the status code based on the type of exception
                httpcontext.Response.StatusCode = ex switch
                {
                    ProductNotFoundException => StatusCodes.Status404NotFound,
                    NotFoundException => StatusCodes.Status404NotFound, // Handle general not found exceptions
                    _ => StatusCodes.Status500InternalServerError  // Fallback for unexpected errors
                };

                // Set content type for the response
                httpcontext.Response.ContentType = "application/json";

                // Prepare the response object
                var response = new ErrorTOReturn()
                {
                    StatusCode = httpcontext.Response.StatusCode,
                    ErrorMessage = ex is ProductNotFoundException ? "productnotfound" : ex.Message
                };

                // Serialize and send the response
                var responseToReturn = JsonSerializer.Serialize(response);
                await httpcontext.Response.WriteAsync(responseToReturn);
            }
        }
    }

}
