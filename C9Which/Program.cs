using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C9Which
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineApplication cla = new CommandLineApplication(false);
            //CommandArgument items = null;
            //cla.Command()

            CommandOption showUnused = cla.Option("-u|--unused", "Show unused path elements", CommandOptionType.NoValue);
            cla.HelpOption("-? | -h | --help");

            string path = Environment.GetEnvironmentVariable("path");

            cla.Execute(args);
            
            string[] targets = path.Split(';');

            if (args.Length > 0)
            {
                string askAbout = /*args[0]*/cla.RemainingArguments[0].ToLower();
                for (int ct = 0; ct < targets.Length; ct++)
                {
                    string thisTarget = targets[ct];
                    if (Directory.Exists(thisTarget))
                    {
                        string[] files = Directory.GetFiles(thisTarget);

                        foreach (string file in files)
                        {
                            string foldFileName = file.ToLower();
                            string justFileName = Path.GetFileName(foldFileName);
                            if (justFileName.Equals(args[0]))
                            {
                                Console.Out.WriteLine(file);
                            }
                        }
                    }
                    else
                    {
                        if (showUnused.HasValue())
                        {
                            Console.Error.WriteLine($"Not a folder \"{thisTarget}\"");
                        }
                    }
                }
            }
        }
    }
}
