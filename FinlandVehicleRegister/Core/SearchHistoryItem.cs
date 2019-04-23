using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinlandVehicleRegister.Core
{
    [Serializable]
    public class SearchHistoryItem
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Results { get; set; }
        public string Query { get; set; }
        public string Parameters { get; set; }

        public SearchHistoryItem(string name, DateTime date, string results, string query, string parameters)
        {
            Name = name;
            Date = date;
            Results = results;
            Query = query;
            Parameters = parameters;
        }
    }
}
