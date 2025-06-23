
public class TextStyle
{
    public static readonly TextStyle Normal = new TextStyle("Normal");
    public static readonly TextStyle Link = new TextStyle("Link");
    public static readonly TextStyle Breadcrumb = new TextStyle("Breadcrumb");
    private string Style;
    public TextStyle(string style)
    {
        Style = style;
    }
    public override string ToString()
    {
        return Style;
    }
    
}