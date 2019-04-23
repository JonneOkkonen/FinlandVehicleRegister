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

        /// <summary>
        /// Tablelist (V* = VIEW)  
        /// </summary>
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
            ChartAjoneuvoluokka,
            ChartAjoneuvonKaytto,
            ChartKayttovoima,
            ChartKorityyppi,
            Ajoneuvo
        }

        /// <summary>
        ///  Builds Basic Query based on query type, table, view limit and given fields
        /// </summary>
        /// <param name="type"></param>
        /// <param name="limit"></param>
        /// <param name="table"></param>
        public void Build(QueryType type, int limit = 100, Table table = Table.Vehicle)
        {
            switch(type)
            {
                case QueryType.Select:
                    queryString += $"SELECT * FROM {table}";
                    if (fields.Count != 0)
                    {
                        queryString += " WHERE ";
                        // Last Field
                        Field last = fields.Last();
                        foreach (Field f in fields)
                        {
                            if (f == last)
                            {
                                if (f.Value2 != null) {
                                    queryString += $"{f.FieldName} BETWEEN '{f.Value}' AND '{f.Value2}' LIMIT {limit};";
                                } else {
                                    switch(f.FieldName)
                                    {
                                        case Field.Fields.merkkiSelvakielinen:
                                            queryString += $"{f.FieldName} LIKE '%{f.Value}%' LIMIT {limit};";
                                            break;
                                        case Field.Fields.mallimerkinta:
                                            queryString += $"{f.FieldName} LIKE '%{f.Value}%' LIMIT {limit};";
                                            break;
                                        default:
                                            queryString += $"{f.FieldName}='{f.Value}' LIMIT {limit};";
                                            break;
                                    }
                                }
                            }                                  
                            else
                            {
                                if (f.Value2 != null) {
                                    queryString += $"{f.FieldName} BETWEEN '{f.Value}' AND '{f.Value2}' AND ";
                                } else {
                                    switch (f.FieldName)
                                    {
                                        case Field.Fields.merkkiSelvakielinen:
                                            queryString += $"{f.FieldName} LIKE '%{f.Value}%' AND ";
                                            break;
                                        case Field.Fields.mallimerkinta:
                                            queryString += $"{f.FieldName} LIKE '%{f.Value}%' AND ";
                                            break;
                                        default:
                                            queryString += $"{f.FieldName}='{f.Value}' AND ";
                                            break;
                                    }
                                }   
                            }
                        }
                    }
                    else queryString += $" LIMIT {limit};";
                    break;   
            }
        }

        /// <summary>
        /// Add Field to Query WHERE Clause
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="value2"></param>
        public void AddField(Field.Fields field, string value, string value2 = null)
        {
            fields.Add(new Field(field, value, value2));
        }

        /// <summary>
        /// Return all fields from field list in single string
        /// </summary>
        /// <returns></returns>
        public string FieldsToString()
        {
            string result = "";
            foreach(Field item in fields)
            {
                if(item.Value2 != null)
                {
                    result += $"{item.FieldName}: {item.Value} - {item.Value2}, ";
                }
                else
                {
                    result += $"{item.FieldName}: {item.Value}, ";
                }
            }
            return result;
        }
    }
}
