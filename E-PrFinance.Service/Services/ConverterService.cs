using System.Globalization;

namespace E_PrFinance.Service.Services;

public class ConverterService
{
    public static string[] GetCurrencyTags()
    {

        return new string[] {"eur", "usd", "jpy", "bgn", "czk", "dkk", "gbp", "huf", "ltl", "lvl"
            , "pln", "ron", "sek", "chf", "nok", "hrk", "rub", "try", "aud", "brl", "cad", "cny", "hkd", "idr", "ils"
            , "inr", "krw", "mxn", "myr", "nzd", "php", "sgd", "zar"};
    }
    public static decimal GetCurrencyRateInEuro(string currency)
    {
        if (currency.ToLower() == "")
            throw new ArgumentException("Invalid Argument! currency parameter cannot be empty!");
        if (currency.ToLower() == "eur")
            throw new ArgumentException("Invalid Argument! Cannot get exchange rate from EURO to EURO");

        try
        {
            string rssUrl = string.Concat("http://www.ecb.int/rss/fxref-", currency.ToLower() + ".html");

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(rssUrl);

            System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("rdf", "http://purl.org/rss/1.0/");
            nsmgr.AddNamespace("cb", "http://www.cbwiki.net/wiki/index.php/Specification_1.1");

            System.Xml.XmlNodeList nodeList = doc.SelectNodes("//rdf:item", nsmgr);
            foreach (System.Xml.XmlNode node in nodeList)
            {
                CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                ci.NumberFormat.CurrencyDecimalSeparator = ".";

                try
                {
                    decimal exchangeRate = decimal.Parse(
                        node.SelectSingleNode("//cb:statistics//cb:exchangeRate//cb:value", nsmgr).InnerText,
                        NumberStyles.Any,
                        ci);

                    return exchangeRate;
                }
                catch { }
            }
            return 0;
        }
        catch
        {
            return 0;
        }
    }
    public static decimal GetExchangeRate(string from, string to, decimal amount = 1)
    {
        if (from == null || to == null)
            return 0;

        if (from.ToLower() == "eur" && to.ToLower() == "eur")
            return amount;

        try
        {
            decimal toRate = GetCurrencyRateInEuro(to);
            decimal fromRate = GetCurrencyRateInEuro(from);

            if (from.ToLower() == "eur")
            {
                return (amount * toRate);
            }
            else if (to.ToLower() == "eur")
            {
                return (amount / fromRate);
            }
            else
            {
                return (amount * toRate) / fromRate;
            }
        }
        catch { return 0; }
    }
}
