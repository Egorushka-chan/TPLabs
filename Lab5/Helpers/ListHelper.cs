using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

using Lab5.Models;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab5.Helpers
{
    public static class ListHelper
    {
        /// <summary>
        /// Внешний вспомогательный метод
        /// </summary>
        public static HtmlString CreateList(this IHtmlHelper htmlHelper, Table[] tables)
        {
            TagBuilder superDiv = new TagBuilder("div");

            foreach (Table table in tables)
            {
                TagBuilder tableClass = new TagBuilder("div");
                tableClass.AddCssClass("tableClass");

                Fill(tableClass, table);

                superDiv.InnerHtml.AppendHtml(tableClass);
            }

            var writer = new StringWriter();
            superDiv.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }

        private static void Fill(TagBuilder tableClass, Table table)
        {
            TagBuilder label = new TagBuilder("div");
            label.AddCssClass("label");

            var labelStrings = new string[]
            {
                "ID",
                "Наименование",
                "Описание",
                "Тип",
                "Кол-во столбцов",
                "Дата создания"
            };

            foreach (string labelString in labelStrings)
            {
                TagBuilder newElem = new TagBuilder("div");
                newElem.InnerHtml.Append(labelString);
                label.InnerHtml.AppendHtml(newElem);
            }

            TagBuilder value = new TagBuilder("div");
            value.AddCssClass("value");

            PropertyInfo[] info = table.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in info)
            {
                TagBuilder newElem = new TagBuilder("div");
                object? value_obj = propertyInfo.GetValue(table);
                newElem.InnerHtml.Append(": ");
                if (value_obj != null)
                {
                    if(value_obj is DateTime a)
                    {
                        newElem.InnerHtml.Append(a.ToShortDateString());
                    }
                    else if (value_obj is int b)
                    {
                        newElem.InnerHtml.Append(b.ToString());
                    }
                    else if (value_obj is string s)
                    {
                        newElem.InnerHtml.Append(s.ToString());
                    }
                }
                
                value.InnerHtml.AppendHtml(newElem);
            }

            tableClass.InnerHtml.AppendHtml(label);
            tableClass.InnerHtml.AppendHtml(value);
        }
    }
}
