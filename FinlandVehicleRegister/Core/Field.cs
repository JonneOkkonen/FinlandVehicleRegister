using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinlandVehicleRegister.Core
{
    public class Field
    {
        public enum Fields
        {
            merkki,
            valmistenumero
        };

        public Fields FieldName { get; set; }
        public string Value { get; set; }

        public Field(Fields fieldName, string value)
        {
            FieldName = fieldName;
            Value = value;
        }
    }
}
