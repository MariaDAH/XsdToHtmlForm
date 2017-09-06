using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.MainModule.UI;
using System.Windows.Forms;
using System.IO;

namespace PresentationLayer.MainModule.Test.UITest
{
    /// <summary>
    /// Summary description for FormManagerTest
    /// </summary>
    [TestClass]
    public class FormManagerTest
    {
        public FormManagerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CanGenerateFormFromXsdFile()
        {
           
            //asign
            var formManager = new FormManager(new Panel());

            //action
            formManager.GenerateFormFromXsdFile(@"C:\\Users\\samsung\\Desktop\\XsdFormEditor-master\\XsdFormEditor-master\\XsdToForm.Winforms.Test\\test.xsd", 0);
            

            //assert
        }


        [TestMethod]
        public void CanUpdateFormFromXml()
        {
            //asign
            var formManager = new FormManager(new Panel());

            ////action
            formManager.GenerateFormFromXsdFile(@"C:\\Users\\samsung\\Desktop\\XsdFormEditor-master\\XsdFormEditor-master\\XsdToForm.Winforms.Test\\test.xsd", 0);
            formManager.UpdateFormFromXml("DocumentumArchivageSettings.xml");

            //assert
        }

        [TestMethod]
        public void CanUseSaveFormToXmlFile()
        {
            //asign
            var formManager = new FormManager(new Panel());
            var stream = new MemoryStream();

            //action
            formManager.GenerateFormFromXsdFile(@"C:\\Users\\samsung\\Desktop\\XsdFormEditor-master\\XsdFormEditor-master\\XsdToForm.Winforms.Test\\test.xsd", 0);
            formManager.UpdateFormFromXml("DocumentumArchivageSettings.xml");
            formManager.SaveFormToXmlFile(stream);

            //assert
        }


        [TestMethod]
        public void CanUseIsFormValid()
        {
            //asign
            var formManager = new FormManager(new Panel());

            //action
            formManager.IsFormValid();

            //assert
        }
    }
}
