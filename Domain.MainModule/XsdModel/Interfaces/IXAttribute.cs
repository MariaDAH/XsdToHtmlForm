using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Infraestructure.CrossCutting.Enum;

namespace Domain.MainModule.XsdModel.Interfaces
{
    public interface IXAttribute : INotifyPropertyChanged, IXmlSerializable
    {
        string Name { get; set; }

        XAttributeUse Use { get; set; }

        string GetStringXmlValue();
    }

    public interface IXAttribute<T> : IXAttribute
    {
       
        T Value { get; set; }
    }
}
