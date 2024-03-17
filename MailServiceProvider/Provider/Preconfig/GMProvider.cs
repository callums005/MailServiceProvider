namespace MailServiceProvider.Provider;

public class GMProvider : IProvider
{
    public string Host { get; set; } = "smtp.gmail.com";
    public int Port { get; set; } = 587;
    public string EmailCredential { get; init; }
    public string ApplicationPasswordCredential { get; init; }

    public GMProvider(string emailCredential, string appPasswordCredential)
    {
        EmailCredential = emailCredential;
        ApplicationPasswordCredential = appPasswordCredential;
    }
}