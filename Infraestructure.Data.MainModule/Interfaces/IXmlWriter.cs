using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Domain.MainModule.XsdModel.Entities;

namespace Infraestructure.Data.MainModule.Interfaces
{
    /// <summary>
    /// Xml writer interface used to write data to xml file.
    /// </summary>  
    public interface IXmlWriter
    {
        /// <summary>
        /// Write data from form to output stream.
        /// </summary>
        /// <param name="stream">Output stream.</param>
        /// <param name="xForm">XForm with data.</param>
        void WriteXFormToXmlFile(Stream stream, XForm xForm);
    }
}
