using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    class Content
    {
        public Content(string title)
        {
            Title = title;
        }
        public string Title { get; private set; }
    }
}
