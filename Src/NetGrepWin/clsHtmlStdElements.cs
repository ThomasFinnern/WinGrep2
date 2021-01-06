using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace HtmlFromToken
{
    public class clsHtmlStdElements
    {
        public static clsHtmlElement HTML() { return new clsHtmlElement("html"); }
        public static clsHtmlElement HEAD() { return new clsHtmlElement("head"); }
        public static clsHtmlElement TITLE() { return new clsHtmlElement("title"); }
        public static clsHtmlElement BODY() { return new clsHtmlElement("body"); }
        public static clsHtmlElement TABLE() { return new clsHtmlElement("table"); }
        public static clsHtmlElement TR() { return new clsHtmlElement("tr"); }
        public static clsHtmlElement TH() { return new clsHtmlElement("th"); }
        public static clsHtmlElement TD() { return new clsHtmlElement("td"); }
        public static clsHtmlElement BR() { return new clsHtmlElement("br"); }
        public static clsHtmlElement HR() { return new clsHtmlElement("hr"); }
        public static clsHtmlElement A() { return new clsHtmlElement("a"); }
        public static clsHtmlElement H1() { return new clsHtmlElement("h1"); }
        public static clsHtmlElement H2() { return new clsHtmlElement("h2"); }
        public static clsHtmlElement H3() { return new clsHtmlElement("h3"); }
        public static clsHtmlElement H4() { return new clsHtmlElement("h4"); }
        public static clsHtmlElement DIV() { return new clsHtmlElement("div"); }
        public static clsHtmlElement SPAN() { return new clsHtmlElement("span"); }
        public static clsHtmlElement STRONG() { return new clsHtmlElement("strong"); }
        public static clsHtmlElement LINK() { return new clsHtmlElement("link"); }

        public static clsHtmlElement HTML(string Content) { return new clsHtmlElement("html", Content); }
        public static clsHtmlElement HEAD(string Content) { return new clsHtmlElement("head", Content); }
        public static clsHtmlElement TITLE(string Content) { return new clsHtmlElement("title", Content); }
        public static clsHtmlElement BODY(string Content) { return new clsHtmlElement("body", Content); }
        public static clsHtmlElement TABLE(string Content) { return new clsHtmlElement("table", Content); }
        public static clsHtmlElement TR(string Content) { return new clsHtmlElement("tr", Content); }
        public static clsHtmlElement TH(string Content) { return new clsHtmlElement("th", Content); }
        public static clsHtmlElement TD(string Content) { return new clsHtmlElement("td", Content); }
        public static clsHtmlElement BR(string Content) { return new clsHtmlElement("br", Content); }
        public static clsHtmlElement HR(string Content) { return new clsHtmlElement("hr", Content); }
        public static clsHtmlElement A(string Content) { return new clsHtmlElement("a", Content); }
        public static clsHtmlElement H1(string Content) { return new clsHtmlElement("h1", Content); }
        public static clsHtmlElement H2(string Content) { return new clsHtmlElement("h2", Content); }
        public static clsHtmlElement H3(string Content) { return new clsHtmlElement("h3", Content); }
        public static clsHtmlElement H4(string Content) { return new clsHtmlElement("h4", Content); }
        public static clsHtmlElement DIV(string Content) { return new clsHtmlElement("div", Content); }
        public static clsHtmlElement STRONG(string Content) { return new clsHtmlElement("strong", Content); }
        public static clsHtmlElement SPAN(string Content) { return new clsHtmlElement("span", Content); }

/*
        public static clsHtmlElement x() { return new clsHtmlElement("x"); }
        public static clsHtmlElement x() { return new clsHtmlElement("x"); }
        public static clsHtmlElement x() { return new clsHtmlElement("x"); }
        public static clsHtmlElement x() { return new clsHtmlElement("x"); }
        public static clsHtmlElement x() { return new clsHtmlElement("x"); }
        public static clsHtmlElement x() { return new clsHtmlElement("x"); }
        public static clsHtmlElement x() { return new clsHtmlElement("x"); }
        public static clsHtmlElement x() { return new clsHtmlElement("x"); }
        public static clsHtmlElement x() { return new clsHtmlElement("x"); }
        public static clsHtmlElement x() { return new clsHtmlElement("x"); }
        public static clsHtmlElement x() { return new clsHtmlElement("x"); }
*/
    }
}
