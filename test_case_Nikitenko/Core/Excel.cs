using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;


namespace test_case_Nikitenko.Core
{
    class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        public Workbook wb;
        public Worksheet ws;

        public Excel(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
        }

        public Excel()
        {

        }
        public string ReadCell(int i, int j)
        {
            i++;j++;
            if (ws.Cells[i, j].Value2 != null)
            {
                var temp = ws.Cells[i, j].Value2;                
                return temp.ToString();
            }
            else return "";
        }

        public void WriteToCell(int i, int j, string s)
        {
            i++; j++;
            ws.Cells[i, j].Value2 = s;
        }

        public void Save()
        {
            wb.Save();
        }

        public void SaveAs(string path)
        {
            wb.SaveAs(path);
        }

        public void Close()
        {
            wb.Close();
        }

        public void CreateNewFile()
        {
            this.wb = excel.Workbooks.Add();
            this.ws = wb.Worksheets[1];
            Heder();
        }
        public void Heder()
        {           
            ws.Cells[1, 1].Value2 = "Ідентифікаційний код юридичної особи";
            ws.Cells[1, 2].Value2 = "Контролюючий орган";
            ws.Cells[1, 3].Value2 = "Сфера контролю";
            ws.Cells[1, 4].Value2 = "Перевірка №";
            ws.Cells[1, 5].Value2 = "Статус перевірки";
            ws.Cells[1, 6].Value2 = "Ступінь ризику";
            ws.Cells[1, 7].Value2 = "Тип перевірки";
            ws.Cells[1, 8].Value2 = "Санкції (грн.)";
            ws.Cells[1, 9].Value2 = "Дати проведення";
            ws.Cells[1, 10].Value2 = "Посилання на картку з результатами";
        }
    }
}
