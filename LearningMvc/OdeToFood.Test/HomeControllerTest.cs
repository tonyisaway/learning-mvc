using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Controllers;
using System.Web.Mvc;

namespace OdeToFood.Test
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void About()
        {
            // Arrange
            using (HomeController controller = new HomeController())
            {
                // Act
                ViewResult result = controller.About() as ViewResult;

                // Assert
                Assert.IsNotNull(result.Model);
            }
        }
    }
}
