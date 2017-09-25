using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnHuiSiteModel
{
    public class ChartModel
    {
        public static List<string> colorList;

        public string label { get; set; }

        public double data { get; set; }

        public string color { get; set; }

        static ChartModel()
        {
            colorList = new List<string>();
            colorList.Add("#68BC31");
            colorList.Add("#2091CF");
            colorList.Add("#AF4E96");
            colorList.Add("#DA5430");
            colorList.Add("#FEE074");
            colorList.Add("#005757");
            colorList.Add("#D94600");
            colorList.Add("#9F4D95");
        }
    }
}
