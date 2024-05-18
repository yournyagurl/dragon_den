using dragon.Data;
using dragon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;

namespace dragon.Pages.ContactInfo
{
    public class IndexModel : PageModel
    {
        private readonly dragonContext _dragonContext;

        [BindProperty]
        public ContactCentre ContactCentre { get; set; }
        public void OnGet()
        {

        }

        public Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Task.FromResult<IActionResult>(Page());
            }

            // Example: Sending an email
            var emailMessage = new MailMessage
            {
                From = new MailAddress("your-email@example.com"),
                To = { "recipient@example.com" },
                Subject = "New Contact Message",
                Body = $"Name: {ContactCentre.Name}\nEmail: {ContactCentre.Email}\n\n{ContactCentre.Message}"
            };

            using (var smtpClient = new SmtpClient("smtp.example.com"))
            {
                smtpClient.Send(emailMessage);
            }

            // Redirect to a thank you page
            return Task.FromResult<IActionResult>(RedirectToPage("/ThankYou"));
        }
    }
}

