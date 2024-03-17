namespace MailServiceProvider.Provider;

public interface IProviderS
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string EnvEmailVar { get; set; }
    public string EnvPasswordVar { get; set; }
}