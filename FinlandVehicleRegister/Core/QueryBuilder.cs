using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinlandVehicleRegister.Core
{
    public class QueryBuilder
    {
        /// <summary>
        /// QueryString that was created in build
        /// </summary>
        public string QueryString
        {
            get
            {
                return queryString;
            }
        }
        private string queryString { get; set; }
        private List<Field> fields = new List<Field>();
        public enum QueryType
        {
            Select
        }

        public enum Table
        {
            VAjoneuvoluokka,
            VAjoneuvon_kaytto,
            VAjoneuvoryhma,
            VKayttovoima,
            VKorityyppi,
            VKunta,
            VOhjaamotyyppi,
            VVari,
            Vehicle,
            ChartVari,
            Ajoneuvo
        }
        
        /// <summary>
        /// Builds Basic Query based on query type and given fields
        /// </summary>
        /// <param name="type"></param>
        public void Build(QueryType type, Table table = Table.Vehicle, int limit = 100)
        {
            switch(type)
            {
                case QueryType.Select:
                    queryString += $"SELECT * FROM {table}";
                    if (fields.Count != 0)
                    {
                        queryString += " WHERE ";
                        Field last = fields.Last();
                        foreach (Field f in fields)
                        {
                            if (f == last)
                                queryString += $"{f.FieldName}='{f.Value}' LIMIT {limit};";
                            else
                                queryString += $"{f.FieldName}='{f.Value}' AND ";
                        }
                    }
                    else queryString += $" LIMIT {limit};";
                    break;   
            }
        }

        public void AddField(Field.Fields field, string value)
        {
            fields.Add(new Field(field, value));
        }
    }
}
