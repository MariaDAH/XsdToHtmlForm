using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructure.CrossCutting.Enum
{
    /// <summary>
    /// Information about chosen option in choice element 
    /// of the xsd.
    /// </summary>
    [Serializable]
    public enum Option : int
    {
        Estimate = 0,
        Milestones = 1,
        PartQuery = 2,
        EstimateList = 3,
    }
}
