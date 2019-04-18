using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FinlandVehicleRegister.Core
{
    public class Vehicle
    {
        [JsonProperty("ajoneuvoluokka_koodi", NullValueHandling = NullValueHandling.Ignore)]
        public string AjoneuvoLuokkaKoodi { get; set; }
        [JsonProperty("ajoneuvoluokka_lyhytselite", NullValueHandling = NullValueHandling.Ignore)]
        public string AjoneuvoLuokkaLyhytselite { get; set; }
        [JsonProperty("ajoneuvoluokka_pitkaselite", NullValueHandling = NullValueHandling.Ignore)]
        public string AjoneuvoLuokkaPitkaselite { get; set; }
        [JsonProperty("ensirekisterointipvm", NullValueHandling = NullValueHandling.Ignore)]
        public string Ensirekisterointipvm { get; set; }
        [JsonProperty("ajoneuvoryhma", NullValueHandling = NullValueHandling.Ignore)]
        public string AjoneuvoRyhma { get; set; }
        [JsonProperty("ajoneuvonkaytto", NullValueHandling = NullValueHandling.Ignore)]
        public string AjoneuvonKaytto { get; set; }
        [JsonProperty("variantti", NullValueHandling = NullValueHandling.Ignore)]
        public string Variantti { get; set; }
        [JsonProperty("versio", NullValueHandling = NullValueHandling.Ignore)]
        public string Versio { get; set; }
        [JsonProperty("kayttoonottopvm", NullValueHandling = NullValueHandling.Ignore)]
        public string Kayttoonottopvm { get; set; }
        [JsonProperty("vari", NullValueHandling = NullValueHandling.Ignore)]
        public string Vari { get; set; }
        [JsonProperty("ovienLukumaara", NullValueHandling = NullValueHandling.Ignore)]
        public int OvienLukumaara { get; set; }
        [JsonProperty("korityyppi_koodi", NullValueHandling = NullValueHandling.Ignore)]
        public string KorityyppiKoodi { get; set; }
        [JsonProperty("korityyppi_pitkaselite", NullValueHandling = NullValueHandling.Ignore)]
        public string KorityyppiPitkaselite { get; set; }
        [JsonProperty("ohjaamotyyppi", NullValueHandling = NullValueHandling.Ignore)]
        public string Ohjaamotyyppi { get; set; }
        [JsonProperty("istumapaikkojenLkm", NullValueHandling = NullValueHandling.Ignore)]
        public int IstumapaikkojenLkm { get; set; }
        [JsonProperty("omamassa", NullValueHandling = NullValueHandling.Ignore)]
        public int OmaMassa { get; set; }
        [JsonProperty("teknSuurSallKokmassa", NullValueHandling = NullValueHandling.Ignore)]
        public int TeknSuurSallKokmassa { get; set; }
        [JsonProperty("tieliikSuurSallKokmassa", NullValueHandling = NullValueHandling.Ignore)]
        public int TieLiikSuurSallKokmassa { get; set; }
        [JsonProperty("ajonKokPituus", NullValueHandling = NullValueHandling.Ignore)]
        public int AjonKokPituus { get; set; }
        [JsonProperty("ajonLeveys", NullValueHandling = NullValueHandling.Ignore)]
        public int AjonLeveys { get; set; }
        [JsonProperty("ajonKorkeus", NullValueHandling = NullValueHandling.Ignore)]
        public int AjonKorkeus { get; set; }
        [JsonProperty("kayttovoima", NullValueHandling = NullValueHandling.Ignore)]
        public string Kayttovoima { get; set; }
        [JsonProperty("iskutilavuus", NullValueHandling = NullValueHandling.Ignore)]
        public int Iskutilavuus { get; set; }
        [JsonProperty("suurinNettoteho", NullValueHandling = NullValueHandling.Ignore)]
        public int SuurinNettoteho { get; set; }
        [JsonProperty("sylintereidenLkm", NullValueHandling = NullValueHandling.Ignore)]
        public int SylintereidenLkm { get; set; }
        [JsonProperty("ahdin", NullValueHandling = NullValueHandling.Ignore)]
        public int Ahdin { get; set; }
        [JsonProperty("sahkohybridi", NullValueHandling = NullValueHandling.Ignore)]
        public int Sahkohybridi { get; set; }
        [JsonProperty("sahkohybridinluokka", NullValueHandling = NullValueHandling.Ignore)]
        public string Sahkohybridinluokka { get; set; }
        [JsonProperty("merkkiSelvakielinen", NullValueHandling = NullValueHandling.Ignore)]
        public string Merkki { get; set; }
        [JsonProperty("mallimerkinta", NullValueHandling = NullValueHandling.Ignore)]
        public string Malli { get; set; }
        [JsonProperty("vaihteisto", NullValueHandling = NullValueHandling.Ignore)]
        public string Vaihteisto { get; set; }
        [JsonProperty("vaihteidenLkm", NullValueHandling = NullValueHandling.Ignore)]
        public string VaihteidenLkm { get; set; }
        [JsonProperty("kaupallinenNimi", NullValueHandling = NullValueHandling.Ignore)]
        public string KaupallinenNimi { get; set; }
        [JsonProperty("voimanvalJaTehostamistapa", NullValueHandling = NullValueHandling.Ignore)]
        public string VoimanvalJaTehostamistapa { get; set; }
        [JsonProperty("tyyppihyvaksyntanro", NullValueHandling = NullValueHandling.Ignore)]
        public string Tyyppihyvaksyntanro { get; set; }
        [JsonProperty("yksittaisKayttovoima", NullValueHandling = NullValueHandling.Ignore)]
        public string YksittaisKayttovoima { get; set; }
        [JsonProperty("kunta", NullValueHandling = NullValueHandling.Ignore)]
        public string Kunta { get; set; }
        [JsonProperty("Co2", NullValueHandling = NullValueHandling.Ignore)]
        public int Co2 { get; set; }
        [JsonProperty("matkamittarilukema", NullValueHandling = NullValueHandling.Ignore)]
        public int Matkamittarilukema { get; set; }
        [JsonProperty("alue", NullValueHandling = NullValueHandling.Ignore)]
        public string Alue { get; set; }
        [JsonProperty("valmistenumero2", NullValueHandling = NullValueHandling.Ignore)]
        public string Valmistenumero { get; set; }
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }
    }
}
