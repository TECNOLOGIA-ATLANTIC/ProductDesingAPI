﻿namespace AtlanticProductDesing.Application.Models
{
    public class Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }

        public List<EmailAttachment>? emailAttachments { get; set; }
    }



}
