using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace TodoApp.Controllers
{
    public class BaseController : ControllerBase
    {
        protected TodoContext Context => (TodoContext)HttpContext.RequestServices.GetService(typeof(TodoContext));

    }
}