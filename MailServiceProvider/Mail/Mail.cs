using System.Net;
using System.Net.Mail;
using MailServiceProvider.Body;
using MailServiceProvider.Provider;

namespace MailServiceProvider.Mail;

public class Mail : IMail
{
    public IProvider Provider { get; init; }
    public List<string> MailingList { get; set; }
    public string FromAddress { get; set; }
    public string Subject { get; set; }
    public IBody Body { get; set; }
    
    public bool Send()
    {
        bool success = true;
        
        SmtpClient smtpClient = new()
        {
            Port = Provider.Port,
            EnableSsl = true,
            Credentials = new NetworkCredential(Provider.EmailCredential, Provider.ApplicationPasswordCredential),
            Host = Provider.Host
        };
        
        MailingList.ForEach(_ =>
        {
            MailMessage mailMessage = new(
                FromAddress,
                _,
                Subject,
                Body.Content
            );
            
            switch (Body.ToString())
            {
                case "MailServiceProvider.Body.HTMLBody":
                    mailMessage.IsBodyHtml = true;
                    break;
                case "MailServiceProvider.Body.IBody":
                    Console.Error.WriteLine("Mail class body is defaulted to IBody");
                    break;
            }

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                success = false;
            }
        });

        return success;
    }
}