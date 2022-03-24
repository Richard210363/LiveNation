using NUnit.Framework;
using Moq;
using LiveNation.WebAPI.Controllers;
using LiveNation.WebAPI.DataProcessing;
using LiveNation.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveNation.WebAPI.UnitTests
{
    public class NumberRangeProcessingControllerUnitTests
    {
        //Arrange
        int startRange = 1;
        int endRange = 15;
        Mock<INumberRangeProcessor> mockNumberRangeProcessor = new Mock<INumberRangeProcessor>();

        [SetUp]
        public void Setup()
        {

            //Use incorrect result data to tell it apart from the real NumberRangeProcessor
            NumberRangeProcessingResultSummery numberRangeProcessingResultSummery = new NumberRangeProcessingResultSummery
            {
                Live = "1",
                Nation = "2",
                LiveNation = "3",
                Integer = "4"
            };

            NumberRangeProcessingResult numberRangeProcessingResult = new NumberRangeProcessingResult
            {
                Result = "Live Nation LiveNation 200",
                Summary = numberRangeProcessingResultSummery
            };


            mockNumberRangeProcessor.Setup(p => p.ProcessNumberRange(startRange, endRange))
                .Returns(numberRangeProcessingResult);

        }

        [Test]
        public void Test_Get_ReturnsResultInCorrectFormat()
        {
            NumberRangeProcessingController numberRangeProcessingController = new NumberRangeProcessingController(mockNumberRangeProcessor.Object);

            //Act
            var objectResult = numberRangeProcessingController.Get(startRange, endRange) as OkObjectResult;
            var objectResultValue = objectResult.Value as NumberRangeProcessingResult;
            
            //Assert
            Assert.AreEqual(objectResultValue.Result, "Live Nation LiveNation 200");
        }

        [Test]
        public void Test_Get_ReturnsSummaryInCorrectFormat()
        {
            NumberRangeProcessingController numberRangeProcessingController = new NumberRangeProcessingController(mockNumberRangeProcessor.Object);

            //Act
            var objectResult = numberRangeProcessingController.Get(startRange, endRange) as OkObjectResult;
            var objectResultValue = objectResult.Value as NumberRangeProcessingResult;

            //Assert
            Assert.AreEqual(objectResultValue.Summary.Live, "1");
            Assert.AreEqual(objectResultValue.Summary.Nation, "2");
            Assert.AreEqual(objectResultValue.Summary.LiveNation, "3");
            Assert.AreEqual(objectResultValue.Summary.Integer, "4");
        }
    }
}