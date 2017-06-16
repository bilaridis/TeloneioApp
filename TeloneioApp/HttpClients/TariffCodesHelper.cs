using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Windows.Automation.Peers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeloneioApp.HttpClients
{
    public class TariffCodesHelper
    {
        private HttpClient _httpClient;
        public TariffCodesHelper()
        {

            _httpClient = new HttpClient { BaseAddress = new Uri("http://ec.europa.eu/taxation_customs/dds2/taric/") };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //GetChapterDescriptions();
        }

        public List<Chapter> GetChapterDescriptions(string taricCode)
        {
            //nomenclaturetree/nomenclaturetree_el_20170616_33_el.js

            var response = _httpClient.GetAsync($"nomenclaturetree/nomenclaturetree_el_20170616_{taricCode.Substring(0,2)}_el.js").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var filteredContent = content.Split(';')[1];
            var toDeserialiazed = filteredContent.Split('=')[1];
            var obj = JsonConvert.DeserializeObject<List<object>>(toDeserialiazed);//();
            List<Chapter> chapters = new List<Chapter>();
            foreach (JArray item in obj)
            {
                Chapter ch = new Chapter(item);
                chapters.Add(ch);
            }

            return chapters;


        }
        public static DataTable convertStringToDataTable(string data)
        {
            DataTable dataTable = new DataTable();
            bool columnsAdded = false;
            foreach (string row in data.Split('$'))
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (string cell in row.Split('|'))
                {
                    string[] keyValue = cell.Split('~');
                    if (!columnsAdded)
                    {
                        DataColumn dataColumn = new DataColumn(keyValue[0]);
                        dataTable.Columns.Add(dataColumn);
                    }
                    dataRow[keyValue[0]] = keyValue[1];
                }
                columnsAdded = true;
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        public string getFootnoteUserDesc(DataTable content)
        {
            if (content == null)
                return "";

            foreach (var item in content.Rows)
            {
                item.ToString();
            }
            return "";
        }
    }
}
