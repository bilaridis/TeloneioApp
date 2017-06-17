﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        }

        public Chapter GetChapterDescriptions(string taricCode)
        {
            //nomenclaturetree/nomenclaturetree_el_20170616_33_el.js

            var response = _httpClient.GetAsync($"nomenclaturetree/nomenclaturetree_el_20170616_{taricCode.Substring(0,2)}_el.js").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            if (content.Contains("under maintenance"))
            {
                MessageBox.Show("The taric system is under construction");
                return null;
            }
            else
            {
                var filteredContent = content.Split(';')[1];
                var toDeserialiazed = filteredContent.Split('=')[1];
                var obj = JsonConvert.DeserializeObject<List<object>>(toDeserialiazed);//();
                List<Chapter> chapters = new List<Chapter>();
                foreach (JArray item in obj)
                {
                    Chapter ch = new Chapter(item);
                    chapters.Add(ch);
                }
                return chapters.FirstOrDefault();
            }
        }
    }
}
