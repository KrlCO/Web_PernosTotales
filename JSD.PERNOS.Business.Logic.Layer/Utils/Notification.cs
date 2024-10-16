
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace JSD.SUNKU.Business.Logic.Layer.Utils
{
    public class Notification
    {
        private readonly IConfiguration _configuration;

        public Notification(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private void CorreoAcces(out string _from, out string _userName, out string _password, out string _hostName, out int _port)
        {
            _from = "";
            _userName = "";
            _password = "";
            _hostName = "";
            _port = 0;

        }

        public void EnviarCorreoAsync(CorreoMensaje correoMensaje)
        {
            Task.Run(async () =>
            {
                CorreoAcces(out string _from, out string _userName, out string _password, out string _hostName, out int _port);

                using MailMessage message = new MailMessage();
                message.From = new MailAddress(_from);

                var body = correoMensaje.Cuerpo;

                correoMensaje.Para.ForEach(d => message.To.Add(new MailAddress(d)));
                correoMensaje.Copia.ForEach(c => message.To.Add(new MailAddress(c)));
                correoMensaje.Adjuntos.ForEach(a => message.Attachments.Add(a));

                message.Subject = correoMensaje.Asunto;
                message.Body = body;
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient(_hostName)
                {
                    Port = _port,
                    Credentials = new NetworkCredential(_userName, _password)
                };
                await smtpClient.SendMailAsync(message);
            });

        }
    }
}
