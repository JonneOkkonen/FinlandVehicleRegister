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
        [JsonProperty("ajoneuvoluokka_koodi")]
        public string AjoneuvoLuokkaKoodi { get; set; }
        [JsonProperty("ajoneuvoluokka_lyhytselite")]
        public string AjoneuvoLuokkaLyhytselite { get; set; }
        [JsonProperty("ajoneuvoluokka_pitkaselite")]
        public string AjoneuvoLuokkaPitkaselite { get; set; }
        [JsonProperty("ensirekisterointipvm")]
        public string Ensirekisterointipvm { get; set; }
        [JsonProperty("ajoneuvoryhma")]
        public string AjoneuvoRyhma { get; set; }
        [JsonProperty("ajoneuvonkaytto")]
        public string AjoneuvonKaytto { get; set; }
        [JsonProperty("variantti")]
        public string Variantti { get; set; }
        [JsonProperty("versio")]
        public string Versio { get; set; }
        [JsonProperty("kayttoonottopvm")]
        public string Kayttoonottopvm { get; set; }
        [JsonProperty("vari")]
        public string Vari { get; set; }
        [JsonProperty("ovienLukumaara")]
        public int OvienLukumaara { get; set; }
        [JsonProperty("korityyppi_koodi")]
        public string KorityyppiKoodi { get; set; }
        [JsonProperty("korityyppi_pitkaselite")]
        public string KorityyppiPitkaselite { get; set; }
        [JsonProperty("ohjaamotyyppi")]
        public string Ohjaamotyyppi { get; set; }
        [JsonProperty("istumapaikkojenLkm")]
        public int IstumapaikkojenLkm { get; set; }
        [JsonProperty("omamassa")]
        public int OmaMassa { get; set; }
        [JsonProperty("teknSuurSallKokmassa")]
        public int TeknSuurSallKokmassa { get; set; }
        [JsonProperty("tieliikSuurSallKokmassa")]
        public int TieLiikSuurSallKokmassa { get; set; }
        [JsonProperty("ajonKokPituus")]
        public int AjonKokPituus { get; set; }
        [JsonProperty("ajonLeveys")]
        public int AjonLeveys { get; set; }
        [JsonProperty("ajonKorkeus")]
        public int AjonKorkeus { get; set; }
        [JsonProperty("kayttovoima")]
        public string Kayttovoima { get; set; }
        [JsonProperty("iskutilavuus")]
        public int Iskutilavuus { get; set; }
        [JsonProperty("suurinNettoteho")]
        public int SuurinNettoteho { get; set; }
        [JsonProperty("sylintereidenLkm")]
        public int SylintereidenLkm { get; set; }
        [JsonProperty("ahdin")]
        public int Ahdin { get; set; }
        [JsonProperty("sahkohybridi")]
        public int Sahkohybridi { get; set; }
        [JsonProperty("sahkohybridinluokka")]
        public string Sahkohybridinluokka { get; set; }
        [JsonProperty("merkkiSelvakielinen")]
        public string Merkki { get; set; }
        [JsonProperty("mallimerkinta")]
        public string Malli { get; set; }
        [JsonProperty("vaihteisto")]
        public string Vaihteisto { get; set; }
        [JsonProperty("vaihteidenLkm")]
        public string VaihteidenLkm { get; set; }
        [JsonProperty("kaupallinenNimi")]
        public string KaupallinenNimi { get; set; }
        [JsonProperty("voimanvalJaTehostamistapa")]
        public string VoimanvalJaTehostamistapa { get; set; }
        [JsonProperty("tyyppihyvaksyntanro")]
        public string Tyyppihyvaksyntanro { get; set; }
        [JsonProperty("yksittaisKayttovoima")]
        public string YksittaisKayttovoima { get; set; }
        [JsonProperty("kunta")]
        public string Kunta { get; set; }
        [JsonProperty("Co2")]
        public int Co2 { get; set; }
        [JsonProperty("matkamittarilukema")]
        public int Matkamittarilukema { get; set; }
        [JsonProperty("alue")]
        public string Alue { get; set; }
        [JsonProperty("valmistenumero2")]
        public string Valmistenumero { get; set; }
    }
}
