using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_case_Nikitenko.Core;
using test_case_Nikitenko.Core.Data;


namespace test_case_Nikitenko
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;
        string pathToExel = "Testing";
        

        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(
                new OpenDataParser()
                );
            
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
            parser.OnNewProfile += Parser_OnNewProfile;

           
            textBox1.Text = pathToExel;
            
            label4.Text =$"Основная ссылка:\r\nhttps://inspections.gov.ua/" +
                $"\r\ninspection/all-unplanned?" +
                $"\r\nplanning_period_id=2";

        }


        public void WriteToCell(int i, int j, string[] str)
        {
            
        }
        private void Parser_OnNewProfile(object arg1, string[] arg2)
        {
            Excel ex = new Excel(pathToExel,1);
            int i = 0, j = 0;
            while (ex.ReadCell(i, j) != "") { i++;}
            for (int index = 0; index < arg2.Length; index++)
                ex.WriteToCell(i, index, arg2[index]);
            listBox1.Items.AddRange(arg2);
            
            
            ex.Save();
            ex.Close();
        }


        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            listBox1.Items.AddRange(arg2);
            
        }

        private void Parser_OnCompleted(object obj)
        {           
            MessageBox.Show("Готово");
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            parser.Settings = new OpenDataSettings((int)numericUpDown1.Value,(int)numericUpDown2.Value);
            parser.Start();

            
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            FocusFile();
        }

        private void FocusFile()

        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", @"Testing.xlsx");
            }
            catch (Exception exc) { }
        }




        private void button3_Click(object sender, EventArgs e)
        {

            Excel ex = new Excel();
            ex.CreateNewFile();
            ex.SaveAs(pathToExel);
            ex.Close();

            List<string> vs = new List<string>();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                vs.Add(listBox1.Items[i].ToString());
            }

            parser.StartProfiles(vs.ToArray());
            


        }
        private void Parser2_OnNewData(object arg1, string[] arg2)
        {
           
            listBox1.Items.AddRange(arg2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pathToExel = textBox1.Text;
            Excel ex = new Excel();
            ex.CreateNewFile();
            ex.SaveAs(pathToExel);             
            ex.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
