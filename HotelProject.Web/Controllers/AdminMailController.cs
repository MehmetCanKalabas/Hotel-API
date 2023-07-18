using HotelProject.Web.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace HotelProject.Web.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel adminMailViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelAdmin","commentproject.34@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", adminMailViewModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder= new BodyBuilder();
            bodyBuilder.TextBody = adminMailViewModel.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = adminMailViewModel.Subject;
            
            SmtpClient  smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("commentproject.34@gmail.com", "ylndlrrshanwsrra");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return RedirectToAction("Index","AdminDashboard");
        }
    }
}
