using Newtonsoft.Json.Linq;

namespace DomainModel.HttpClients
{
    public class Rule
    {
        public Rule()
        {
            
        }
        public Rule(JArray item)
        {
            RuleNum = item[0].ToString();
            RuleCode = item[1].ToString();
            RuleCategory = item[2].ToString();
            Descr = item[3].ToString();
            Object1 = item[4].ToString();
        }
        public string RuleNum { get; set; }
        public string RuleCode { get; set; }
        public string RuleCategory { get; set; }
        public string Descr { get; set; }
        public dynamic Object1 { get; set; }
    }
}