using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructure.CrossCutting.Enum
{
    /// <summary>
    /// Information about attribute usage.
    /// </summary>
    [Serializable]
    public enum XAttributeUse : int
    {
        None = 0,
        Optional = 1,
        Prohibited = 2,
        Required = 3,
    }
}
