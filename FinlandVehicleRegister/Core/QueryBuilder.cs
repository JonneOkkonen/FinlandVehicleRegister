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
        private readonly string TableName = "Vehicle";
        private List<Field> fields = new List<Field>();
        public enum QueryType
        {
            Select
        }
        
        /// <summary>
        /// Builds Basic Query based on query type and given fields
        /// </summary>
        /// <param name="type"></param>
        public void Build(QueryType type)
        {
            switch(type)
            {
                case QueryType.Select:
                    queryString += $"SELECT * FROM {TableName}";
                    if (fields.Count != 0)
                    {
                        queryString += " WHERE ";
                        Field last = fields.Last();
                        foreach (Field f in fields)
                        {
                            if (f == last)
                                queryString += $"{f.FieldName}='{f.Value}' LIMIT 100;";
                            else
                                queryString += $"{f.FieldName}='{f.Value}' AND ";
                        }
                    }
                    else queryString += " LIMIT 100;";
                    break;   
            }
        }

        public void AddField(Field.Fields field, string value)
        {
            fields.Add(new Field(field, value));
        }
    }
}
