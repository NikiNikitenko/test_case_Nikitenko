using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_case_Nikitenko.Core.Data
{
    class OpenDataParser : iParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var list2 = new List<string>();
            
            var items = document.QuerySelectorAll("table").Where(item => item.ClassName != null && item.ClassName.Contains("inspection_table"));
            var doc = document.QuerySelectorAll("table").Where(item => item.ClassName != null && item.ClassName.Contains("vertical_table table table-bordered table-striped"));
            var title = document.QuerySelectorAll("h1").Where(item => item.ClassName != null && item.ClassName.Contains("page_title"));

            foreach (var item in items)
            {
                list2.Add(item.OuterHtml);                
            }
            string[] inspection_table = list2.ToArray();
            
            
            list2.Clear();


            foreach (var item in doc)
            {
                list2.Add(item.OuterHtml);
            }
            string[] vertical_table = list2.ToArray();

            
            list2.Clear();


            foreach (var item in title)
            {
                list2.Add(item.OuterHtml);
            }
            string[] page_title = list2.ToArray();

            //1
            list.Add(Inn(vertical_table[0]));            
            //2
            list.Add(SupervisoryAuthority(inspection_table[0]));
            //3
            list.Add(ScopeOfControl(inspection_table[0]));
            //4
            list.Add(CheckN(page_title[0]));
            //5
            list.Add(VerificationStatus(inspection_table[0]));
            //6
            list.Add(DegreeOfRisk(vertical_table[0]));
            //7
            list.Add(TypeChecking(inspection_table[0]));
            //8
            list.Add(Sanctions(inspection_table[0]));            
            //9
            list.Add(Dates(inspection_table[0]));
            //10
            list.Add(Link(page_title[0])) ;


            return list.ToArray();
        }
        public string CutOut(string source,string str,int i)
        {
            string outputString = source;
            int index = outputString.IndexOf(str);
            outputString = outputString.Remove(0, index + str.Length);
            for(int j=0;j<i;j++)
            {
                index = outputString.IndexOf(">");
                outputString = outputString.Remove(0, index + 1);
            }
            index = outputString.IndexOf("<");
            outputString = outputString.Remove(index);
            return outputString;
        }
        public string Inn(string source)
        {
            
            string outputString = source;
            string str = "дентифікаційний";

            return CutOut(source, str, 2);
           
        }
        //1. Ідентифікаційний код юридичної особи
        public string SupervisoryAuthority(string source)
        {
            string outputString = source;            
            string str = "Контролюючий орган";
                       
            return CutOut(source,str,3);
        }
        //2. Контролюючий орган
        public string ScopeOfControl(string source)
        {
           
            string outputString = source;
            string str = "Сфера контролю";
            return CutOut(source, str, 2);

        }
        //3. Сфера контролю
        public string CheckN(string source)
        {
            string outputString = source;
            string str = "Перевірка";

            int index = outputString.IndexOf(str);
            outputString = outputString.Remove(0, index);

            index = outputString.IndexOf("<");
            outputString = outputString.Remove(index);

            return outputString;

        }
        //4. Перевірка №
        public string VerificationStatus(string source)
        {
            string outputString = source;
            string str = "Статус";
            return CutOut(source, str, 2);


        }
        //5. Статус перевірки
        public string DegreeOfRisk(string source)
        {
            
            string outputString = source;
            string str = "Ступінь ризику";

            return CutOut(source, str, 2);

        }
        //6. Ступінь ризику
        public string TypeChecking(string source)
        {
            
            string outputString = source;
            string str = "Тип перевірки";
            return CutOut(source, str, 2);

        }
        //7. Тип перевірки
        public string Sanctions(string source)
        {
            
            string outputString = source;
            string str = "Заходи впливу та санкції";
            return CutOut(source, str, 2);

        }
        //8. Санкції(грн.)
        public string Dates(string source)
        {            
            string outputString = source;
            string str = "Дати";
            return CutOut(source, str, 2);

        }
        //9. Дати проведення
        public string Link(string source)
        {
            string ProfileUrl = "https://inspections.gov.ua/inspection/view?id=";
            source = CheckN(source);
            int index = source.IndexOf("№");
            source = source.Remove(0, index+1);
            return ProfileUrl+source;

        }





        public string[] ParseList(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("table_action_btn icon-details"));

            foreach (var item in items)
            {

                list.Add(GetHref(item.OuterHtml));
            }
            return list.ToArray();
        }
        public string GetHref(string inputString)
        {
            string outputString = inputString;
            int index = outputString.IndexOf("/inspection/view?id=");
            string href = "/inspection/view?id=";
            outputString = outputString.Remove(0, index + href.Length);
            index = outputString.IndexOf('"');
            outputString = outputString.Remove(index);
            return outputString;
        }
    }

    
}
