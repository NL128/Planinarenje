using Planinarenje.Models.ClientInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planinarenje.Models.Factory
{
     public interface IFactoryGuide
    {
        IGuideUser Create();
    }
}
