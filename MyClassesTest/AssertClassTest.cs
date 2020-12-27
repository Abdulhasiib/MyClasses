using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    /// <summary>
    /// Summary description for AssertClassTest
    /// </summary>
    [TestClass]
    public class AssertClassTest
    {
        [TestMethod]
        public void AreEqualTestCaseSensitive()
        {
            string str1 = "Test";
            string str2 = "Test";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        public void AreEqualCaseInSensitive()
        {
            string str1 = "Test";
            string str2 = "test";

            Assert.AreEqual(str1, str2, true);
        }

        [TestMethod]
        public void AreNotEqual()
        {
            string str1 = "Test";
            string str2 = "abcd";

            Assert.AreNotEqual(str1, str2);
        }

        [TestMethod]
        public void AreSame()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        public void AreNotSame()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }
    }
}
