using System.Linq;
using Engine;
using Engine.Kernel;
using Engine.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Ninject;

namespace AutocompleteTest
{
    
    
    /// <summary>
    ///This is a test class for PrefixStorageTest and is intended
    ///to contain all PrefixStorageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrefixStorageTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            IPrefixStorage target = InjectContainer.Instance.Get<IPrefixStorage>();
            target.Add("example 0");
            Assert.AreEqual(target.Lookup("").Single(), "example");

            target.Add("examination 1");
            Assert.AreEqual(target.Lookup("").Last(), "example");
            Assert.AreEqual(target.Lookup("exam").First(), "examination");

        }

        /// <summary>
        ///A test for Lookup
        ///</summary>
        [TestMethod()]
        public void LookupTest()
        {
            IPrefixStorage target = InjectContainer.Instance.Get<IPrefixStorage>();
            target.Add("example 0");
            target.Add("exist 3");
            target.Add("examination 1");
            target.Add("exercise 2");
            target.Add("ecology 5");
            target.Add("tetris 7");

            string[] actual = target.Lookup("ex");
            Assert.IsTrue(actual.SequenceEqual(new[] { "exist", "exercise", "examination", "example" }));
        }
    }
}
