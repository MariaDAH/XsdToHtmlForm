using System;
using System.Windows.Forms;
using System.Net;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using PresentationLayer.MainModule.UI;
using Infraestructure.CrossCutting.Enum;
using PresentationLayer.MainModule.Properties;
using Infraestructure.Data.ServiceAgent;

namespace PresentationLayer.MainModule
{
    public partial class MainForm : Form
    {
        private FormManager _formManager;

        public Option _option;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            _formManager = new FormManager(mainPanel);
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = "xsd";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = Resources.MainForm_LoadXSDToolStripMenuItemClick_XSD_Files____xsd____xsd_All_Files__________;
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string sInput = null;
                    sInput = Microsoft.VisualBasic.Interaction.InputBox("Write name of the root element", "Root Element", "Type something");
                    var file = openFileDialog.FileName;
                    _option = new Option();
                    _formManager.GenerateFormFromXsdFileWithInput(file, _option,sInput);
                    loadXMLToolStripMenuItem.Enabled = true;
                    saveXMLAsToolStripMenuItem.Enabled = true;
                    sendRequestToolStripMenuItem.Enabled = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, Resources.MainForm_LoadXSDToolStripMenuItemClick_Error_during_processing_XSD_schema_);
                }
            }
        }

        private void estimateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = "xsd";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = Resources.MainForm_LoadXSDToolStripMenuItemClick_XSD_Files____xsd____xsd_All_Files__________;
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string sInput = null;
                    sInput = Microsoft.VisualBasic.Interaction.InputBox("Write name of the root element", "Root Element", "Type something");
                    var file = openFileDialog.FileName;
                    _option = new Option();
                    _option = Option.Estimate;
                    _formManager.GenerateFormFromXsdFileWithInput(file, _option,sInput);
                    loadXMLToolStripMenuItem.Enabled = true;
                    saveXMLAsToolStripMenuItem.Enabled = true;
                    sendRequestToolStripMenuItem.Enabled = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, Resources.MainForm_LoadXSDToolStripMenuItemClick_Error_during_processing_XSD_schema_);
                }
            }
        }

        private void milestonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = "xsd";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = Resources.MainForm_LoadXSDToolStripMenuItemClick_XSD_Files____xsd____xsd_All_Files__________;
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string sInput = null;
                    sInput = Microsoft.VisualBasic.Interaction.InputBox("Write name of the root element", "Root Element", "Type something");
                    var file = openFileDialog.FileName;
                    _option = new Option();
                    _option = Option.Milestones;
                    _formManager.GenerateFormFromXsdFileWithInput(file, _option,sInput);
                    loadXMLToolStripMenuItem.Enabled = true;
                    saveXMLAsToolStripMenuItem.Enabled = true;
                    sendRequestToolStripMenuItem.Enabled = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, Resources.MainForm_LoadXSDToolStripMenuItemClick_Error_during_processing_XSD_schema_);
                }
            }
        }


        private void partQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = "xsd";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = Resources.MainForm_LoadXSDToolStripMenuItemClick_XSD_Files____xsd____xsd_All_Files__________;
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string sInput = null;
                    sInput = Microsoft.VisualBasic.Interaction.InputBox("Write name of the root element", "Root Element", "Type something");
                    var file = openFileDialog.FileName;
                    _option = new Option();
                    _option = Option.PartQuery;
                    _formManager.GenerateFormFromXsdFileWithInput(file, _option,sInput);
                    loadXMLToolStripMenuItem.Enabled = true;
                    saveXMLAsToolStripMenuItem.Enabled = true;
                    sendRequestToolStripMenuItem.Enabled = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, Resources.MainForm_LoadXSDToolStripMenuItemClick_Error_during_processing_XSD_schema_);
                }
            }
        }



        private void estimateListToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog.DefaultExt = "xsd";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = Resources.MainForm_LoadXSDToolStripMenuItemClick_XSD_Files____xsd____xsd_All_Files__________;
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string sInput = null;
                    sInput = Microsoft.VisualBasic.Interaction.InputBox("Write name of the root element", "Root Element", "Type something");
                    var file = openFileDialog.FileName;
                    _option = new Option();
                    _option = Option.EstimateList;
                    _formManager.GenerateFormFromXsdFileWithInput(file, _option,sInput);
                    loadXMLToolStripMenuItem.Enabled = true;
                    saveXMLAsToolStripMenuItem.Enabled = true;
                    sendRequestToolStripMenuItem.Enabled = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, Resources.MainForm_LoadXSDToolStripMenuItemClick_Error_during_processing_XSD_schema_);
                }
            }
        }

        /// <summary>
        /// Strip menu item for loading XSD file.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event data.</param>
       

        /// <summary>
        /// Stip menu item event click handler to save Xml file with data.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event data.</param>
        private void SaveXmlAsToolStripMenuItemClick(object sender, EventArgs e)
        {
            //if (!_formManager.IsFormValid())
            //{
            //    MessageBox.Show(Resources.MainForm_SaveXmlAsToolStripMenuItemClick_Form_contain_error_,
            //                    Resources.MainForm_SaveXmlAsToolStripMenuItemClick_Error, MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);
            //    return;
            //}

            saveFileDialog.Title = Resources.MainForm_SaveXmlAsToolStripMenuItemClick_Save_file_as___;
            saveFileDialog.Filter = Resources.MainForm_SaveXmlAsToolStripMenuItemClick_XML_files____xml____xml_All_files__________;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var fileStream = saveFileDialog.OpenFile())
                {
                    try
                    {
                        _formManager.SaveFormToXmlFile(fileStream);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, Resources.MainForm_SaveXmlAsToolStripMenuItemClick_Error_during_saving_XML_file_with_data_to_the_file_);
                    }
                }
            }
        }

        /// <summary>
        /// Strip menu item event click handler to load Xml file with data.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event data.</param>
        private void LoadXmlToolStripMenuItemClick(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = "xml";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = Resources.MainForm_LoadXmlToolStripMenuItemClick_XML_Files____xml____xml_All_Files__________;
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    _formManager.UpdateFormFromXml(openFileDialog.FileName);
                    
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, Resources.MainForm_LoadXmlToolStripMenuItemClick_Error_during_loading_XML_file_with_form_data_);
                }
            }
        }

        /// <summary>
        /// Strip menu item click handler for app close.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event data.</param>
        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string fileUploaded = getFileFromFileUploader();

            Infraestructure.Data.ServiceAgent.GtInterfaceWS.GtInterfaceWSSoapClient client = new Infraestructure.Data.ServiceAgent.GtInterfaceWS.GtInterfaceWSSoapClient();

            string response = client.GTIWS(fileUploaded);

            MessageBox.Show(response);

    }
  
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getFileFromFileUploader() 
        {
            XmlDocument doc = new XmlDocument(); 
            openFileDialog.DefaultExt = "xml";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = Resources.MainForm_LoadXmlToolStripMenuItemClick_XML_Files____xml____xml_All_Files__________;
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                    
                    doc.Load(openFileDialog.FileName);
                    return doc.InnerXml;
                   
              
            }
            else 
            {
                return "Problems loading open file dialog.";
            }
        }
    }
}
