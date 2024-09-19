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
    public class GetToolListControllerTests
    { 
        [Fact]
        public async Task GetTools_ReturnsOkResult_WithTools()
        {
            // Arrange
            var tools = new List<ToolViewModel>
            {
                new ToolViewModel 
                {
                    ToolCategoryID = new Guid("E89ABAEC-3EC6-41C9-B2EE-A27BD7C61BF9"),
                    RegionID = new Guid("F32711E8-6099-4B08-BADE-6AC006654721"),
                    RegionName = "South",
                    ToolCategoryName = "Drilling",
                    id = new Guid("154D5DE6-F784-4B89-97C0-59B44A45251B"),
                    ToolName = "Drill 1",
                    PartsProduce ="Parts 1",
                    ExpectedUsefulLife = "5 years",
                    ToolImage = null,
                    NumberofPartsPerStroke = "10",
                    StrokeCount = "100", 
                },
                new ToolViewModel
                {
                    ToolCategoryID = new Guid("E89ABAEC-3EC6-41C9-B2EE-A27BD7C61BF9"),
                    RegionID = new Guid("F32711E8-6099-4B08-BADE-6AC006654721"),
                    RegionName = "South",
                    ToolCategoryName = "Drilling",
                    id = new Guid("154D5DE6-F784-4B89-97C0-59B44A45251B"),
                    ToolName = "Drill 1",
                    PartsProduce ="Parts 1",
                    ExpectedUsefulLife = "5 years",
                    ToolImage = null,
                    NumberofPartsPerStroke = "10",
                    StrokeCount = "100",
                }
            };

            var mockRepository = new Mock<IGetToolListRepository>();
            mockRepository.Setup(r => r.GetTools(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
               .ReturnsAsync(tools);

            var mockService = new Mock<IGetToolListService>();
            mockService.Setup(s => s.GetTools(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
               .ReturnsAsync(tools);

            var logger = new Mock<ILogger<GetToolListController>>();

            var controller = new GetToolListController(mockService.Object, logger.Object);

            // Act
            var result = await controller.GetTools();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(tools, okResult.Value);
        }

        [Fact]
        public async Task GetTools_ReturnsNoContentResult_WhenNoToolsFound()
        {
            // Arrange
            var mockRepository = new Mock<IGetToolListRepository>();
            mockRepository.Setup(r => r.GetTools(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
               .ReturnsAsync((List<ToolViewModel>)null);

            var mockService = new Mock<IGetToolListService>();
            mockService.Setup(s => s.GetTools(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
               .ReturnsAsync((List<ToolViewModel>)null);

            var logger = new Mock<ILogger<GetToolListController>>();

            var controller = new GetToolListController(mockService.Object, logger.Object);

            // Act
            var result = await controller.GetTools();

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetTools_ReturnsBadRequestResult_WhenExceptionOccurs()
        {
            // Arrange
            var exception = new Exception("Error retrieving tool list");

            var mockRepository = new Mock<IGetToolListRepository>();
            mockRepository.Setup(r => r.GetTools(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
               .ThrowsAsync(exception);

            var mockService = new Mock<IGetToolListService>();
            mockService.Setup(s => s.GetTools(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
               .ThrowsAsync(exception);

            var logger = new Mock<ILogger<GetToolListController>>();

            var controller = new GetToolListController(mockService.Object, logger.Object);

            // Act
            var result = await controller.GetTools();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(exception, badRequestResult.Value);
        }
    }
}




