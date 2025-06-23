namespace Assets.App.UIElements.NarrativeSection.DTOs
{
    public class TextDTO
    {
        public string Text { get; set; }
        public TextStyle StyleOverride { get; set; }

        public override string ToString()
        {
            return Text;
        }
        public TextDTO(string text, TextStyle styleOverride = null)
        {
            Text = text;
            StyleOverride = styleOverride;
        }
    }
}