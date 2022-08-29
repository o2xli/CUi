using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUi.Model
{
    internal class Enums
    {
        [Flags]
        public enum TemplateType 
        { 
            none = 0,
            file = 1,
            files = 2,
            folder = 4,
            folders = 8,
            text = 16,
            suggestions = 32
        }
    }
}
