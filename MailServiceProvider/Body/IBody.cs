namespace MailServiceProvider.Body;

public interface IBody
{
    public bool CanBuild { get; set; }
    public string? Content { get; set; }
    
    public void StartBuild() => CanBuild = true;
    private void EndBuild() => CanBuild = false;
}