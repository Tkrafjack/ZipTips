using Infrastructure.Census;

namespace IntegrationTests
{
    [TestClass]
    public class GetBusinessMetricsTests
    {
        [TestMethod]
        public void ShouldGetZipCodeInfo ()
        {
            var censusRequestService = new CensusRequestService();
            int testZip = 77001;
            int testBusinessSector = 72;

            var result = censusRequestService.GetBusinessMetrics(testZip, testBusinessSector);
        }
    }
}