using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitoringServices.Controllers;
using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Model;
using ToolMonitoringServices.Services;
using Xunit;


namespace ToolTesting
{
    public class GetToolCategoryCountControllerTests
    {
        [Fact]
        public async Task GetToolCategory_ReturnsOkResult_WithToolCategories()
        {
            // Arrange
            var toolCategories = new List<ToolCategories>
            {
                new ToolCategories 
                {
                    ToolCategoryID =new Guid("DEDAC644-D539-4F69-B1E1-3438904B0BBB"),
                    ToolCategoryName = "Shaping",
                    LocID=new Guid("F8EF0274-987E-449A-9777-175AC05570B6")
                },
                new ToolCategories
                {
                    ToolCategoryID =new Guid("EF9C827D-58FA-41C1-8CD8-8F31B66EB1D1"),
                    ToolCategoryName = "Finishing",
                    LocID=new Guid("BDE4BD58-1EEF-4F33-8620-607A3F60D6FC")
                }
            };

            var mockRepository = new Mock<IGetToolCategoryCountRepository>();
            mockRepository.Setup(r => r.GetToolCategory()).ReturnsAsync(toolCategories);

            var mockService = new Mock<IGetToolCategoryCountService>();
            mockService.Setup(s => s.GetToolCategory()).ReturnsAsync(toolCategories);

            var logger = new Mock<ILogger<GetToolCategoryCountController>>();
            var controller = new GetToolCategoryCountController(mockService.Object, logger.Object);

            // Act
            var result = await controller.GetToolCategory();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(toolCategories, okResult.Value);
        }

        [Fact]
        public async Task GetToolCategory_ReturnsNoContentResult_WithNullResult()
        {
            // Arrange
            var mockRepository = new Mock<IGetToolCategoryCountRepository>();
            mockRepository.Setup(r => r.GetToolCategory()).ReturnsAsync((List<ToolCategories>)null);

            var mockService = new Mock<IGetToolCategoryCountService>();
            mockService.Setup(s => s.GetToolCategory()).ReturnsAsync((List<ToolCategories>)null);

            var logger = new Mock<ILogger<GetToolCategoryCountController>>();
            var controller = new GetToolCategoryCountController(mockService.Object, logger.Object);

            // Act
            var result = await controller.GetToolCategory();

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetToolCategory_ReturnsBadRequestResult_WithException()
        {
            // Arrange
            var exception = new Exception("Error getting tool categories");

            var mockRepository = new Mock<IGetToolCategoryCountRepository>();
            mockRepository.Setup(r => r.GetToolCategory()).ThrowsAsync(exception);

            var mockService = new Mock<IGetToolCategoryCountService>();
            mockService.Setup(s => s.GetToolCategory()).ThrowsAsync(exception);

            var logger = new Mock<ILogger<GetToolCategoryCountController>>();
            var controller = new GetToolCategoryCountController(mockService.Object, logger.Object);

            // Act
            var result = await controller.GetToolCategory();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(exception.Message, badRequestResult.Value);
        }
    }
}


