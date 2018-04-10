using System;
using System.IO;

namespace com.dave.Touch
{
    /// <summary>
    /// This class will parse the parameters given and will parse out the filename, desired date and identify if the
    /// given argument is a file or directory.
    /// </summary>
    public class ProcessFile
    {

        private bool isDir = false;
        private bool isFile = false;
        private DateTime dateFormat = DateTime.MinValue;
        private string dirFilename = "";

        /// <summary>
        /// Parses the arguments.
        /// </summary>
        /// <param name="args">A string array of the arguments.</param>
        public void Parse(string[] args)
        {

            if (args is null)
                throw new ArgumentNullException("args", "Argument(s) cannot be null.");
            if (args.Length != 5)
                throw new ArgumentException("ERROR - There must be 5 arguments passed into program.", "args");

            if (args[0] != "-t")
                throw new ArgumentException("ERROR! - The -t parameter was not provided.  Please see help screen.");
            if ((args[3] != "-d") && (args[3] != "-f"))
                throw new ArgumentException("ERROR! - The -d or -f parameter was not provided.  Please see help screen.");

            if (DateTime.TryParse(string.Concat(args[1], " ", args[2]), out dateFormat) == false)
                throw new ArgumentException("ERROR - The value in the -t parameter is not a valid date.");
            if ((args[3] != "-d") && (args[3] != "-f"))
                throw new ArgumentException("ERROR - Neither the -d or -f parameters were provided.  Please see help screen.");

            if (args[3] == "-d")
                isDir = true;
            else if (args[3] == "-f")
                isFile = true;

            dirFilename = args[4];

        }

        /// <summary>
        /// Returns true if the string provided is a directory. Otherwise, false is returned.
        /// </summary>
        public bool IsDir
        {
            get { return isDir; }
        }

        /// <summary>
        /// Returns true if the string provided is a filename.  Otherwise, false is returned.
        /// </summary>
        public bool IsFile
        {
            get { return isFile; }
        }

        /// <summary>
        /// Returns a DateTime representing the date and time to set the file/directory to.
        /// </summary>
        public DateTime DateFormat
        {
            get { return dateFormat; }
        }

        /// <summary>
        /// Returns the fully qualified filename or directory name that the user passed in.
        /// </summary>
        public string DirFilename
        {
            get { return dirFilename; }
        }
    }
}
