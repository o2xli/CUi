using CUi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace CUi.Commands
{
    internal class Copy : Command
    {
        /// <summary>
        ///  command subcommand option argument
        /// </summary>
        public Copy(Context ctx)
        {
            this.Name = "Copy";
            //this.Scheme = "copy "
            this.Description = "Copy files and directories";
            this.Args = () =>
            {                
                return new Argument[] 
                {
                    new()
                    {
                        Name = "source",
                        Variadic = true,
                        Template = Enums.TemplateType.folder | Enums.TemplateType.file
                    },
                    new()
                    {
                        Name = "target",
                        Template = Enums.TemplateType.folder | Enums.TemplateType.file
                    }
                };
            };
            this.Options = () =>
            {
                return new Option[]
                {
                    new()
                    {
                        Name = "-a",
                        Description="Preserves structure and attributes of files but not directory structure",
                    },
                    new()
                    {
                        Name= "-f",
                        Description="If the destination file cannot be opened, remove it and create a new file, without prompting for confirmation",
                        ExclusiveOn= {"-n"},
                    },
                    new()
                    {
                        Name= "-H",
                        Description="If the -R option is specified, symbolic links on the command line are followed",
                        ExclusiveOn= {"-L", "-P" },
                        DependsOn= {"-R"},
                    },
                    new()
                    {
                        Name= "-i",
                        Description="Cause cp to write a prompt to the standard error output before copying a file that would overwrite an existing file",
                        ExclusiveOn= {"-n"},
                    },
                    new()
                    {
                        Name= "-L",
                        Description= "If the -R option is specified, all symbolic links are followed",
                        ExclusiveOn= {"-H", "-P"},
                        DependsOn= {"-R"},
                    },
                    new()
                    {
                        Name= "-n",
                        Description= "Do not overwrite an existing file",
                        ExclusiveOn= {"-f", "-i"},
                    },
                    new()
                    {
                        Name= "-P",
                        Description="If the -R option is specified, no symbolic links are followed",
                        ExclusiveOn= {"-H", "-L"},
                        DependsOn= {"-R"},
                    },
                    new()
                    {
                        Name= "-R",
                        Description="If source designates a directory, cp copies the directory and the entire subtree connected at that point. If source ends in a /, the contents of the directory are copied rather than the directory itself",
                    },
                    new()
                    {
                        Name= "-v",
                        Description= "Cause cp to be verbose, showing files as they are copied",
                    },
                    new()
                    {
                        Name= "-X",
                        Description= "Do not copy Extended Attributes (EAs) or resource forks",
                    },
                    new()
                    {
                        Name= "-c",
                        Description= "Copy files using clonefile",
                    }

                };
            };

        }
    }
}
