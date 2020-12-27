using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClassesTest
{
    /// <summary>
    /// Summary description for MyClassTestInitialization
    /// </summary>
    [TestClass]
    public class MyClassTestInitialization
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext tc)
        {
            tc.WriteLine("Inside Assembly Initilaize");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }
    }
}
