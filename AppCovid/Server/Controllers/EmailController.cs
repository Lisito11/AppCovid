using AppCovid.Server.DTOs;
using AppCovid.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCovid.Server.Controllers {
    [Route("api/email")]
    public class EmailController : Controller {
        private readonly IEmailSender _emailSender;
        public EmailController(IEmailSender emailSender) { _emailSender = emailSender;}

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] PersonaCreacionDTO personaCreacionDTO) {
            await _emailSender
                .SendEmailAsync($"{personaCreacionDTO.Email}", "Asunto", "<h1>Gracias por usar nuestros servicios</h1>" +
                    "<p> Nombre: " + personaCreacionDTO.Nombres + "</p>" +
                    "<p> Apellidos: " + personaCreacionDTO.Apellido1 + personaCreacionDTO.Apellido2 + "</p>" +
                    "<p> Telefono: " + personaCreacionDTO.Telefono + "</p>" +
                    "<p> Cedula: " + personaCreacionDTO.Cedula + "</p>" +
                    "<p> Tipo de sangre: " + personaCreacionDTO.TipoSangre + "</p>" +
                    "<p> Email: " + personaCreacionDTO.Email + "</p>" +
                    "<p> Justificacion: " + personaCreacionDTO.Justifacion + "</p>")
                .ConfigureAwait(false);
            return View();
        }
    }
}
