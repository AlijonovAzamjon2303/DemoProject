using DemoProject.Models;

namespace DemoProject.Brokers.Storages
{
    public interface IStorageBroker
    {
        VideoMetadata Insert(VideoMetadata metadata);
    }
}
