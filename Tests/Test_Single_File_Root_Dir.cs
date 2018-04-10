using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.dave.Touch
{
    [TestClass]
    public class Test_Single_File_Root_Dir
    {
        private ProcessFile theParameters = new ProcessFile();

        [TestInitialize]
        public void Initialize()
        {
            List<string> myList = new List<string>();

            myList.Add("-t");
            myList.Add("02/01/2018");
            myList.Add("17:50:10");
            myList.Add("-f");
            myList.Add(@"c:\file.txt");

            theParameters.Parse(myList.ToArray());
        }

        [TestMethod]
        public void Test_Validate_Correct_DateTime_String()
        {
            DateTime theDate = new DateTime(2018, 2, 1, 17, 50, 10);
            Assert.AreEqual(theDate, theParameters.DateFormat);
        }

        [TestMethod]
        public void Test_Validate_Correct_Filename_Is_Returned()
        {
            Assert.AreEqual(@"c:\file.txt", theParameters.DirFilename);
        }

        [TestMethod]
        public void Test_Ensure_Indicator_IsFile_IsTrue()
        {
            Assert.IsTrue(theParameters.IsFile);
        }

        [TestMethod]
        public void Test_Ensure_Indicator_IsDir_IsFalse()
        {
            Assert.IsFalse(theParameters.IsDir);
        }

    }
}
