using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infraestructure.Data.MainModule.Entities;
using Domain.MainModule.XsdModel.Entities;
using Domain.MainModule.XsdModel;
using System.IO;

namespace Infraestructure.Data.MainModule.Test
{
    /// <summary>
    /// Descripción resumida de XmlWriterTest
    /// </summary>
    [TestClass]
    public class XmlWriterTest
    {
        public XmlWriterTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la ejecución de pruebas actual.
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

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CanWriteXFormFromXmlFileDocumentumArchivageSettings()
        {
            //asign
            var xmlWriter = new XmlWriter();
            var xForm = new XForm();

            xForm.Root = new XContainer { Name = "BaseContainer" };

            var xAttribute = new XAttribute<string>(string.Empty) { Name = "StringAttribute", Value = "StringAttribute" };
            var xContainer = new XContainer { Name = "ChildContainer", Value = "ChildContainerValue", ParentContainer = xForm.Root };
            xContainer.Attributes.Add(xAttribute);
            var xElement = new XElement { Name = "Element", Value = "ElementValue" };
            xContainer.Elements.Add(xElement);

            xForm.Root.Attributes.Add(xAttribute);
            xForm.Root.Containers.Add(xContainer);
            xForm.Root.Elements.Add(xElement);

            var fileStream = new FileStream(@"testXml.txt", FileMode.OpenOrCreate);

            //action
            xmlWriter.WriteXFormToXmlFile(fileStream, xForm);

            //assert
            var xml = File.ReadAllText(@"testXml.txt");

            var resultXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
"<BaseContainer xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" StringAttribute=\"StringAttribute\">" +
"\r\n  <Element>ElementValue</Element>" +
"\r\n  <ChildContainer StringAttribute=\"StringAttribute\">ChildContainerValue" +
"<Element>ElementValue</Element>" +
"</ChildContainer>" +
"\r\n</BaseContainer>";

            Assert.AreEqual(xml, resultXml);
        }
    }
}
