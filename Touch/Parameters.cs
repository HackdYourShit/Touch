//using System;
//using System.IO;

//namespace com.dave.Touch
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class Parameters
//    {

//        private bool isDir = false;
//        private bool isFile = false;
//        private DateTime dateFormat = DateTime.MinValue;
//        private string dirFilename = "";

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="args"></param>
//        public void Process(string[] args)
//        {

//            if (args[0] != "-t")
//                throw new ArgumentException("ERROR! - The -t parameter was not provided.  Please see help screen.");
//            if ((args[3] != "-d") && (args[3] != "-f"))
//                throw new ArgumentException("ERROR! - The -d or -f parameter was not provided.  Please see help screen.");

//            if (DateTime.TryParse(string.Concat(args[1], " ", args[2]), out dateFormat) == false)
//                throw new ArgumentException("ERROR - The value in the -t parameter is not a valid date.");
//            if ((args[3] != "-d") && (args[3] != "-f"))
//                throw new ArgumentException("ERROR - Neither the -d or -f parameters were provided.  Please see help screen.");

//            if (args[3] == "-d")
//                isDir = true;
//            else if (args[3] == "-f")
//                isFile = true;

//            dirFilename = args[4];
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public bool IsDir
//        {
//            get { return isDir; }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public bool IsFile
//        {
//            get { return isFile; }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public DateTime DateFormat
//        {
//            get { return dateFormat; }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string DirFilename
//        {
//            get { return dirFilename; }
//        }
//    }
//}
