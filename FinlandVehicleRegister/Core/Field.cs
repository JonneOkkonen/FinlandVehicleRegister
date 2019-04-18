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
            ajoneuvoluokka,
            ensirekisterointipvm,
            ajoneuvoryhma,
            ajoneuvonkaytto,
            variantti,
            versio,
            kayttoonottopvm,
            vari,
            ovienLukumaara,
            korityyppi,
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

        public Field(Fields fieldName, string value)
        {
            FieldName = fieldName;
            Value = value;
        }
    }
}
