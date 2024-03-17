using MailServiceProvider.Body;
using MailServiceProvider.Mail;
using MailServiceProvider.Provider;

namespace Appication;

class Program
{
    public static void Main(string[] args)
    {
        List<string> emails = new()
        {
            "dev@callums005.net"
        };

        HTMLBody body = new();

        body.Img("https://www.lotus-qa.com/wp-content/uploads/2020/02/testing.jpg");
        body.H1("Hello World!");
        body.P("This is a html test");
        
        Mail exampleMail = new()
        {
            Provider = new GMProvider("internalcommportal@gmail.com", Environment.GetEnvironmentVariable("InternalCommunicationPortal_SMTP_AccessToken")),
            MailingList = emails,
            FromAddress = "internalcommportal@gmail.com",
            Subject = "Hello World!",
            Body = body
        };

        exampleMail.Send();
    }
}