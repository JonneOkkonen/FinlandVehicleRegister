using FinlandVehicleRegister.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass()]
    public class VehicleAPITests
    {
        [TestMethod()]
        // Get Data from API
        public void TestLoadData()
        {
            QueryBuilder query = new QueryBuilder();
            query.AddField(Field.Fields.ID, "8897");
            query.Build(QueryBuilder.QueryType.Select);
            string actual = VehicleAPI.LoadData(query.QueryString);
            string expected = "[{\"ID\":\"8897\",\"ajoneuvoluokka_koodi\":\"O2\",\"ajoneuvoluokka_lyhytselite\":\"PerÃ¤vaunu\",\"ajoneuvoluokka_pitkaselite\":\"PerÃ¤vaunu, 750 < m <= 3500 kg\",\"ensirekisterointipvm\":\"1998-04-22\",\"ajoneuvoryhma\":\"KeskiakseliperÃ¤vaunu\",\"ajoneuvonkaytto\":\"Yksityinen\",\"variantti\":null,\"versio\":null,\"kayttoonottopvm\":\"1998-04-22\",\"vari\":null,\"ovienLukumaara\":null,\"korityyppi_koodi\":null,\"korityyppi_pitkaselite\":null,\"ohjaamotyyppi\":null,\"istumapaikkojenLkm\":null,\"omamassa\":\"640\",\"teknSuurSallKokmassa\":null,\"tieliikSuurSallKokmassa\":\"2100\",\"ajonKokPituus\":null,\"ajonLeveys\":\"2250\",\"ajonKorkeus\":null,\"kayttovoima\":null,\"iskutilavuus\":null,\"suurinNettoteho\":null,\"sylintereidenLkm\":null,\"ahdin\":null,\"sahkohybridi\":null,\"sahkohybridinluokka\":null,\"merkkiSelvakielinen\":\"Omavalmiste\",\"mallimerkinta\":\"PV 2100\",\"vaihteisto\":null,\"vaihteidenLkm\":null,\"kaupallinenNimi\":null,\"voimanvalJaTehostamistapa\":\"8\",\"tyyppihyvaksyntanro\":null,\"yksittaisKayttovoima\":null,\"kunta\":\"Oulu\",\"Co2\":null,\"matkamittarilukema\":null,\"alue\":\"901\",\"valmistenumero2\":null}]";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        // Test Get Vehicles
        public void TestGetVehicles()
        {
            QueryBuilder query = new QueryBuilder();
            query.AddField(Field.Fields.ID, "8897");
            query.Build(QueryBuilder.QueryType.Select);
            List<Vehicle> vehicles = VehicleAPI.GetVehicles(query.QueryString);
            string actual = vehicles[0].Ensirekisterointipvm;
            string expected = "1998-04-22";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        // Test Get Options
        public void TestGetOptions()
        {
            List<Option> values = VehicleAPI.GetOptions(QueryBuilder.Table.VOhjaamotyyppi);
            string actual1 = values[0].Value;
            string expected1 = "Umpiohjaamo";
            Assert.AreEqual(expected1, actual1);
            string actual2 = values[1].Value;
            string expected2 = "Suojakehys";
            Assert.AreEqual(expected2, actual2);
            string actual3 = values[2].Value;
            string expected3 = "Jatko-ohjaamo";
            Assert.AreEqual(expected3, actual3);
            string actual4 = values[3].Value;
            string expected4 = "Avo-ohjaamo";
            Assert.AreEqual(expected4, actual4);
        }

        [TestMethod()]
        [ExpectedException(typeof(QueryEmptyException))]
        public void TestQueryEmptyError()
        {
            List<Vehicle> vehicles = VehicleAPI.GetVehicles("");
        }

        [TestMethod()]
        [ExpectedException(typeof(ZeroResultsFromQueryException))]
        public void TestZeroResultsError()
        {
            List<Vehicle> vehicles = VehicleAPI.GetVehicles("SELECT * FROM Vehicle WHERE ID = 630902340;");
        }

        [TestMethod()]
        [ExpectedException(typeof(MySQLErrorException))]
        public void TestMySQLError()
        {
            List<Vehicle> vehicles = VehicleAPI.GetVehicles("SELECT  FROM Vehicle LIMIT 1;");
        }

        [TestMethod()]
        [ExpectedException(typeof(IncorrectAPIKeyException))]
        public void TestIncorrectAPIKey()
        {
            VehicleAPI.URL = $"https://www.jonneokkonen.com/api/ajoneuvorekisteri.php?query="; ;
            List<Vehicle> vehicles = VehicleAPI.GetVehicles("SELECT  FROM Vehicle LIMIT 1;");
        }
    }
}
