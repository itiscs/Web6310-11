using FirstApi;
using FirstApi.Controllers;

namespace TestToDoProject
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestWeatherGet()
        {
            //Arrange
            WeatherForecastController controller = new WeatherForecastController(null);

            //Act
            var result = controller.Get();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<WeatherForecast>));
            Assert.AreEqual(5, result.Count());
        }
    }
}
