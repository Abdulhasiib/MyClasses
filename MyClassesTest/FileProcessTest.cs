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

        #region Class Initialize and Cleanup
        
        [ClassInitialize]
        public static void ClassInitialization(TestContext tc)
        {
            tc.WriteLine("Inside Class Initilization");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        #endregion

        #region Test Initialize and Cleanup

        [TestInitialize]
        public void TestInitialization()
        {
            if(TestContext.TestName == "FileDoesExist")
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_goodFileName))
                {
                    TestContext.WriteLine("Test File Created at {0}", _goodFileName);
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if(TestContext.TestName == "FileDoesExist")
            {
                File.Delete(_goodFileName);
                TestContext.WriteLine("Deleting Test File {0}", _goodFileName);
            }
        }

        #endregion

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
            
            File.AppendAllText(_goodFileName, "This is a test file");
            TestContext.WriteLine("Updating Test File {0}", _goodFileName);
            
            IsFileExist = fp.FileExists(_goodFileName);
            
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
