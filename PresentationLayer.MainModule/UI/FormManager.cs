using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Domain.MainModule.XsdModel.Entities;
using Infraestructure.CrossCutting.Enum;
using System.IO;
using Infraestructure.Data.MainModule.Entities;

namespace PresentationLayer.MainModule.UI
{
    /// <summary>
    /// Managing form UI
    /// </summary>
    public class FormManager
    {
        /// <summary>
        /// UI Panel to render controls.
        /// </summary>
        private readonly Panel _mainPanel;

        private readonly ControlManager _controlManager;

        /// <summary>
        /// XForm used for form description.
        /// </summary>
        private XForm _xForm;

        /// <summary>
        /// XForm used to store form data.
        /// </summary>
        private XForm _xFormData;

        public FormManager(Panel mainPanel)
        {
            _mainPanel = mainPanel;
            _controlManager = new ControlManager();

        }


        /// <summary>
        /// Creates XForm from given Xsd file
        /// </summary>
        /// <param name="file">Path to Xsd file.</param>
        public void GenerateFormFromXsdFile(string file, Option option)
        {
            _mainPanel.Controls.Clear();
            _xForm = null;

            _controlManager.Clear();//prepare for new rendering
            var xsdParser = new XsdParser();
            xsdParser.setParseOption(option);
            _xForm = xsdParser.ParseXsdFile(file, option);
            _xFormData = xsdParser.ParseXsdFile(file, option);
            var generateGuiGetGroupBox = _controlManager.GetGroupBoxGui(_xForm.Root, _xFormData.Root);

            _mainPanel.Controls.Add(generateGuiGetGroupBox);
        }

        /// <summary>
        /// Creates XForm from given Xsd file
        /// </summary>
        /// <param name="file">Path to Xsd file.</param>
        public void GenerateFormFromXsdFileWithInput(string file, Option option, string input)
        {
            _mainPanel.Controls.Clear();
            _xForm = null;

            _controlManager.Clear();//prepare for new rendering
            var xsdParser = new XsdParser();
            xsdParser.setParseOption(option);
            xsdParser.rootElementInput = input;
            _xForm = xsdParser.ParseXsdFile(file, option);
            _xFormData = xsdParser.ParseXsdFile(file, option);
            var generateGuiGetGroupBox = _controlManager.GetGroupBoxGui(_xForm.Root, _xFormData.Root);

            _mainPanel.Controls.Add(generateGuiGetGroupBox);
        }

        /// <summary>
        /// Updates values in XForm from given Xml file.
        /// </summary>
        /// <param name="fileName">Path to Xml file contains data.</param>
        public void UpdateFormFromXml(string fileName)
        {
            var xmlParser = new XmlParser();
            var filledXForm = xmlParser.GetFilledXForm(fileName, _xForm);

            if (filledXForm != null)
            {
                _xFormData = filledXForm;
            }

            _controlManager.UpdateVisibleContainers(_xFormData.Root);
            _controlManager.UpdateBindingForVisibleContainer(_xFormData.Root);
        }

        /// <summary>
        /// Save XForm to Xml file.
        /// </summary>
        /// <param name="stream">Output stream.</param>
        public void SaveFormToXmlFile(Stream stream)
        {
            _controlManager.Save();

            var xmlWriter = new XmlWriter();
            xmlWriter.WriteXFormToXmlFile(stream, _xFormData);

        }

        /// <summary>
        /// Check if form is valid usually before saving Xml data.
        /// </summary>
        /// <returns>True if form is valid, false if not.</returns>
        public bool IsFormValid()
        {
            return _controlManager.AreControlsValid();
        }
    }
}
