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
    public class GetLocationControllerTests
    {
        [Fact]
        public async Task GetLocations_ReturnsOkResult_WithLocations()
        {
            // Arrange
            var locations = new List<GetLocationCordinates>
            {
                new GetLocationCordinates 
                {
                    Id = new Guid("DEDAC644-D539-4F69-B1E1-3438904B0BBB"),
                    Options = "Shaping",
                    GetPoints = new List<GetPointsModel>
                    {
                        new GetPointsModel
                        {
                            ToolId = new Guid("1EA476F8-0188-49AF-9369-6A3A5AD3D11E"),
                            LocationName = "Pune",
                            Status ="Refurbished",
                            partsProduce="Parts 3",
                            Partsper1Stroke="30",
                            expectedUsefulLife="4 years",
                            regionName="East",
                            Location = new GetLocat
                             {
                               latitude= 18.52040m,
                               longitude = 73.85670m
                             }
                        }
                        
                    }
                },
                new GetLocationCordinates
                {
                    Id = new Guid("DEDAC644-D539-4F69-B1E1-3438904B0BBB"),
                    Options = "Shaping",
                    GetPoints = new List<GetPointsModel>
                    {
                        new GetPointsModel
                        {
                            ToolId = new Guid("1EA476F8-0188-49AF-9369-6A3A5AD3D11E"),
                            LocationName = "Pune",
                            Status ="Refurbished",
                            partsProduce="Parts 3",
                            Partsper1Stroke="30",
                            expectedUsefulLife="4 years",
                            regionName="East",
                            Location = new GetLocat
                             {
                               latitude= 18.52040m,
                               longitude = 73.85670m
                             }
                        }

                    }
                } 
            };

            var mockRepository = new Mock<IGetLocationRepository>();
            mockRepository.Setup(r => r.GetLocations()).ReturnsAsync(locations);

            var mockService = new Mock<IGetLocationService>();
            mockService.Setup(s => s.GetLocations()).ReturnsAsync(locations);

            var logger = new Mock<ILogger<GetLocationController>>();
            var controller = new GetLocationController(mockService.Object, logger.Object);

            // Act
            var result = await controller.GetLocations();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(locations, okResult.Value);
        }

        [Fact]
        public async Task GetLocations_ReturnsBadRequestResult_WithException()
        {
            // Arrange
            var exception = new Exception("Error getting locations");

            var mockRepository = new Mock<IGetLocationRepository>();
            mockRepository.Setup(r => r.GetLocations()).ThrowsAsync(exception);

            var mockService = new Mock<IGetLocationService>();
            mockService.Setup(s => s.GetLocations()).ThrowsAsync(exception);

            var logger = new Mock<ILogger<GetLocationController>>();
            var controller = new GetLocationController(mockService.Object, logger.Object);

            // Act
            var result = await controller.GetLocations();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(exception, badRequestResult.Value);
        }
    }
}
