using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCollections.Models.Models
{
    public class AuthSenderOptions
    {
        private string user = "Derek Nichols"; // The name you want to show up on your email
                                               // Make sure the string passed in below matches your API Key
        private string key = "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";
        public string SendGridUser { get { return user; } }
        public string SendGridKey { get { return key; } }
    }
}
