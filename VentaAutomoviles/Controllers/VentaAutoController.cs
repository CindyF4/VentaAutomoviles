using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentaAutomoviles.Controllers
{
    public class VentaAutoController : Controller
    {
        public string Welcome()
        {
            return "Bienvenido a Auto Sales";
        }
    }
}
