using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.dave.Touch
{
    [TestClass]
    public class Test_Single_Dir
    {
        private ProcessFile theParameters = new ProcessFile();

        [TestInitialize]
        public void Initialize()
        {
            List<string> myList = new List<string>();

            myList.Add("-t");
            myList.Add("12/14/2001");
            myList.Add("14:00:00");
            myList.Add("-d");
            myList.Add(@"c:\mydocs");

            theParameters.Parse(myList.ToArray());
        }

        [TestMethod]
        public void Test_Validate_Correct_DateTime_String()
        {
            DateTime theDate = new DateTime(2001, 12, 14, 14, 00, 00);
            Assert.AreEqual(theDate, theParameters.DateFormat);
        }

        [TestMethod]
        public void Test_Validate_Correct_Dirname_Is_Returned()
        {
            Assert.AreEqual(@"c:\mydocs", theParameters.DirFilename);
        }

        [TestMethod]
        public void Test_Ensure_Indicator_IsFile_IsFalse()
        {
            Assert.IsFalse(theParameters.IsFile);
        }

        [TestMethod]
        public void Test_Ensure_Indicator_IsDir_IsTrue()
        {
            Assert.IsTrue(theParameters.IsDir);
        }

    }
}
