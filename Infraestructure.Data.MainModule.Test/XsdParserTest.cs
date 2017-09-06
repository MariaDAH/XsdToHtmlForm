using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infraestructure.Data.MainModule.Entities;
using Domain.MainModule.XsdModel;
using Domain.MainModule.XsdModel.Entities;
using System.IO;
using System.Windows.Forms;

namespace Infraestructure.Data.MainModule.Test
{
    /// <summary>
    /// Descripción resumida de XsdParserTest
    /// </summary>
    [TestClass]
    public class XsdParserTest
    {
        public XsdParserTest()
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
        public void CanParseXFormFromXsdFileDocumentumArchivageSettingsXsd()
        {
            //asign
            var xsdParser = new XsdParser();
            xsdParser.rootElementInput = "DocumentumArchivageSettings";

            //action
            string path = @"C:\Documents and Settings\bdesarrollo\Escritorio\IWClientForm\Infraestructure.CrossCutting\Templates\DocumentumArchivageSettings.xsd"; 
            var xForm = xsdParser.ParseXsdFile(path, 0);

            //assert
            Assert.IsNotNull(xForm);
        }

        [TestMethod]
        public void CanParseXFormFromXsdFileMoveCopySettingsXsd()
        {
            //asign
            var xsdParser = new XsdParser();
            xsdParser.rootElementInput = "MoveCopySettings";

            //action
            var xForm = xsdParser.ParseXsdFile(@"C:/Documents and Settings/bdesarrollo/Escritorio/IWClientForm/Infraestructure.CrossCutting/Templates/MoveCopySettings.xsd", 0);

            //assert
            Assert.IsNotNull(xForm);
        }
    }
}
