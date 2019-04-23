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
    public class QueryBuilderTests
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
            string expected = "SELECT * FROM Vehicle WHERE merkkiSelvakielinen LIKE '%BMW%' AND valmistenumero2='123456789' LIMIT 100;";
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
            string expected = "SELECT * FROM Vehicle WHERE merkkiSelvakielinen LIKE '%BMW%' LIMIT 100;";
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
    }
}
