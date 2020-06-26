using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_case_Nikitenko.Core
{
    interface iParserSettings
    {
        string BaseUrl { get; set; }

        string ProfileUrl { get; set; }

        string Prefix { get; set; }

        string ProfilePrefix { get; set; } 

        int StartPoint { get; set; }

        int EndPoint { get; set; }

        string[] arrOfProfiles { get; set; }
    }
}
