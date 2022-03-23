using NUnit.Framework;
using LiveNation.WebAPI.DataProcessing;

namespace LiveNation.WebAPI.UnitTests
{
    public class DataProcessingUnitTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_ProcessNumberRange_ReturnsCorrectResultFromGoodInput()
        {
            //Arrange
            int startRange = 1;
            int endRange = 20;
            LiveNationNumberRangeProcessor liveNationNumberRangeProcessor = new LiveNationNumberRangeProcessor();

            //Act
            var returnValue = liveNationNumberRangeProcessor.ProcessNumberRange(startRange, endRange);

            //Assert
            Assert.AreEqual(returnValue.Result, "1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation 16 17 Live 19 Nation");
        }

        [Test]
        public void Test_ProcessNumberRange_ReturnsCorrectSummaryLiveValueFromGoodInput()
        {
            //Arrange
            int startRange = 1;
            int endRange = 20;
            LiveNationNumberRangeProcessor liveNationNumberRangeProcessor = new LiveNationNumberRangeProcessor();

            //Act
            var returnValue = liveNationNumberRangeProcessor.ProcessNumberRange(startRange, endRange);

            //Assert
            Assert.AreEqual(returnValue.Summary.Live, "5");
        }

        [Test]
        public void Test_ProcessNumberRange_ReturnsCorrectSummaryNationValueFromGoodInput()
        {
            //Arrange
            int startRange = 1;
            int endRange = 20;
            LiveNationNumberRangeProcessor liveNationNumberRangeProcessor = new LiveNationNumberRangeProcessor();

            //Act
            var returnValue = liveNationNumberRangeProcessor.ProcessNumberRange(startRange, endRange);

            //Assert
            Assert.AreEqual(returnValue.Summary.Nation, "3");
        }

        [Test]
        public void Test_ProcessNumberRange_ReturnsCorrectSummaryLiveNationValueFromGoodInput()
        {
            //Arrange
            int startRange = 1;
            int endRange = 20;
            LiveNationNumberRangeProcessor liveNationNumberRangeProcessor = new LiveNationNumberRangeProcessor();

            //Act
            var returnValue = liveNationNumberRangeProcessor.ProcessNumberRange(startRange, endRange);

            //Assert
            Assert.AreEqual(returnValue.Summary.LiveNation, "1");
        }

        [Test]
        public void Test_ProcessNumberRange_ReturnsCorrectSummaryIntegerValueFromGoodInput()
        {
            //Arrange
            int startRange = 1;
            int endRange = 20;
            LiveNationNumberRangeProcessor liveNationNumberRangeProcessor = new LiveNationNumberRangeProcessor();

            //Act
            var returnValue = liveNationNumberRangeProcessor.ProcessNumberRange(startRange, endRange);

            //Assert
            Assert.AreEqual(returnValue.Summary.Integer, "11");
        }
    }
}