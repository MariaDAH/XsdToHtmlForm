using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.MainModule.XsdModel.Entities;
using Infraestructure.CrossCutting.Enum;

namespace Infraestructure.Data.MainModule.Interfaces
{
    /// <summary>
    /// Used for Xsd file parsing.
    /// </summary>
    public interface IXsdParser
    {
        /// <summary>
        /// Get XForm from given Xsd file.
        /// </summary>
        /// <param name="fileName">Path to Xsd file.</param>
        /// <returns></returns>
        XForm ParseXsdFile(string fileName, Option option);
    }
}
