using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUi.Model
{
    internal class Option
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Die Zeichenfolge, die auf der Benutzeroberfläche für einen bestimmten Vorschlag angezeigt wird.
        /// </summary>
        public string Description { get; set; }
        public Action<IEnumerable<Argument>> Args { get; set; }
        /// <summary>
        /// Zeigt an, ob eine Option persistent ist, d. h., dass sie weiterhin als Option für alle untergeordneten Befehle verfügbar ist.
        /// </summary>
        public bool Persitent { get; set; } = false;
        /// <summary>
        /// Gibt an, ob eine Option erforderlich ist.
        /// </summary>
        public bool Required { get; set; } = false;

        /// <summary>
        /// Gibt an, ob eines der in parserDirectives angegebenen Trennzeichen erforderlich ist, um ein Argument an eine Option zu übergeben 
        /// (z.B. git commit --message[separator]"msg"). 
        /// Bei einem Trennzeichen (String) wird automatisch das angegebene Trennzeichen nach dem Optionsnamen eingefügt.
        /// </summary>
        public string Separator { get; set; }
        /// <summary>
        /// Gibt an, ob eine Option mehrfach übergeben werden kann.
        /// </summary>
        public bool Repeatable { get; set; } = false;
        /// <summary>
        /// Gibt an, ob sich eine Option mit anderen Optionen gegenseitig ausschließt.
        /// </summary>
        public string[] ExclusiveOn { get; set; }
        /// <summary>
        /// Gibt an, ob eine Option von anderen Optionen abhängt.
        /// </summary>
        public string[] DependsOn { get; set; }
        

    }
}
