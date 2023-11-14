using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FrontEnd.Utils
{
    public class CorreoService
    {

        public string Destinatario { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }

    }

    public static class InterfaceEmail
    {
        public static void SendEmail(CorreoService model)
        {
            MailMessage correo = new MailMessage();

            //Correo del que recibimos y nombre a aparecer en remitente
            correo.From = new MailAddress("aplicacionesService365@outlook.com", "Service365", System.Text.Encoding.UTF8);
            correo.To.Add(model.Destinatario);
            correo.Subject = model.Asunto;
            correo.Body = model.Cuerpo;
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.office365.com";
            smtp.Port = 587;
            //Correo y contrasena, en ese mismo orden
            smtp.Credentials = new System.Net.NetworkCredential("aplicacionesService365@outlook.com", "S3rV1c3365");
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(correo);
            }
            catch (Exception )
            {
            }
        }
    }
}