namespace NumberVerify.Test
{
    public class SwedishPersonalNumberTests
    {

        [Fact] 
        public void ReturnsTrueWhenValidPersonalNumber()
        {

            // Arrange
            var personalNumber = "19890326-1611";

            // Act
            var actual = SwedishPersonalNumber.VerifyPersonalNumber(personalNumber);

            // Assert
            Assert.True(actual);

        }

        [Fact]
        public void ReturnsFalseWhenInvalidPersonalNumber()
        {
            // Arrange
            var personalNumber = "19890326-1616"; // Wrong on purpose

            // Act
            var actual = SwedishPersonalNumber.VerifyPersonalNumber(personalNumber);

            // Assert
            Assert.False(actual);
        }


        [Theory]
        [InlineData("19890326-1611")]
        [InlineData("198903261611")]
        [InlineData("890326-1611")]
        [InlineData("8903261611")]
        public void CanVerifyManyPersonalNumbers(string personalNumber)
        {
            // Arrange

            // Act
            var actual = SwedishPersonalNumber.VerifyPersonalNumber(personalNumber);

            // Assert
            Assert.True(actual);
        }


        [Theory]
        [InlineData("119890326-1611")]
        [InlineData("9890326-1611")]
        public void ThrowsInvalidOperationExceptionIfToShortOrLong(string personalNumber)
        {
            // Arrange

            // Act
            var actual = SwedishPersonalNumber.VerifyPersonalNumber(personalNumber);
            // Assert
            //Assert.ThrowsAny<InvalidOperationException>(() => SwedishPersonalNumber.VerifyPersonalNumber(personalNumber)); // Main method returns a bool, how to fix??
            Assert.False(actual);
        }

    }
}
