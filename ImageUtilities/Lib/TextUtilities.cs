using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities
{
    class TextUtilities
    {
        public string ConvertToXml(string name)
        {
            string xml = "<p id=\"" + name + "\" size=\"15x15\" n=\"" + TrimName(name) + "\" />";
            return xml;
        }

        string TrimName(string name)
        {
            return "" + name[0] + name[1] + name[2] + name[3];
        }
    }
}
