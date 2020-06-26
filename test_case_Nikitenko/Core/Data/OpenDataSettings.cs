
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace test_case_Nikitenko.Core.Data
{
    class OpenDataSettings : iParserSettings
    {
        public OpenDataSettings(int start, int end) 
        {
            StartPoint = start;
            EndPoint = end;        
        }

        public OpenDataSettings(string[] str)
        {
            arrOfProfiles = str;
        }
        public string BaseUrl { get; set; } = "https://inspections.gov.ua/inspection/all-unplanned?planning_period_id=2";

        public string ProfileUrl { get; set; } = "https://inspections.gov.ua/inspection/view?id=";

        public string Prefix { get; set; } = "&page={CurrentId}";

        public string ProfilePrefix { get; set; } = "{CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }

        public string[] arrOfProfiles { get; set; }
    }
}
