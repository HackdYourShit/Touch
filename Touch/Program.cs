using System;
using System.IO;
using System.Reflection;
using com.dave.Touch;

namespace com.dave.Touch
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {

        private static bool isDir = false;
        private static bool isFile = false;
        private static DateTime dateFormat = DateTime.MinValue;
        private static string dirFilename = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

            AppDomain.CurrentDomain.AssemblyResolve += (Object sender, ResolveEventArgs args2) =>
            {
                String thisExe = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                System.Reflection.AssemblyName embeddedAssembly = new System.Reflection.AssemblyName(args2.Name);
                String resourceName = thisExe + "." + embeddedAssembly.Name + ".dll";

                using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return System.Reflection.Assembly.Load(assemblyData);
                }
            };


            if (args.Length != 5 )
                ShowHelp();
            else
            {

                for (int i = 0; i < args.Length; i++)
                {
                    if ((args[i] == "-?") || (args[i] == "/?"))
                    {
                        ShowHelp();
                        return;
                    }

                }

                ProcessParameters(args);
                DoTheWork();
            }

        }

        private static void ShowHelp()
        {
            Console.WriteLine("");
            Console.WriteLine("Touch - This application will enable you to change the last modified date");
            Console.WriteLine("and time of a file or a directory.");
            Console.WriteLine("");
            Console.WriteLine(@"Usage: touch -t mm/dd/yyyy hr:mn:ss -f file.txt");
            Console.WriteLine(@"Usage: touch -t mm/dd/yyyy hr:mn:ss -d c:\temp");
            Console.WriteLine("");
            Console.WriteLine("Please ensure the parameters are passed into the program in the same order");
            Console.WriteLine("in the examples above.  Note, if the directory or filename has spaces, please ");
            Console.WriteLine("ensure you wrap the value in double quotes.");
            Console.WriteLine("");
        }

        private static void ProcessParameters(string[] args)
        {

            //Parameters param = new Parameters();
            ProcessFile param = new ProcessFile();
            param.Parse(args);

            dirFilename = param.DirFilename;
            dateFormat = param.DateFormat;
            isDir = param.IsDir;
            isFile = param.IsFile;

        }

        private static void DoTheWork()
        {

            if (isDir == true)
            {
                Directory.SetLastWriteTime(dirFilename, dateFormat);
                Directory.SetCreationTime(dirFilename, dateFormat);
            }
                
            if (isFile == true)
            {
                File.SetLastWriteTime(dirFilename, dateFormat);
                File.SetCreationTime(dirFilename, dateFormat);
            }

        }

    }
}
