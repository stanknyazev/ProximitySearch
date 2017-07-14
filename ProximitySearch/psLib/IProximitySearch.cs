using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psLib
{
    public interface IProximitySearch
    {
        int CountInstances(string keyword, string keywordTwo, int proximity);
        void SetSearcheableText(string text);
    }
}
