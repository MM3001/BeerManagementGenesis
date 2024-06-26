using BeerManagement.Business;
using BeerManagement.Domain;
using BeerManagement.IDatabase;
using Moq;

namespace BeerManagement.UnitTest
{
    public class WholeSalerTest
    {
        [Fact]
        public async Task GetOffer_WholeSaler_NotExistError()
        {
            // Arrange
            Mock<IWholesalerDL> mock = new();

            mock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Wholesaler?>(null));

            WholesalerBL wholeSalerBL = new(mock.Object);


            // Act
            var result = await Assert.ThrowsAsync<Exception>(async () => await wholeSalerBL.GetOfferAsync(Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41"), null));

            // Assert
            Assert.Equal("Wholeseller Doesn't exist !", result.Message);
        }

        [Fact]
        public async Task GetOffer_WholeSaler_AtLeastOneBeerOrderedError()
        {
            // Arrange
            Wholesaler wholesaler = new() { Id = Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41") };
            Mock<IWholesalerDL> mock = new();

            mock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Wholesaler?>(wholesaler));

            WholesalerBL wholeSalerBL = new(mock.Object);


            // Act
            var result = await Assert.ThrowsAsync<Exception>(async () => await wholeSalerBL.GetOfferAsync(Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41"), null));

            // Assert
            Assert.Equal("At least one beer should be ordered !", result.Message);
        }

        [Fact]
        public async Task GetOffer_WholeSaler_BeerFoundMultipleTimesError()
        {
            // Arrange
            Wholesaler wholesaler = new Wholesaler() { Id = Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41") };

            List<RequestOrderBeer> requestOrderBeers = [
                    new RequestOrderBeer() { BeerId = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Quantity = 3 },
                    new RequestOrderBeer() { BeerId = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Quantity = 3 }
                ];
            Mock<IWholesalerDL> mock = new();

            mock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Wholesaler?>(wholesaler));

            WholesalerBL wholeSalerBL = new(mock.Object);


            // Act
            var result = await Assert.ThrowsAsync<Exception>(async () => await wholeSalerBL.GetOfferAsync(Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41"), requestOrderBeers));

            // Assert
            Assert.Equal("Beer found multiple times !", result.Message);
        }

        [Fact]
        public async Task GetOffer_WholeSaler_BeernotSoldError()
        {
            // Arrange
            List<WholesalerStock> wholesalerStocks = new();
            Wholesaler wholesaler = new() { Id = Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41"), WholesalerStocks = wholesalerStocks };
            List<RequestOrderBeer> requestOrderBeers = new() {
                    new RequestOrderBeer() { BeerId = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Quantity = 3 }
                };

            Mock<IWholesalerDL> mock = new();

            mock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Wholesaler?>(wholesaler));

            WholesalerBL wholeSalerBL = new WholesalerBL(mock.Object);


            // Act
            var result = await Assert.ThrowsAsync<Exception>(async () => await wholeSalerBL.GetOfferAsync(Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41"), requestOrderBeers));

            // Assert
            Assert.Equal("Some beer not sold by wholeseller !", result.Message);
        }

        [Fact]
        public async Task GetOffer_WholeSaler_NotEnoughBeerAvailableError()
        {
            // Arrange
            List<WholesalerStock> wholesalerStocks = [
                new WholesalerStock() { BeerId = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Quantity = 2}
            ];

            Wholesaler wholesaler = new() { Id = Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41"), WholesalerStocks = wholesalerStocks };

            List<RequestOrderBeer> requestOrderBeers = [
                    new RequestOrderBeer() { BeerId = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Quantity = 3 }
                ];

            Mock<IWholesalerDL> mock = new();
            mock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Wholesaler?>(wholesaler));

            WholesalerBL wholeSalerBL = new(mock.Object);

            // Act
            var result = await Assert.ThrowsAsync<Exception>(async () => await wholeSalerBL.GetOfferAsync(Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41"), requestOrderBeers));

            // Assert
            Assert.Equal("Not enough beer availeble for this wholesaler !", result.Message);
        }

        [Fact]
        public async Task GetOffer_WholeSaler_OfferWithoutReduction()
        {
            // Arrange
            Beer beer = new Beer() { Id = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Price = 2 };

            List<WholesalerStock> wholesalerStocks = [
                new WholesalerStock() { BeerId = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Quantity = 25, Beer = beer}
            ];

            Wholesaler wholesaler = new() { Id = Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41"), WholesalerStocks = wholesalerStocks };

            List<RequestOrderBeer> requestOrderBeers = [
                    new RequestOrderBeer() { BeerId = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Quantity = 3 }
                ];

            Mock<IWholesalerDL> mock = new();
            mock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Wholesaler?>(wholesaler));

            WholesalerBL wholeSalerBL = new(mock.Object);

            // Act
            var result = await wholeSalerBL.GetOfferAsync(Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41"), requestOrderBeers);

            // Assert
            Assert.Equal(6, result.TotalAmount);
        }

        [Fact]
        public async Task GetOffer_WholeSaler_OfferWithTenPercentReduction()
        {
            // Arrange
            Beer beer = new Beer() { Id = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Price = 2 };

            List<WholesalerStock> wholesalerStocks = [
                new WholesalerStock() { BeerId = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Quantity = 25, Beer = beer}
            ];

            Wholesaler wholesaler = new() { Id = Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41"), WholesalerStocks = wholesalerStocks };

            List<RequestOrderBeer> requestOrderBeers = [
                    new RequestOrderBeer() { BeerId = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Quantity = 10 }
                ];

            Mock<IWholesalerDL> mock = new();
            mock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Wholesaler?>(wholesaler));

            WholesalerBL wholeSalerBL = new(mock.Object);

            // Act
            var result = await wholeSalerBL.GetOfferAsync(Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41"), requestOrderBeers);

            // Assert
            Assert.Equal(18, result.TotalAmount);
        }

        [Fact]
        public async Task GetOffer_WholeSaler_OfferWithTwentyPercentReduction()
        {
            // Arrange
            Beer beer = new Beer() { Id = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Price = 2 };

            List<WholesalerStock> wholesalerStocks = [
                new WholesalerStock() { BeerId = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Quantity = 25, Beer = beer}
            ];

            Wholesaler wholesaler = new() { Id = Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41"), WholesalerStocks = wholesalerStocks };

            List<RequestOrderBeer> requestOrderBeers = [
                    new RequestOrderBeer() { BeerId = Guid.Parse("6d596d7c-658e-4fa4-ad73-53e8a2925463"), Quantity = 20 }
                ];

            Mock<IWholesalerDL> mock = new();
            mock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Wholesaler?>(wholesaler));

            WholesalerBL wholeSalerBL = new(mock.Object);

            // Act
            var result = await wholeSalerBL.GetOfferAsync(Guid.Parse("550ee50f-bf64-4d0f-b740-f379e2f9aa41"), requestOrderBeers);

            // Assert
            Assert.Equal(32, result.TotalAmount);
        }
    }
}