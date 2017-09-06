using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Domain.MainModule.XsdModel.Interfaces
{
    
    public interface IXElement : IXmlSerializable
    {
        /// <summary>
        /// Element name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Element value.
        /// </summary>
        string Value { get; set; }
    }
}
