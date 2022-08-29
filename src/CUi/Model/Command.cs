using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUi.Model
{
    internal class Command
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Action<IEnumerable<SubCommand>> SubCommands { get; set; }

        public Action<IEnumerable<Option>> Options { get; set; }

    }
}
