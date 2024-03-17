namespace MailServiceProvider.Body;

public class HTMLBody : IBody
{
    public bool CanBuild { get; set; }
    public string? Content { get; set; }

    public void H1(string inner)
    {
        if (!CanBuild)
            return;

        Content += $"<h1>{inner}</h1>";
    }
    
    public void H2(string inner)
    {
        if (!CanBuild)
            return;
    
        Content += $"<h2>{inner}</h2>";
    }
    
    public void H3(string inner)
    {
        if (!CanBuild)
            return;

        Content += $"<h3>{inner}</h3>";
    }
    
    public void P(string inner)
    {
        if (!CanBuild)
            return;

        Content += $"<p>{inner}</p>";
    }
    
    public void Span(string inner)
    {
        if (!CanBuild)
            return;

        Content += $"<span>{inner}</span>";
    }
    
    public void A(string inner, string href)
    {
        if (!CanBuild)
            return;

        Content += $"<a href='{href}'>{inner}</a>";
    }
    
    public void DivStart(string classname)
    {
        if (!CanBuild)
            return;

        Content += $"<div class='{classname}'>";
    }

    public void DivEnd()
    {
        if (!CanBuild)
            return;

        Content += $"</div>";
    }
}