using System.Net;
using System.Net.Mail;
using MailServiceProvider.Body;
using MailServiceProvider.Provider;

namespace MailServiceProvider.Mail;

public interface IMail
{
    public IProvider Provider { get; init; }
    public List<string> MailingList { get; set; }
    public string FromAddress { get; set; }
    public string Subject { get; set; }
    public IBody Body { get; set; }

    public bool Send();
}