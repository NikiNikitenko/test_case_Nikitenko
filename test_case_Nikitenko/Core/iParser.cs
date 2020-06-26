using AngleSharp.Html.Dom;

namespace test_case_Nikitenko.Core
{
    interface iParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
        T ParseList(IHtmlDocument document);
    }
   
}
