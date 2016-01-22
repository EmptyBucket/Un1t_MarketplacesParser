using System;
using System.Collections.Generic;
using System.Linq;
using Sprache;

namespace ParseZakupki.Parser
{
    public class ZakupkiParser
    {
        public IReadOnlyCollection<PurchaseInformation> Parse(string text)
        {
            var costParser =
                from openDataDesc in Sprache.Parse.String("<dd>").Token()
                from openStrong in Sprache.Parse.String("<strong>").Token()
                from cost in Sprache.Parse.AnyChar.Except(Sprache.Parse.String("<span>")).Many().Token().Text()
                from openSpan in Sprache.Parse.String("<span>").Token()
                from dec in Sprache.Parse.AnyChar.Except(Sprache.Parse.String("</span>")).Many().Token().Text()
                from closeSpan in Sprache.Parse.String("</span>").Token()
                from closeStrong in Sprache.Parse.String("</strong>").Token()
                from openCloseBR in Sprache.Parse.String("<br/>").Token()
                from openCurrency in Sprache.Parse.String("<span class=\"currency\">").Token()
                from currency in Sprache.Parse.AnyChar.Except(Sprache.Parse.String("</span>")).Many().Token().Text()
                from closeCurrence in Sprache.Parse.String("</span>").Token()
                from closeDataDesc in Sprache.Parse.String("</dd>")
                select double.Parse(string.Join("", cost.Split(new string[] { "&nbsp;" }, StringSplitOptions.RemoveEmptyEntries)) + dec);
            var createdParser =
                from openLi in Sprache.Parse.String("<li>").Token()
                from label in Sprache.Parse.String("<label>Размещено:</label>").Token()
                from date in Sprache.Parse.AnyChar.Except(Sprache.Parse.String("</li>")).Many().Text()
                from closeLi in Sprache.Parse.String("</li>")
                select DateTime.Parse(date);
            var updatedParser =
                from openLi in Sprache.Parse.String("<li>").Token()
                from label in Sprache.Parse.String("<label>Обновлено:</label>").Token()
                from date in Sprache.Parse.AnyChar.Except(Sprache.Parse.String("</li>")).Many().Text()
                from closeLi in Sprache.Parse.String("</li>")
                select DateTime.Parse(date);
            var linkParser =
                from openTag in Sprache.Parse.String("<a").Token()
                from trash1 in Sprache.Parse.AnyChar.Except(Sprache.Parse.String("href=\"")).Many()
                from href in Sprache.Parse.String("href=\"").Token()
                from link in Sprache.Parse.AnyChar.Except(Sprache.Parse.Char('"')).Many().Text()
                from endLink in Sprache.Parse.Char('"').Token()
                from trash2 in Sprache.Parse.AnyChar.Except(Sprache.Parse.Char('>')).Many()
                from endTag in Sprache.Parse.Char('>').Token()
                from name in Sprache.Parse.AnyChar.Except(Sprache.Parse.String("</a>")).Many().Text()
                from closeTag in Sprache.Parse.String("</a>").Token()
                select new { Link = link, Name = name };
            var customerParser =
                from openDDNameOrgenization in Sprache.Parse.String("<dd class=\"nameOrganization\">").Token()
                from link in linkParser
                from closeDDNameOrganization in Sprache.Parse.String("</dd>").Token()
                from openDDDesc in Sprache.Parse.String("<dd>").Token()
                from desc in Sprache.Parse.AnyChar.Except(Sprache.Parse.String("</dd>")).Many().Text()
                from closeDDDesc in Sprache.Parse.String("</dd>").Token()
                select new { Link = link.Link, Name = link.Name, Desc = System.Web.HttpUtility.HtmlDecode(desc) };
            var openBlockParser =
                from openBlock in Sprache.Parse.String("<div class=\"registerBox registerBoxBank margBtm20\">").Token().Text()
                select openBlock;
            var dirtyParser =
                from trash1 in Sprache.Parse.AnyChar.Except(costParser).Many()
                from cost in costParser
                from trash2 in Sprache.Parse.AnyChar.Except(customerParser).Many()
                from customer in customerParser
                from trash3 in Sprache.Parse.AnyChar.Except(createdParser).Many()
                from created in createdParser
                from trash4 in Sprache.Parse.AnyChar.Except(updatedParser).Many()
                from updated in updatedParser
                select new PurchaseInformation()
                {
                    Cost = cost.ToString(),
                    Created = created.ToString(),
                    Customer = $"{customer.Name} - {customer.Link}",
                    Description = customer.Desc,
                    Updated = updated.ToString()
                };

            var result = dirtyParser.Many().Parse(text).ToArray();
            return result;
        }
    }
}
