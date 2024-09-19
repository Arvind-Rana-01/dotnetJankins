using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToolMonitoringServices.Controllers;
using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Model;
using ToolMonitoringServices.Services;

namespace ToolTesting
{
        public class GetRegionsControllerTests
        {
            [Fact]
            public async Task GetRegion_ReturnsOkResult_WithRegions()
            {
                // Arrange
                var regions = new List<Region>
            {
                new Region 
                {
                    RegionID = new Guid("F32711E8-6099-4B08-BADE-6AC006654721"),
                    RegionName = "South"
                },
                new Region
                {
                    RegionID = new Guid("F93D86C1-E45A-49DC-BE2D-8204CA442222"),
                    RegionName = "East"
                }
            };

                var mockRepository = new Mock<IGetRegionsRepository>();
                mockRepository.Setup(r => r.GetRegion()).ReturnsAsync(regions);

                var mockService = new Mock<IGetRegionsService>();
                mockService.Setup(s => s.GetRegion()).ReturnsAsync(regions);

                var logger = new Mock<ILogger<GetRegionsController>>();
                var controller = new GetRegionsController(mockService.Object, logger.Object);

                // Act
                var result = await controller.GetRegion();

                // Assert
                Assert.IsType<OkObjectResult>(result);
                var okResult = (OkObjectResult)result;
                Assert.Equal(regions, okResult.Value);
            }

            [Fact]
            public async Task GetRegion_ReturnsBadRequestResult_WithException()
            {
                // Arrange
                var exception = new Exception("Error getting regions");

                var mockRepository = new Mock<IGetRegionsRepository>();
                mockRepository.Setup(r => r.GetRegion()).ThrowsAsync(exception);

                var mockService = new Mock<IGetRegionsService>();
                mockService.Setup(s => s.GetRegion()).ThrowsAsync(exception);

                var logger = new Mock<ILogger<GetRegionsController>>();
                var controller = new GetRegionsController(mockService.Object, logger.Object);

                // Act
                var result = await controller.GetRegion();

                // Assert
                Assert.IsType<BadRequestObjectResult>(result);
                var badRequestResult = (BadRequestObjectResult)result;
                Assert.Equal(exception, badRequestResult.Value);
            }
        }
}

