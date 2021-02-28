using AutoSell.Data.Enumerations.ItemStatus;
using System.Linq;
using Xunit;

namespace AutoSell.Tests.Data.Enumerations
{
    public class ItemStatusTypeTests
    {
        [Fact]
        public void GetAll_ShouldReturnMoreThanZero()
        {
            // Arrange

            // Act
            var actual = ItemStatusType.GetAll<ItemStatusType>();

            // Assert
            Assert.True(actual.Count() > 0);
        }

        [Fact]
        public void Equals_ShouldReturnEqual()
        {
            // Arrange
            ItemStatusType objectA = ItemStatusType.Available;
            ItemStatusType objectB = ItemStatusType.Available;

            // Act
            var actual = objectA.Equals(objectB);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void Equals_ShouldReturnNotEqual()
        {
            // Arrange
            ItemStatusType objectA = ItemStatusType.Available;
            ItemStatusType objectB = ItemStatusType.NotAvailable;

            // Act
            var actual = objectA.Equals(objectB);

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void CompareTo_ShouldReturnLessThanZero()
        {
            // Arrange
            ItemStatusType objectA = ItemStatusType.Available;
            ItemStatusType objectB = ItemStatusType.NotAvailable;

            // Act
            int actual = objectA.CompareTo(objectB);

            // Assert
            Assert.True(actual < 0);
        }

        [Fact]
        public void CompareTo_ShouldReturnZero()
        {
            // Arrange
            ItemStatusType objectA = ItemStatusType.Sold;
            ItemStatusType objectB = ItemStatusType.Sold;

            // Act
            int actual = objectA.CompareTo(objectB);

            // Assert
            Assert.Equal(0, 0);
        }

        [Fact]
        public void CompareTo_ShouldReturnMoreThanZero()
        {
            // Arrange
            ItemStatusType objectA = ItemStatusType.NotAvailable;
            ItemStatusType objectB = ItemStatusType.Available;

            // Act
            int actual = objectA.CompareTo(objectB);

            // Assert
            Assert.True(actual > 0);
        }
    }
}
