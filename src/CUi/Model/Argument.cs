using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUi.Model
{
    internal class Argument
    {
        private string[] suggestions;

        public string Name { get; set; }
        public string Description { get; set; }

        public Action<string[]> Suggestions { get; set; }

        /// <summary>
        /// Specifies that the argument is variadic and therefore repeats infinitely.
        /// </summary>
        public bool Variadic { get; set; }
        /// <summary>
        /// When true for git add's argument: git add file1 -v file2 will interpret -v as an option NOT an argument, and will continue interpreting file2 as a variadic argument to add after
        /// </summary>
        public bool OptionsCanBreakVariadicArg { get; set; }

    }
}
