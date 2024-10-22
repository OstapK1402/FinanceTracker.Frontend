using Moq;

namespace Task12.BLL.Service.Tests
{
    [TestClass()]
    public class FinancialOperationServiceTests
    {
        private CancellationToken token;
        private Mock<HttpMessageHandler> httpMessageHandler;
        private HttpClient httpClient;
        private FinancialOperationService service;

        [TestInitialize]
        public void Setup()
        {
            token = CancellationToken.None;
            httpMessageHandler = new Mock<HttpMessageHandler>();
            httpClient = new HttpClient(httpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://localhost")
            };
            service = new FinancialOperationService(httpClient);
        }

        //[TestMethod()]
        //public void GetAllFinancialOperationsTest()
        //{
        //    Assert.Fail();
        //}
    }
}