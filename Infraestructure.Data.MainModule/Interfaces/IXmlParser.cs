using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.MainModule.XsdModel.Entities;

namespace Infraestructure.Data.MainModule.Interfaces
{
    /// <summary>
    /// Xml file parser interface.
    /// </summary>
    public interface IXmlParser
    {
        /// <summary>
        /// Fills given XForm structure with data form given Xml file.
        /// </summary>
        /// <param name="xmlFileName">Path to Xml file contains data.</param>
        /// <param name="xsdForm">XForm to be filled with data from Xml file.</param>
        /// <returns>Filled XForm.</returns>
        XForm GetFilledXForm(string xmlFileName, XForm xsdForm);
    }
}
