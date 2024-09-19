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
    public class GetToolDetailsControllerTests
    {
        [Fact]
        public async Task GetToolDetail_ReturnsOkResult_WithToolDetails()
        {
            // Arrange
            var toolDetails = new List<ToolMaster>
            {
                new ToolMaster 
                { 
                    ToolID = new Guid("154D5DE6-F784-4B89-97C0-59B44A45251B"),
                    ToolName = "Drill 1" ,
                    ToolDescription="Drilling tool",
                    RegionID = new Guid("F32711E8-6099-4B08-BADE-6AC006654721"),
                    ToolCategoryID = new Guid("E89ABAEC-3EC6-41C9-B2EE-A27BD7C61BF9"),
                    PartsProduce = "Parts 1",
                    NumberofPartsPerStroke="10",
                    StrokeCount="100",
                    ExpectedUsefulLife="5 years",
                    ConditionID=new Guid("35D3EC69-E943-4766-8676-118BBED75FB4"),
                    ToolImage=null,
                    LocID=new Guid("402D5F71-1C63-42BF-AEE3-152F4C87A121")
                },
                new ToolMaster
                {
                    ToolID = new Guid("154D5DE6-F784-4B89-97C0-59B44A45251B"),
                    ToolName = "Drill 1" ,
                    ToolDescription="Drilling tool",
                    RegionID = new Guid("F32711E8-6099-4B08-BADE-6AC006654721"),
                    ToolCategoryID = new Guid("E89ABAEC-3EC6-41C9-B2EE-A27BD7C61BF9"),
                    PartsProduce = "Parts 1",
                    NumberofPartsPerStroke="10",
                    StrokeCount="100",
                    ExpectedUsefulLife="5 years",
                    ConditionID=new Guid("35D3EC69-E943-4766-8676-118BBED75FB4"),
                    ToolImage=null,
                    LocID=new Guid("402D5F71-1C63-42BF-AEE3-152F4C87A121")
                }
            };

            var mockRepository = new Mock<IGetToolDetailsRepository>();
            mockRepository.Setup(r => r.GetToolDetail()).ReturnsAsync(toolDetails);

            var mockService = new Mock<IGetToolDetailsService>();
            mockService.Setup(s => s.GetToolDetail()).ReturnsAsync(toolDetails);

            var logger = new Mock<ILogger<GetToolDetailsController>>();
            var controller = new GetToolDetailsController(mockService.Object, logger.Object);

            // Act
            var result = await controller.GetToolCategory();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(toolDetails, okResult.Value);
        }

        [Fact]
        public async Task GetToolDetail_ReturnsNoContentResult_WithNullResult()
        {
            // Arrange
            var mockRepository = new Mock<IGetToolDetailsRepository>();
            mockRepository.Setup(r => r.GetToolDetail()).ReturnsAsync((List<ToolMaster>)null);

            var mockService = new Mock<IGetToolDetailsService>();
            mockService.Setup(s => s.GetToolDetail()).ReturnsAsync((List<ToolMaster>)null);

            var logger = new Mock<ILogger<GetToolDetailsController>>();
            var controller = new GetToolDetailsController(mockService.Object, logger.Object);

            // Act
            var result = await controller.GetToolCategory();

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetToolDetail_ReturnsBadRequestResult_WithException()
        {
            // Arrange
            var exception = new Exception("Error retrieving tool details");

            var mockRepository = new Mock<IGetToolDetailsRepository>();
            mockRepository.Setup(r => r.GetToolDetail()).ThrowsAsync(exception);

            var mockService = new Mock<IGetToolDetailsService>();
            mockService.Setup(s => s.GetToolDetail()).ThrowsAsync(exception);

            var logger = new Mock<ILogger<GetToolDetailsController>>();
            var controller = new GetToolDetailsController(mockService.Object, logger.Object);

            // Act
            var result = await controller.GetToolCategory();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(exception.Message, badRequestResult.Value);
        }
    }
}




