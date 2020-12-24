using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileDoesExist()
        {
            FileProcess fp = new FileProcess();

            bool IsFileExist;

            IsFileExist = fp.FileExists(@"C:\UnitTest.txt");

            Assert.IsTrue(IsFileExist);
        }

        [TestMethod]
        public void FileDoesNotExist()
        {
            FileProcess fp = new FileProcess();

            bool IsFileExist;

            IsFileExist = fp.FileExists(@"C:\Test.test");

            Assert.IsFalse(IsFileExist);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty()
        {
            FileProcess fp = new FileProcess();

            bool IsFileExist;

            IsFileExist = fp.FileExists("");
            
        }

        [TestMethod]
        public void FileNameNullOrEmpty_TryCatch()
        {
            FileProcess fp = new FileProcess();

            bool IsFileExist;

            try
            {
                
                IsFileExist = fp.FileExists(string.Empty);
                
            }
            catch(ArgumentNullException)
            {
                return;
            }

            Assert.Fail("FileExist method does not throw Null Argument Exception");

        }
    }
}
