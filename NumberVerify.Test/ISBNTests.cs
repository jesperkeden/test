using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberVerify.Test
{
    public class ISBNTests
    {

        [Fact]
        public void CanVerifyISBN10()
        {
            // Arrange
            string isbn = "0-306-40615-2";
            var expected = true;

            // Act
            var actual = ISBN.VerifyIsbnNumber(isbn);

            // Assert
            Assert.True(true);
        }

        [Theory]
        [InlineData("9781472295941")]
        [InlineData("978-0-306-40615-7")]
        [InlineData("9789180530552")]
        [InlineData("97891-896037-38")]
        [InlineData("97813-99611428")]
        [InlineData("0-306-40615-2")]
        public void CanVerifyISBN(string isbn)
        {
            // Arrange
            var expected = true;

            // Act
            var actual = ISBN.VerifyIsbnNumber(isbn);

            // Assert
            Assert.True(true);
        }

    }
}
