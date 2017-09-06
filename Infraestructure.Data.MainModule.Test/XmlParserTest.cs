using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infraestructure.Data.MainModule.Entities;
using Infraestructure.CrossCutting.Enum;
using System.Windows.Forms;
using System.IO;

namespace Infraestructure.Data.MainModule.Test
{
    /// <summary>
    /// Descripción resumida de UnitTest1
    /// </summary>
    [TestClass]
    public class XmlParserTest
    {
        public XmlParserTest()
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
        public void CanParseXFormFromXmlFileMilestonesXml()
        {

            Option option = new Option();
            option = Option.Milestones;
            //asign 
            var xmlParser = new XmlParser();
            var xsdParser = new XsdParser();
            xsdParser.rootElementInput = "request";
            var xForm = xsdParser.ParseXsdFile(@"C:\Documents and Settings\bdesarrollo\Escritorio\IWClientForm\Infraestructure.CrossCutting\Templates\request.xsd",option);

            //action
            var xFormFromXml = xmlParser.GetFilledXForm(@"C:\Documents and Settings\bdesarrollo\Escritorio\IWClientForm\Infraestructure.CrossCutting\Templates\milestonesTest.xml", xForm);

            //assert
            Assert.IsNotNull(xFormFromXml);
        }
    }
}
