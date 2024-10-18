using Moq;
using Moq.Protected;
using System.Net;
using System.Text;
using System.Text.Json;
using Task12.BLL.DTO;
using Task12.BLL.Service;

namespace TAsk12.UI.Test
{
    [TestClass]
    public class TransactionTypeServiceTest
    {
        private CancellationToken token;
        private Mock<HttpMessageHandler> httpMessageHandler;
        private HttpClient httpClient;
        private TransactionTypeService service;

        [TestInitialize]
        public void Setup()
        {
            token = CancellationToken.None;
            httpMessageHandler = new Mock<HttpMessageHandler>();
            httpClient = new HttpClient(httpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://localhost")
            };
            service = new TransactionTypeService(httpClient);
        }

        [TestMethod]
        public async Task GetAllTransactionsTypes_ReturnTransactionsTypes_ResponseIsSuccessful()
        {
            //arrange
            var transactionsTypes = new List<TransactionsTypeDTO>
            {
                new TransactionsTypeDTO{TypeId = 1, Name = "Зарплата", IsIncome = true },
                new TransactionsTypeDTO{TypeId = 2, Name = "Оренда", IsIncome = false }
            };

            var jsonData = JsonSerializer.Serialize(transactionsTypes);
            var httpResponseMessage = new HttpResponseMessage 
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act
            var result = await service.GetAllTransactionsTypes(token);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), transactionsTypes.Count());
        }

        [TestMethod]
        public async Task GetAllTransactionsTypes_ThrowHttpRequestException_ResponseIsInternalServerError()
        {
            //arrange
            var errorMessage = "Server error occurred";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<HttpRequestException>(
                () => service.GetAllTransactionsTypes(token)
            );

            Assert.IsTrue(exception.Message.Contains("Error: InternalServerError"));
            Assert.IsTrue(exception.Message.Contains(errorMessage));
        }

        [TestMethod]
        public async Task GetTransactionsTypeById_ReturnTransactionsType_ResponseIsSuccessful()
        {
            //arrange
            int id = 1;
            var transactionsType = new TransactionsTypeDTO
            {
                TypeId = id, Name = "Зарплата", IsIncome = true
            };

            var jsonData = JsonSerializer.Serialize(transactionsType);
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act
            var result = await service.GetTransactionsTypeById(id, token);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, transactionsType.Name);
            Assert.AreEqual(result.IsIncome, transactionsType.IsIncome);
            Assert.AreEqual(result.TypeId, transactionsType.TypeId);
        }

        [TestMethod]
        public async Task GetTransactionsTypeById_ThrowInvalidOperationException_ResponseIsNotFound()
        {
            //arrange
            int id = 1;
            var errorMessage = "Not Found";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                () => service.GetTransactionsTypeById(id, token)
            );

            Assert.AreEqual(exception.Message, ($"Not Found: {errorMessage}"));
        }

        [TestMethod]
        public async Task GetTransactionsTypeById_ThrowHttpRequestException_ResponseIsInternalServerError()
        {
            //arrange
            int id = 1;
            var errorMessage = "Server error occurred";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<HttpRequestException>(
                () => service.GetTransactionsTypeById(id, token)
            );

            Assert.IsTrue(exception.Message.Contains("Error: InternalServerError"));
            Assert.IsTrue(exception.Message.Contains(errorMessage));
        }

        [TestMethod]
        public async Task CreateTransactionsType_ReturnOk_ResponseIsSuccessful()
        {
            //arrange
            var transactionsType = new TransactionsTypeDTO
            {
                TypeId = 0,
                Name = "Зарплата",
                IsIncome = true
            };

            var responseContent = "Successfully created";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act
            var result = await service.CreateTransactionsType(transactionsType, token);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, responseContent);
        }

        [TestMethod]
        public async Task CreateTransactionsType_ThrowInvalidOperationException_ResponseIsConflict()
        {
            //arrange
            var transactionsType = new TransactionsTypeDTO
            {
                TypeId = 0,
                Name = "Зарплата",
                IsIncome = true
            };

            var errorMessage = "Transactions Type already exists";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Conflict,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                () => service.CreateTransactionsType(transactionsType, token)
            );

            Assert.AreEqual(exception.Message, ($"Conflict: {errorMessage}"));
        }

        [TestMethod]
        public async Task CreateTransactionsType_ThrowInvalidOperationException_ResponseIsBadRequest()
        {
            //arrange

            var errorMessage = "TransactionsTypeDTO is null";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                () => service.CreateTransactionsType((TransactionsTypeDTO)null, token)
            );

            Assert.AreEqual(exception.Message, ($"Bad Request: {errorMessage}"));
        }

        [TestMethod]
        public async Task CreateTransactionsType_ThrowInvalidOperationException_ResponseIsInternalServerError()
        {
            //arrange
            var transactionsType = new TransactionsTypeDTO
            {
                TypeId = 0,
                Name = "Зарплата",
                IsIncome = true
            };

            var errorMessage = "Something went wrong while saving";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                () => service.CreateTransactionsType(transactionsType, token)
            );

            Assert.AreEqual(exception.Message, ($"Internal Server Error: {errorMessage}"));
        }

        [TestMethod]
        public async Task CreateTransactionsType_ThrowHttpRequestException_ResponseIsOtherError()
        {
            //arrange
            var transactionsType = new TransactionsTypeDTO
            {
                TypeId = 0,
                Name = "Зарплата",
                IsIncome = true
            };

            var errorMessage = "Some other error";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.ServiceUnavailable,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<HttpRequestException>(
                () => service.CreateTransactionsType(transactionsType, token)
            );

            Assert.IsTrue(exception.Message.Contains("Error: ServiceUnavailable"));
            Assert.IsTrue(exception.Message.Contains(errorMessage));
        }

        [TestMethod]
        public async Task UpdateTransactionsType_ReturnOk_ResponseIsSuccessful()
        {
            //arrange
            int id = 1;
            var transactionsType = new TransactionsTypeDTO
            {
                TypeId = 1,
                Name = "Зарплата",
                IsIncome = true
            };

            var responseContent = "Successfully updated";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act
            var result = await service.UpdateTransactionsType(id, transactionsType, token);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, responseContent);
        }

        [TestMethod]
        public async Task UpdateTransactionsType_ThrowInvalidOperationException_ResponseIsNotFound()
        {
            //arrange
            int id = 1;
            var transactionsType = new TransactionsTypeDTO
            {
                TypeId = 1,
                Name = "Зарплата",
                IsIncome = true
            };

            var errorMessage = "Not Found Transactions type";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                () => service.UpdateTransactionsType(id, transactionsType, token)
            );

            Assert.AreEqual(exception.Message, ($"Not Found: {errorMessage}"));
        }

        [TestMethod]
        public async Task UpdateTransactionsType_ThrowInvalidOperationException_ResponseIsBadRequest()
        {
            //arrange
            int id = 1;

            var errorMessage = "TransactionsTypeDTO is null";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                () => service.UpdateTransactionsType(id, (TransactionsTypeDTO)null, token)
            );

            Assert.AreEqual(exception.Message, ($"Bad Request: {errorMessage}"));
        }

        [TestMethod]
        public async Task UpdateTransactionsType_ThrowInvalidOperationException_ResponseIsInternalServerError()
        {
            //arrange
            int id = 1;
            var transactionsType = new TransactionsTypeDTO
            {
                TypeId = 0,
                Name = "Зарплата",
                IsIncome = true
            };

            var errorMessage = "Something went wrong while saving";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                () => service.UpdateTransactionsType(id, transactionsType, token)
            );

            Assert.AreEqual(exception.Message, ($"Internal Server Error: {errorMessage}"));
        }

        [TestMethod]
        public async Task UpdateTransactionsType_ThrowHttpRequestException_ResponseIsOtherError()
        {
            //arrange
            int id = 1;
            var transactionsType = new TransactionsTypeDTO
            {
                TypeId = 1,
                Name = "Зарплата",
                IsIncome = true
            };

            var errorMessage = "Some other error";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.ServiceUnavailable,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<HttpRequestException>(
                () => service.UpdateTransactionsType(id, transactionsType, token)
            );

            Assert.IsTrue(exception.Message.Contains("Error: ServiceUnavailable"));
            Assert.IsTrue(exception.Message.Contains(errorMessage));
        }

        [TestMethod]
        public async Task DeleteTransactionsType_ReturnOk_ResponseIsSuccessful()
        {
            //arrange
            int id = 1;

            var responseContent = "Successfully updated";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act
            var result = await service.DeleteTransactionsType(id, token);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, responseContent);
        }

        [TestMethod]
        public async Task DeleteTransactionsType_ThrowInvalidOperationException_ResponseIsNotFound()
        {
            //arrange
            int id = 1;

            var errorMessage = "Not Found Transactions type";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                () => service.DeleteTransactionsType(id, token)
            );

            Assert.AreEqual(exception.Message, ($"Not Found: {errorMessage}"));
        }

        [TestMethod]
        public async Task DeleteTransactionsType_ThrowInvalidOperationException_ResponseIsBadRequest()
        {
            //arrange
            int id = 1;

            var errorMessage = "Transactions Type same wrong";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                () => service.DeleteTransactionsType(id, token)
            );

            Assert.AreEqual(exception.Message, ($"Bad Request: {errorMessage}"));
        }

        [TestMethod]
        public async Task DeleteTransactionsType_ThrowInvalidOperationException_ResponseIsInternalServerError()
        {
            //arrange
            int id = 1;

            var errorMessage = "Something went wrong while saving";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                () => service.DeleteTransactionsType(id, token)
            );

            Assert.AreEqual(exception.Message, ($"Internal Server Error: {errorMessage}"));
        }

        [TestMethod]
        public async Task DeleteTransactionsType_ThrowHttpRequestException_ResponseIsOtherError()
        {
            //arrange
            int id = 1;

            var errorMessage = "Some other error";
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.ServiceUnavailable,
                Content = new StringContent(errorMessage)
            };

            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            //act & assert
            var exception = await Assert.ThrowsExceptionAsync<HttpRequestException>(
                () => service.DeleteTransactionsType(id, token)
            );

            Assert.IsTrue(exception.Message.Contains("Error: ServiceUnavailable"));
            Assert.IsTrue(exception.Message.Contains(errorMessage));
        }
    }
}