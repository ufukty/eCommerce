using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.Models
{
    public class FilterList
    {
        public List<FilterButtons> GenderButtons = new List<FilterButtons>();
        public List<FilterButtons> CategoryButtons = new List<FilterButtons>();
        public List<FilterButtons> SizeButtons = new List<FilterButtons>();

        public FilterList(string gender, string category, string size)
        {

            List<string> get = new List<string>(new string[] { gender, category, size });

            GenderButtons.Add(new FilterButtons(get, 0, "-women", "KADIN"));
            GenderButtons.Add(new FilterButtons(get, 0, "-men", "ERKEK"));
            GenderButtons.Add(new FilterButtons(get, 0, "-girls", "KIZ ÇOCUK"));
            GenderButtons.Add(new FilterButtons(get, 0, "-boys", "ERKEK ÇOCUK"));

            CategoryButtons.Add(new FilterButtons(get, 1, "-skirt", "ETEK"));
            CategoryButtons.Add(new FilterButtons(get, 1, "-shirt", "GÖMLEK"));
            CategoryButtons.Add(new FilterButtons(get, 1, "-tshirt", "TİŞÖRT"));
            CategoryButtons.Add(new FilterButtons(get, 1, "-trousers", "PANTOLON"));
            CategoryButtons.Add(new FilterButtons(get, 1, "-jean", "JEAN"));
            CategoryButtons.Add(new FilterButtons(get, 1, "-outerwear", "DIŞ GİYİM"));
            CategoryButtons.Add(new FilterButtons(get, 1, "-sweatshirt", "KAZAK"));
            CategoryButtons.Add(new FilterButtons(get, 1, "-blazer", "BLAZER"));

            SizeButtons.Add(new FilterButtons(get, 2, "-xs", "XS"));
            SizeButtons.Add(new FilterButtons(get, 2, "-s", "S"));
            SizeButtons.Add(new FilterButtons(get, 2, "-m", "M"));
            SizeButtons.Add(new FilterButtons(get, 2, "-l", "L"));
            SizeButtons.Add(new FilterButtons(get, 2, "-xl", "XL"));
        }
    }

    public class FilterButtons
    {
        public string displayName;
        public string queryName;
        public bool isActive = false;
        public string className;
        public List<string> linkParams;

        public FilterButtons(List<string> get, int curIndex, string key, string displayName)
        {
            // (1) Direkt kopyalanan değişkenler

            this.displayName = displayName;
            queryName = key.Substring(1, key.Length - 1);
            linkParams = new List<string>(get);

            // (2) buton'a tıklandığında gönderilecek parametreleri belirleme

            string curStr = get[curIndex];

            if (curStr.IndexOf(key) > -1)
                isActive = true;

            if (isActive)
            {
                className = "btn btn-sm btn-primary";
                var pivotOne = curStr.IndexOf(key);
                var pivotTwo = pivotOne + key.Length;
                linkParams[curIndex] = curStr.Substring(0, pivotOne) + curStr.Substring(pivotTwo, curStr.Length - pivotTwo);
            }
            else
            {
                className = "btn btn-sm btn-outline-primary";
                if (curStr.IndexOf("-empty") > -1)
                    linkParams[curIndex] = key;
                else
                    linkParams[curIndex] = linkParams[curIndex] + key;
            }
        }
    }
}