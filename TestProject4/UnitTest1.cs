using Core_CodeFirst.Services;
using Core_CodeFirst.Services.IServices;
using Moq;

namespace TestProject4
{
    [TestClass]
    public class UnitTest1
    {

        // Life cycle

        // Arrange
        // Act
        // Assert 

        // MOQ >> 

        private Mock<IRepository> _mockRepository;
        private RespositoryService _respositoryService;

        [TestInitialize]
        public void Setup()
        {

            _mockRepository = new Mock<IRepository>();
            _respositoryService = new RespositoryService(_mockRepository.Object);
        }

        // 15

        [TestMethod]
        public void TestMethod1()
        {
            // Arrnage : 
            var expectedResult = "JIGAR";
            _mockRepository.Setup(r => r.GetData()).Returns("jigarss");


            //Act
            var result = _respositoryService.GetData();

            //Assert : Verify result
            Assert.AreEqual(expectedResult, result);

        }
    }
}