using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            string from = "leilsonjau@gmail.com";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(from,"murgo1010");
            smtp.EnableSsl = true;

            string corpo = string.Format("<h2> Contato - Loja Virtual</h2>" +
                "<b>Nome: </b> {0} <br />" +
                "<b>Email: </b> {1} <br />" +
                "<b>Texto: </b> {2} <br />" +
                "<br /> E-mail enviado automaticamente.",
                contato.Nome,
                contato.Email,
                contato.Texto
                );
            
            
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress(from);
            mensagem.To.Add("leilsonmurgo@sti3.com.br");
            mensagem.Subject = "Contato - Loja Virtual";
            mensagem.Body = corpo;
            mensagem.IsBodyHtml = true;

            smtp.Send(mensagem);

        }
    }
}
