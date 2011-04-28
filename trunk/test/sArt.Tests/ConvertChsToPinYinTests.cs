using Core.Model;
using Data;
using NUnit.Framework;
using Service;

namespace sArt.Tests
{
    public class ConvertChsToPinYinTests : IntegrationTestsBase
    {

        private UtilService us;

        [SetUp]
        public void SetUp()
        {
            us = new UtilService();
        }

        [Test]
        public void CorrectPinYinShouldBeReturned()
        {
            Assert.AreEqual("(wan2,wan4) (ju4)", us.ConvertChsToPinYin("肯德基"));
        }

        [Test]
        public void ConvertDBValueToPinYinCorrectly()
        {
            var r = new Repo<Vendor>(new DbContextFactory());
            Assert.AreEqual("(ken3) (de2) (ji1)", us.ConvertChsToPinYin(r.Get(6).Name));
        }

    }
}
