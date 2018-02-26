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
            string path = Environment.GetEnvironmentVariable("path");

            string[] targets = path.Split(';');

            if (args.Length > 0)
            {
                string askAbout = args[0].ToLower();
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
                        Console.Error.WriteLine($"Not a folder \"{thisTarget}\"");
                    }
                }
            }
        }
    }
}
