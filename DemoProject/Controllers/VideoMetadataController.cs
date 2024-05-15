using DemoProject.Brokers.Storages;
using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DemoProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoMetadataController : ControllerBase
    {
        private readonly IStorageBroker storageBroker;
        public VideoMetadataController(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
        [HttpPost(Name = "AddVideoMetadata")]
        public async Task<ActionResult<VideoMetadata>> AddAsync(VideoMetadata videoMetadata)
        {
            await this.storageBroker.InsertVideoMetadataAsync(videoMetadata);

            return Ok();
        }
    }
}
