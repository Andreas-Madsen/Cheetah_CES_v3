using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cheetah_Transport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheetah_Transport.Data.Tests
{
    [TestClass()]
    public class PackageDAOTests
    {
        [TestMethod()]
        public void FetchAllTest()
        {
            TransportTypeDAO test = new TransportTypeDAO();
            test.FetchAll();
            Assert.IsNotNull(test);
        }

        [TestMethod()]
        public void FetchAllTest1()
        {

        }
    }
}