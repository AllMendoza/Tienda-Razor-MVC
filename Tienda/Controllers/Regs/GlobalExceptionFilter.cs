using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tienda.Models.Modelos;
using Tienda.Models.Modelos.Regs;

namespace Tienda.Controllers.Admin
{
    public class GlobalExceptionFilter : IAsyncExceptionFilter
    {
        private readonly masterContext _context;

        public GlobalExceptionFilter(masterContext context)
        {
            _context = context;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {

            dynamic exception = context.Exception;
            List<object> errors = new List<object>();


            if (context.Exception.Message == "IdentityError")
            {
                foreach (object error in context.Exception.InnerException.Data)
                {
                    errors.Add(error);
                }
            }

            errors.Add(new { errorType = exception.Message ?? "Unknown Error" });

            var json = new
            {
                errors = new[] { errors.ToArray() }
            };

            dynamic jsonResponse = new JsonResponseDto();
            jsonResponse.message = json;
            jsonResponse.code = (int)HttpStatusCode.BadRequest;



            Error _error = new Error();
            _error.Date = DateTime.Now;
            _error.Codigo = 400;
            _error.Mensaje = exception.Message.ToString();
            _error.Id = 2;

            context.Result = new BadRequestObjectResult(jsonResponse);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.ExceptionHandled = true;



            try
            {
                _context.Database.ExecuteSqlRaw
                    ("INSERT INTO errores(Date, Mensaje, Codigo) VALUES ('" + _error.Date.ToString() + 
                    "','" + _error.Mensaje + 
                    "'," + _error.Codigo.ToString() + 
                    ")");

                
            }
            catch (Exception e)
            {
                
            }





        }

    async Task ConexionAsync(Error _error)
        {
            try { 
            using (SqlConnection connection = new SqlConnection(@"Data Source=ASUSI5\MSSQLSERVER01;Initial Catalog=master;Integrated Security=True"))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                connection.Open();

                String sql = "INSERT INTO errores(Date, Mensaje, Codigo) VALUES ('" + _error.Date.ToString() + "','" + _error.Mensaje + "'," + _error.Codigo.ToString() + ")";

                    SqlCommand command = new SqlCommand(sql, connection);
                    await command.Connection.OpenAsync();
                   
                    await command.ExecuteNonQueryAsync();
                   
                    //object p = command.Transaction;
                    command.Connection.Close();
                    //SqlConnection connection = new SqlConnection connection;

            }
        }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
}
    }
}
