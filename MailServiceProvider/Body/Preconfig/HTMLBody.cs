namespace MailServiceProvider.Body;

public class HTMLBody : IBody
{
    public string? Content { get; set; }

    public void H1(string inner)
    {
        Content += $"<h1>{inner}</h1>";
    }
    
    public void H2(string inner)
    {
        Content += $"<h2>{inner}</h2>";
    }
    
    public void H3(string inner)
    {
        Content += $"<h3>{inner}</h3>";
    }
    
    public void P(string inner)
    {
        Content += $"<p>{inner}</p>";
    }
    
    public void Span(string inner)
    {
        Content += $"<span>{inner}</span>";
    }
    
    public void A(string inner, string href)
    {
        Content += $"<a href='{href}'>{inner}</a>";
    }

    public void Img(string src, string alt = "Alternative text has not been implemented for this image.")
    {
        Content += $"<img src='{src}' alt='{alt}' />";
    }
    
    public void DivStart(string classname)
    {
        Content += $"<div class='{classname}'>";
    }

    public void DivEnd()
    {
        Content += $"</div>";
    }
}