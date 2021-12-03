using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace Project06.Models
{
    public class Correo
    {

        public static void EnviarCorreo(String Cuerpo, String Asunto, String Destinatario)
        {

            try
            {

                var sClient = new SmtpClient("smtp.live.com"); 
                var message = new MailMessage();

                sClient.Port = 587; 
                sClient.EnableSsl = true;
                sClient.UseDefaultCredentials = false;
                sClient.Credentials = new System.Net.NetworkCredential("bancodelpueblocr@outlook.com", "BancoDelPueblo01");

                message.Body = Cuerpo;
                message.From = new MailAddress("bancodelpueblocr@outlook.com");
                message.Subject = Asunto;
                message.To.Add(new MailAddress(Destinatario));
                message.CC.Add(new MailAddress("pirlocc637@gmail.com")); ;
                message.IsBodyHtml = true;

                sClient.Send(message);

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error: " + e.Message);
            }

        }
        


    }
}