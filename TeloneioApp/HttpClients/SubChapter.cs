using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TeloneioApp.HttpClients
{
    public class SubChapter
    {
        public SubChapter()
        {
            
        }
        public SubChapter(JArray item)
        {
            Level = item[1].ToString();
            TariffKey = item[2].ToString();
            NumKey = item[3].ToString();
            LevelNumKey = item[4].ToString();
            Descr = item[5].ToString();
            //Rules = new List<Rule>();
            //if (item[6].ToString() != "")
            //{
            //    foreach (JArray jItem in item[6].ToObject<List<JArray>>())
            //    {
            //        Rules.Add(new Rule(jItem));
            //    }
            //}
            Chapters = new List<Chapter>();
            if (item[7].ToString() != "")
            {
                foreach (JArray jItem in item[7].ToObject<List<JArray>>())
                {

                    Chapters.Add(new Chapter(jItem));
                }
            }
            //SecondBool = bool.Parse(item[8].ToString());
            //Object1 = item[9].ToString();
            //Object2 = item[10].ToString();
            //Object3 = item[11].ToString();
            //Object4 = item[12].ToString();
        }
        //public bool IsChild { get; set; }
        public string Level { get; set; }
        public string TariffKey { get; set; }
        public string NumKey { get; set; }
        public string LevelNumKey { get; set; }
        public string Descr { get; set; }
        //public List<Rule> Rules { get; set; }
        public List<Chapter> Chapters { get; set; }
        //public bool SecondBool { get; set; }
        //public dynamic Object1 { get; set; }
        //public dynamic Object2 { get; set; }
        //public dynamic Object3 { get; set; }
        //public dynamic Object4 { get; set; }

    }
}