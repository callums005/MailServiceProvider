namespace MailServiceProvider.Body;

public class PlainTextBody : IBody
{
    public bool CanBuild { get; set; }

    private string? _content;
    public string? Content
    {
        get => _content;
        set
        {
            if (CanBuild)
                _content = value;
        }
    }
}