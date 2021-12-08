namespace ShareMyPaper.Infraestructure.Objects
{
    public class Email
    {
        public string RecipientName { get; set; }
        public string RecipientMail { get; set; }
        public string Subject { get; set; }
        public string PlainTextContent { get; set; }
        public string HtmlContent { get; set; }
    }
}