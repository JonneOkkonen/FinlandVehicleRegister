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
            ID,
            ajoneuvoluokka_koodi,
            ensirekisterointipvm,
            ajoneuvoryhma,
            ajoneuvonkaytto,
            variantti,
            versio,
            kayttoonottopvm,
            vari,
            ovienLukumaara,
            korityyppi_pitkaselite,
            ohjaamotyyppi,
            istumapaikkojenLkm,
            omamassa,
            teknSuurSallKokmassa,
            tieliikSuurSallKokmassa,
            ajonKokPituus,
            ajonLeveys,
            ajonKorkeus,
            kayttovoima,
            iskutilavuus,
            suurinNettoteho,
            sylintereidenLkm,
            ahdin,
            sahkohybridi,
            sahkohybridiluokka,
            merkkiSelvakielinen,
            mallimerkinta,
            vaihteisto,
            vaihteidenLkm,
            kaupallinenNimi,
            voimanvalJaTehostamistapa,
            tyyppihyvaksyntanro,
            yksittaisKayttovoima,
            kunta,
            Co2,
            matkamittarilukema,
            alue,
            valmistenumero2,
            jarnro
        };

        public Fields FieldName { get; set; }
        public string Value { get; set; }
        public string Value2 { get; set; }

        /// <summary>
        /// Default constructor for Field
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <param name="value2"></param>
        public Field(Fields fieldName, string value, string value2 = null)
        {
            FieldName = fieldName;
            Value = value;
            Value2 = value2;
        }
    }
}
