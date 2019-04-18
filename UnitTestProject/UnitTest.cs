
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinlandVehicleRegister.Core;
using System.Diagnostics;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        // Build SELECT Query with Multiple fields
        public void TestSelectMultipleBuild()
        {
            QueryBuilder query = new QueryBuilder();
            query.AddField(Field.Fields.merkkiSelvakielinen, "BMW");
            query.AddField(Field.Fields.valmistenumero2, "123456789");
            query.Build(QueryBuilder.QueryType.Select);
            string actual = query.QueryString;
            string expected = "SELECT * FROM Vehicle WHERE merkkiSelvakielinen='BMW' AND valmistenumero2='123456789' LIMIT 100;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        // Build SELECT Query with Single fields
        public void TestSelectSingleBuild()
        {
            QueryBuilder query = new QueryBuilder();
            query.AddField(Field.Fields.merkkiSelvakielinen, "BMW");
            query.Build(QueryBuilder.QueryType.Select);
            string actual = query.QueryString;
            string expected = "SELECT * FROM Vehicle WHERE merkkiSelvakielinen='BMW' LIMIT 100;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        // Build SELECT Query with 0 fields
        public void TestSelectBuild()
        {
            QueryBuilder query = new QueryBuilder();
            query.Build(QueryBuilder.QueryType.Select);
            string actual = query.QueryString;
            string expected = "SELECT * FROM Vehicle LIMIT 100;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        // Get Data from API
        public void TestVehicleAPI()
        {
            QueryBuilder query = new QueryBuilder();
            query.AddField(Field.Fields.ID, "8897");
            query.Build(QueryBuilder.QueryType.Select);
            string actual = VehicleAPI.LoadData(query.QueryString);
            string expected = "[{\"ID\":\"8897\",\"ajoneuvoluokka_koodi\":\"O2\",\"ajoneuvoluokka_lyhytselite\":\"PerÃ¤vaunu\",\"ajoneuvoluokka_pitkaselite\":\"PerÃ¤vaunu, 750 < m <= 3500 kg\",\"ensirekisterointipvm\":\"1998-04-22\",\"ajoneuvoryhma\":\"KeskiakseliperÃ¤vaunu\",\"ajoneuvonkaytto\":\"Yksityinen\",\"variantti\":null,\"versio\":null,\"kayttoonottopvm\":\"1998-04-22\",\"vari\":null,\"ovienLukumaara\":null,\"korityyppi_koodi\":null,\"korityyppi_pitkaselite\":null,\"ohjaamotyyppi\":null,\"istumapaikkojenLkm\":null,\"omamassa\":\"640\",\"teknSuurSallKokmassa\":null,\"tieliikSuurSallKokmassa\":\"2100\",\"ajonKokPituus\":null,\"ajonLeveys\":\"2250\",\"ajonKorkeus\":null,\"kayttovoima\":null,\"iskutilavuus\":null,\"suurinNettoteho\":null,\"sylintereidenLkm\":null,\"ahdin\":null,\"sahkohybridi\":null,\"sahkohybridinluokka\":null,\"merkkiSelvakielinen\":\"Omavalmiste\",\"mallimerkinta\":\"PV 2100\",\"vaihteisto\":null,\"vaihteidenLkm\":null,\"kaupallinenNimi\":null,\"voimanvalJaTehostamistapa\":\"8\",\"tyyppihyvaksyntanro\":null,\"yksittaisKayttovoima\":null,\"kunta\":\"Oulu\",\"Co2\":null,\"matkamittarilukema\":null,\"alue\":\"901\",\"valmistenumero2\":null}]";
            Assert.AreEqual(expected, actual);
        }
    }
}
