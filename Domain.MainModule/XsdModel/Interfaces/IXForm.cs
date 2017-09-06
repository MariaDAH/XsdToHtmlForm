using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.MainModule.XsdModel.Interfaces
{
    public interface IXForm
    {
        /// <summary>
        /// Root container.
        /// </summary>
        XContainer Root { get; set; }
    }
}
