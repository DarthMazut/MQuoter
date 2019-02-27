using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MQuoter
{
    public struct Quote
    {
        public string QuoteText { get; set; }

        public SolidColorBrush Color { get; set; }

        public Quote(string text, SolidColorBrush color)
        {
            QuoteText = text;
            Color = color;
        }
    }
}
