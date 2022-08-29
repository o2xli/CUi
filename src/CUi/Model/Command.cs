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
        public Func<IEnumerable<SubCommand>> SubCommands { get; set; }
        public Func<IEnumerable<Argument>> Args { get; set; }
        public Func<IEnumerable<Option>> Options { get; set; }

    }
}
