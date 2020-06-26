using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_case_Nikitenko.Core
{
    class ParserWorker<T> where T :class
    {
        iParser<T> parser;
        iParserSettings parserSettings;
        HtmlLoader loader;

        bool isActive;

        #region Properties

        public iParser<T> Parser
        {
            get { return parser; }
            set { parser = value; }
        }
        public iParserSettings Settings
        {
            get { return parserSettings; }
            set 
            { 
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        public bool IsActive
        {
            get { return isActive; }
        }

        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object, T> OnNewProfile;
        public event Action<object> OnCompleted;

        public ParserWorker(iParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(iParser<T> parser, iParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public void Start()
        {
            isActive = true;
            Worker();
        }
        public void StartProfiles(string[] str)
        {
            isActive = true;
            WorkerForProfiles(str);
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void Worker()
        {
            for (int i = parserSettings.StartPoint; i < parserSettings.EndPoint; i++)
            {
                if(!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }
                var source =await loader.GetSourceByPageId(i);
                var domParser = new HtmlParser();

                var document =await domParser.ParseDocumentAsync(source);

                var result = parser.ParseList(document);
                
                OnNewData?.Invoke(this, result);
                
            }

            OnCompleted?.Invoke(this);
            isActive = false;

        }

        private async void WorkerForProfiles(string[] str)
        {
            string[] listOfProfiles = str;
            int count = listOfProfiles.Length;
            int i = 0;
            while(i<count)
            {
                if (!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }
                var source = await loader.GetSourceProfileByPageId(listOfProfiles[i]);
                var domParser = new HtmlParser();

                var document = await domParser.ParseDocumentAsync(source);

                var result = parser.Parse(document);
                // Получили парсинг со страниці
                //OnNewData?.Invoke(this, result);
                OnNewProfile?.Invoke(this, result);

                i++;
            }


            OnCompleted?.Invoke(this);
            isActive = false;

        }


    }
}
