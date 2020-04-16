using System;
using System.Threading.Tasks;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Test
{
    public class TennisPlayerControllerTest
    {
        [Fact]
        public async Task GetPlayerById_WhenPlayerIdIsZero_ShouldReturnBadRequest()
        {
            var playerServiceMock =  new Mock<IPlayerService>();
            
            var controller = new TennisPlayerController(playerServiceMock.Object);
            
            var result = await controller.GetPlayerById(0);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetPlayerById_WhenPlayerIdIsNotFound_ShouldReturnNotFound()
        {
            var playerServiceMock =  new Mock<IPlayerService>();
            playerServiceMock.Setup(e => e.GetAllPlayers()).ReturnsAsync(
                new System.Collections.Generic.List<Player> { 
                    new Player
                    {
                        id = 123
                    }
                }
            );
            var controller = new TennisPlayerController(playerServiceMock.Object);
            
            var result = await controller.GetPlayerById(13);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetPlayerById_WhenPlayerIdIsFound_ShouldBeHappyPath()
        {
            var playerServiceMock =  new Mock<IPlayerService>();
            playerServiceMock.Setup(e => e.GetAllPlayers()).ReturnsAsync(
                new System.Collections.Generic.List<Player> { 
                    new Player
                    {
                        id = 123
                    }
                }
            );
            var controller = new TennisPlayerController(playerServiceMock.Object);
            
            var result = await controller.GetPlayerById(123);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
