using Engine;
using Engine.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace AutocompleteTest
{
    
    
    /// <summary>
    ///This is a test class for PrefixReaderTest and is intended
    ///to contain all PrefixReaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrefixReaderTest
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
        ///A test for Process
        ///</summary>
        [TestMethod()]
        public void ProcessTest() {
            
            #region input and output

            String input =
                @"5
kare 10
kanojo 20
karetachi 1
korosu 7
sakura 3
3
k
ka
kar";
            String output =
                @"kanojo
kare
korosu
karetachi

kanojo
kare
karetachi

kare
karetachi";

            #endregion

            PrefixReader.Process(input.ToStream(), output.ToStream());
        }
    }
}
