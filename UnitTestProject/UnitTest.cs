
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
            query.AddField(Field.Fields.merkki, "BMW");
            query.AddField(Field.Fields.valmistenumero, "123456789");
            query.Build(QueryBuilder.QueryType.Select);
            string actual = query.QueryString;
            string expected = "SELECT * FROM Ajoneuvo WHERE merkki='BMW', valmistenumero='123456789';";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        // Build SELECT Query with Single fields
        public void TestSelectSingleBuild()
        {
            QueryBuilder query = new QueryBuilder();
            query.AddField(Field.Fields.merkki, "BMW");
            query.Build(QueryBuilder.QueryType.Select);
            string actual = query.QueryString;
            string expected = "SELECT * FROM Ajoneuvo WHERE merkki='BMW';";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        // Build SELECT Query with 0 fields
        public void TestSelectBuild()
        {
            QueryBuilder query = new QueryBuilder();
            query.Build(QueryBuilder.QueryType.Select);
            string actual = query.QueryString;
            string expected = "SELECT * FROM Ajoneuvo;";
            Assert.AreEqual(expected, actual);
        }
    }
}
