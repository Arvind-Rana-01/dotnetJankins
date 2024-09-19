using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToolMonitoringServices.Model;
using ToolMonitoringServices.Controllers;
using ToolMonitoringServices.Services;
using ToolMonitoringService.DataAccess.Repository;
using Microsoft.Extensions.Logging;
using ToolMonitoringService.Controllers;
using ToolMonitoringServices.DataAccess.Interface;

using System.Collections.Generic;


namespace ToolTesting
{
    public class GetCategoriesControllerTests
    {
        [Fact]
        public async Task GetCategory_ReturnsOkResult_WithCategories()
        {
            // Arrange
            var categories = new List<ToolCategories>
        {
            new ToolCategories 
            { ToolCategoryID =  new Guid("DEDAC644-D539-4F69-B1E1-3438904B0BBB"),
              ToolCategoryName = "Shaping",
              LocID = new Guid("402D5F71-1C63-42BF-AEE3-152F4C87A121")
            },
            new ToolCategories
            { ToolCategoryID =  new Guid("65FC8B22-F0F5-43B8-BE6C-E2BF4155AEAA"),
              ToolCategoryName = "Cutting",
              LocID = new Guid("0C8DB06E-9BD6-4C92-8AF6-49F8826AD169")
            }
        };

            var mockRepository = new Mock<IGetCategoriesRepository>();
            mockRepository.Setup(r => r.GetCategory()).ReturnsAsync(categories);

            var mockService = new Mock<IGetCategoriesService>();
            mockService.Setup(s => s.GetCategory()).ReturnsAsync(categories);

            var controller = new GetCategoriesController(mockService.Object, Mock.Of<ILogger<GetCategoriesController>>());

            // Act
            var result = await controller.GetCategory();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var categoriesResult = Assert.IsAssignableFrom<IEnumerable<ToolCategories>>(okResult.Value);
            Assert.Equal(categories, categoriesResult);
        }

        [Fact]
        public async Task GetCategory_ReturnsBadRequestResult_WhenExceptionOccurs()
        {
            // Arrange
            var mockRepository = new Mock<IGetCategoriesRepository>();
            mockRepository.Setup(r => r.GetCategory()).ThrowsAsync(new Exception("An error occurred while retrieving."));

            var mockService = new Mock<IGetCategoriesService>();
            mockService.Setup(s => s.GetCategory()).ThrowsAsync(new Exception("Error getting categories"));

            var controller = new GetCategoriesController(mockService.Object, Mock.Of<ILogger<GetCategoriesController>>());

            // Act
            var result = await controller.GetCategory();

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(badRequestResult.Value);
        }
    }
}









