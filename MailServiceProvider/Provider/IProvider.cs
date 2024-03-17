namespace MailServiceProvider.Provider;

public interface IProvider
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string EmailCredential { get; init; }
    public string ApplicationPasswordCredential { get; init; }
}