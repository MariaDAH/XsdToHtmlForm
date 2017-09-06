using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.MainModule.XsdModel.Interfaces;

namespace Domain.MainModule.XsdModel.Entities
{
    public class XForm : IXForm
    {
        /// <summary>
        /// Root container.
        /// </summary>
        public XContainer Root { get; set; }
    }
}
