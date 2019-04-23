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

        /// <summary>
        /// Default Constructor for SearchHistoryItem
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="results"></param>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
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
