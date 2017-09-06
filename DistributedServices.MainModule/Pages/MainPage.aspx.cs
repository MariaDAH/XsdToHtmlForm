using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Xsl;
using System.Xml;
using System.Configuration;
using System.IO;
using System.Web.Services.Description;
using DistributedServices.MainModule.HTTP.Session;
using Domain.MainModule.XsdModel;
using System.Xml.Serialization;
using System.Text;
using Domain.MainModule.XsdModel.Entities;
using Infraestructure.Data.MainModule.Entities;
using Infraestructure.CrossCutting.Enum;


namespace DistributedServices.MainModule
{
    public partial class MainPage : SpecificCulturePage
    {

        /// <summary>
        /// XForm used for form description.
        /// </summary>
        private XForm _xForm;

        /// <summary>
        /// XForm used to store form data.
        /// </summary>
        //private XForm _xFormData;


        //private FormManager _formManager;

        /// <summary>
        /// Parent XContainer;
        /// </summary>
        //private XContainer root;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                }
                catch (Exception exception)
                {
                    throw exception;
                }

            }
        }

       
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }





        protected void btnSendRequest_Click(object sender, EventArgs e)
        {

        }

        protected void btnExportXml_Click(object sender, EventArgs e)
        {

        }

        protected void btnXmlSource_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnRequestForm_Click(object sender, ImageClickEventArgs e)
        {

        }


        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/Templates") + "\\" + filename);
                    var file= Server.MapPath("~/Templates")+"\\" + filename;
                    this.PnlUpload.Visible = false;
                    this.PnlFormUpload.Visible = true;
                    //this.PnlFormTable.Visible = false;
                    this.PnlFormUpload.Controls.Add(LnkEstimate);
                    this.PnlFormUpload.Controls.Add(LnkMilestones);
                    this.PnlFormUpload.Controls.Add(LnkEstimateList);
                    this.PnlFormUpload.Controls.Add(LnkPartQuery);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void GenerateFormFromXsdFile(string file,Option option)
        {

            var xsdParser = new XsdParser();
            try
            {
                _xForm = xsdParser.ParseXsdFile(file, option);
                GenerateXmlFile(_xForm);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected void MenuHeader_MenuItemClick(object sender, MenuEventArgs e)
        {
            var choice = e.Item.Value;
            switch (choice)
            {
                case "LoadXml":
                    PnlUpload.Visible = true;
                    break;
                case "LoadXsd":
                    PnlUpload.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// This method converts a GtResult object into a xml UTF-8 format.
        /// It was necessary converting to this format because it was 
        /// encountered an issue when trying to display an XML file on 
        /// the ticker.
        /// </summary>
        /// <param name="instance">Object to serialize</param>
        /// <returns>An string with the object serialized.</returns>
        public string Serialize(Object instance)
        {
            #region Preconditions

            if (instance == null)
                throw new ArgumentNullException("instance");

            #endregion


            XmlSerializer serializer = new XmlSerializer(instance.GetType());

            // Create a MemoryStream here, we are just working
            // exclusively in memory
            Stream stream = new MemoryStream();

            System.Xml.XmlWriter xtWriter = System.Xml.XmlWriter.Create(stream);

            serializer.Serialize(xtWriter, instance);

            xtWriter.Flush();

            // Go back to the beginning of the Stream to read its contents
            stream.Seek(0, SeekOrigin.Begin);

            // Read back the contents of the stream and supply the encoding

            StreamReader reader = new StreamReader(stream, Encoding.UTF8);

            string result = reader.ReadToEnd();

            return result;
        }

        protected void GenerateXmlFile(XForm form) 
        {
            string path = @"C:\resultados\form.xml";
            var serializado = Serialize(form);
            StreamWriter file = new StreamWriter(path);
            file.Write(serializado);
            file.Close();

        }

      
    }
}