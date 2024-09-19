//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ToolMonitoringServices.Controllers;
//using ToolMonitoringServices.DataAccess.Interface;
//using ToolMonitoringServices.Model;
//using ToolMonitoringServices.Services;
//using Xunit;


//namespace ToolTesting
//{
//    public class GetToolHierarchyControllerTests
//    {
//        [Fact]
//        public async Task GetHierarchy_ReturnsOkResult_WithHierarchyItems()
//        {
//            // Arrange
//            var hierarchyItems = new List<Node>
//            {
//                new Node 
//                { 
//                    Id = "1",
//                    Type = "input",
//                    Data = new NodeData 
//                    { 
//                        Label = "Insulted at which Suppliers",
//                        Condition = "place",
//                        Edges = new List<Edge>
//                        {
//                            new Edge
//                            {
//                                target = "3"
//                            }
//                        }
//                    } 
//                },
//                new Node
//                {
//                    Id = "1",
//                    Type = "input",
//                    Data = new NodeData
//                    {
//                        Label = "Insulted at which Suppliers",
//                        Condition = "place",
//                        Edges = new List<Edge>
//                        {
//                            new Edge
//                            {
//                                target = "3"
//                            }
//                        }
//                    }
//                },
//                new Node
//                {
//                    Id = "1",
//                    Type = "input",
//                    Data = new NodeData
//                    {
//                        Label = "Insulted at which Suppliers",
//                        Condition = "place",
//                        Edges = new List<Edge>
//                        {
//                            new Edge
//                            {
//                                target = "3"
//                            }
//                        }
//                    }
//                }
//            };

//            var mockRepository = new Mock<IGetToolHierarchyRepository>();
//            mockRepository.Setup(r => r.GetHierarchy()).ReturnsAsync(hierarchyItems);

//            var mockService = new Mock<IGetToolHierarchyService>();
//            mockService.Setup(s => s.GetHierarchy()).ReturnsAsync(hierarchyItems);

//            var logger = new Mock<ILogger<GetToolHierarchyController>>();
//            var controller = new GetToolHierarchyController(mockService.Object, logger.Object);

//            // Act
//            var result = await controller.GetHierarchy();

//            // Assert
//            Assert.IsType<OkObjectResult>(result);
//            var okResult = (OkObjectResult)result;
//            Assert.Equal(hierarchyItems, okResult.Value);
//        }

//        [Fact]
//        public async Task GetHierarchy_ReturnsNoContentResult_WithNullResult()
//        {
//            // Arrange
//            var mockRepository = new Mock<IGetToolHierarchyRepository>();
//            mockRepository.Setup(r => r.GetHierarchy()).ReturnsAsync((List<Node>)null);

//            var mockService = new Mock<IGetToolHierarchyService>();
//            mockService.Setup(s => s.GetHierarchy()).ReturnsAsync((List<Node>)null);

//            var logger = new Mock<ILogger<GetToolHierarchyController>>();
//            var controller = new GetToolHierarchyController(mockService.Object, logger.Object);

//            // Act
//            var result = await controller.GetHierarchy();

//            // Assert
//            Assert.IsType<NoContentResult>(result);
//        }

//        [Fact]
//        public async Task GetHierarchy_ReturnsBadRequestResult_WithException()
//        {
//            // Arrange
//            var exception = new Exception("Error while getting tool heirarchy");

//            var mockRepository = new Mock<IGetToolHierarchyRepository>();
//            mockRepository.Setup(r => r.GetHierarchy()).ThrowsAsync(exception);

//            var mockService = new Mock<IGetToolHierarchyService>();
//            mockService.Setup(s => s.GetHierarchy()).ThrowsAsync(exception);

//            var logger = new Mock<ILogger<GetToolHierarchyController>>();
//            var controller = new GetToolHierarchyController(mockService.Object, logger.Object);

//            // Act
//            var result = await controller.GetHierarchy();

//            // Assert
//            Assert.IsType<BadRequestObjectResult>(result);
//            var badRequestResult = (BadRequestObjectResult)result;
//            Assert.Equal(400, badRequestResult.StatusCode);
//        }
        
//    }
//}

