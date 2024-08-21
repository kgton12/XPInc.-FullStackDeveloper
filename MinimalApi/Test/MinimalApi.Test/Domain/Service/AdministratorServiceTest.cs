using Bogus;
using MinimalApi.Domain.Entity;
using MinimalApi.Domain.Enuns;
using MinimalApi.Domain.Services;
using MinimalApi.Test.DB;

namespace MinimalApi.Test.Domain.Service
{
    public class AdministratorServiceTest
    {
        [Fact]
        public async Task TestAdministrator()
        {
            // Arrange
            var faker = new Faker("pt_BR");
            var adm = new Administrator
            {
                Email = faker.Internet.Email(),
                Password = faker.Internet.Password(),
                Profile = faker.Random.Enum<Profile>().ToString(),
            };

            var context = DbContextTest.GetDbContextTest();

            var admService = new ServiceAdministrator(context);

            // Act
            await admService.Create(adm);
            var administrators = await admService.GetAll(1);
            var administrator = await admService.FindById(1);

            // Assert

            Assert.Single(administrators);

            Assert.NotNull(administrator);

            Assert.Equal(1, administrator.Id);
        }
    }
}
