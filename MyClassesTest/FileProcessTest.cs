using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.IO;
using System.Configuration;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        public const string badFileName = @"C:\Test.test";
        string _goodFileName;

        public void SetGoodFileName()
        {
            _goodFileName = ConfigurationManager.AppSettings["goodFileName"];

            if (_goodFileName.Contains("[AppPath]"))
            {
                _goodFileName = _goodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void FileDoesExist()
        {
            FileProcess fp = new FileProcess();

            bool IsFileExist;

            SetGoodFileName();
            TestContext.WriteLine("Creating Test File..");

            File.AppendAllText(_goodFileName, "This is a test file");
            TestContext.WriteLine("Updating Test File..");
            
            IsFileExist = fp.FileExists(_goodFileName);

            File.Delete(_goodFileName);
            TestContext.WriteLine("Deleting Test File..");

            Assert.IsTrue(IsFileExist);
        }

        [TestMethod]
        public void FileDoesNotExist()
        {
            FileProcess fp = new FileProcess();

            bool IsFileExist;

            IsFileExist = fp.FileExists(badFileName);

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
