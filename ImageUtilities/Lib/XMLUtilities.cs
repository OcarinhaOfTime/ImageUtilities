using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities
{
    class XMLUtilities
    {
        public string GeneratePattern(string id, string size, string name)
        {
            string xml = "<p id=\"" + id + "\" size=\""+size+"\" n=\"" + name + "\" />";
            return xml;
        }
    }
}
