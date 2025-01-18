using GcsServices.Interfaces;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace GcsServices.Implementation
{
    public class CorreoService : ICorreoService
    {
        private readonly IConfiguration _configuration;
        private SmtpClient _smtp;
        private readonly string _host;
        private readonly int _port;
        private readonly string _user;
        private readonly string _pass;

        public CorreoService(IConfiguration configuration)
        {
            _configuration = configuration;
            
            _smtp = new SmtpClient();
            _host = _configuration["Smtp:host"]!;
            _port = Convert.ToInt32(_configuration["Smtp:port"]!);
            _user = _configuration["Smtp:user"]!;
            _pass = _configuration["Smtp:pass"]!;
        }

        public async Task Enviar(string para, string asunto, string mensajeHtml)
        {
            _smtp = new SmtpClient();
            _smtp.Connect(_host, _port, SecureSocketOptions.StartTls);
            _smtp.Authenticate(_user, _pass);

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_user));
            email.To.Add(MailboxAddress.Parse(para));
            email.Subject = asunto;
            email.Body = new TextPart(TextFormat.Html) 
            {
                Text = mensajeHtml
            };

            await _smtp.SendAsync(email);
            await _smtp.DisconnectAsync(true);

        }
    }
}
