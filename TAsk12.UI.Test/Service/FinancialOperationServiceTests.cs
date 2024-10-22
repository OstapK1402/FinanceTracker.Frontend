using Moq;
using Task12.BLL.Helpers;

namespace Task12.BLL.Service.Tests
{
    [TestClass()]
    public class FinancialOperationServiceTests
    {
        private CancellationToken token;
        private Mock<HttpMessageHandler> httpMessageHandler;
        private Mock<HttpResponseValidator> responseValidator;
        private HttpClient httpClient;
        private FinancialOperationService service;

        [TestInitialize]
        public void Setup()
        {
            token = CancellationToken.None;
            httpMessageHandler = new Mock<HttpMessageHandler>();
            responseValidator = new Mock<HttpResponseValidator>();
            httpClient = new HttpClient(httpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://localhost")
            };
            service = new FinancialOperationService(httpClient, responseValidator.Object);
        }

        //[TestMethod()]
        //public void GetAllFinancialOperationsTest()
        //{
        //    Assert.Fail();
        //}
    }
}