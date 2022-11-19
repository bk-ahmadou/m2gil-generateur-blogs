using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace m2gil_generateur_blogs.Areas.Identity.Services
{
  public class EmailSender : IEmailSender
  {
    public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
    {
      Options = optionsAccessor.Value;
    }

    public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.


    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
      if (string.IsNullOrEmpty(Options.SendGridKey))
      {
        throw new Exception("Null SendGridKey");
      }
      await Execute(Options.SendGridKey, subject, htmlMessage, email);
    }

    public async Task Execute(string apiKey, string subject, string message, string toEmail)
    {
      var client = new SendGridClient(apiKey);
      var msg = new SendGridMessage()
      {
        From = new EmailAddress("ahmadou.bachir-zp@outlook.com", "Ahmed Free"),
        Subject = subject,
        PlainTextContent = message,
        HtmlContent = message
      };
      msg.AddTo(new EmailAddress(toEmail));

      // Disable click tracking.
      // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
      msg.SetClickTracking(false, false);
      var response = await client.SendEmailAsync(msg);
      if (response.IsSuccessStatusCode)
      {
        Console.WriteLine($"Email to {toEmail} queued successfully!");
      }
      else
      {
        Console.WriteLine($"Failure Email to {toEmail}");
      }
    }
  }
}
