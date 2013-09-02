using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Resources
{
    public interface IService
    {
        Enum LookupEnum(string name);
        File LookupFile(string name);
        Form LookupForm(string name);
        Grid LookupGrid(string name);
        Link LookupLink(string name);
        Model LookupModel(string name);
        Note LookupNote(string name);
        Operation LookupOperation(string name);
        Page LookupPage(string name);
        Report LookupReport(string name);
        Screen LookupScreen(string name);
    }
}
