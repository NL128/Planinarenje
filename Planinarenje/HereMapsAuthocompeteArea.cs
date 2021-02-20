using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planinarenje
{
    public class HereMapsAuthocompeteArea
    {
        private string Authocomplete { get; set; }

        public string GetAuthocomplete()
        {
            return Authocomplete;
        }
        public void SetAuthoComplete(string reference)
        {
            Authocomplete = reference;
        }
        private void AuthocompleteJavascript()
        {
            SetAuthoComplete(@"https://autocomplete.geocoder.ls.hereapi.com/6.2/suggest.json?apiKey=kI9Red6f6Bmm5ummtOtMXgTIbML55lQDCFqpgX2ZgLo&query=Beograd&language=en&country=SRB&beginHighlight=%3Cb%3E&endHighlight=%3C/b%3E");
        }
    }
}