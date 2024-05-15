using DemoProject.Models;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.SqlServer;

namespace DemoProject.Brokers.Storages
{
    internal partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        public DbSet<VideoMetadata> VideoMetadatas { get; set; }
        public ValueTask<VideoMetadata> DeleteVideoMetadataAsync(VideoMetadata videoMetadata)
        {
            throw new NotImplementedException();
        }

        public ValueTask<VideoMetadata> InsertVideoMetadataAsync(VideoMetadata videoMetadata)
        {
            throw new NotImplementedException();
        }

        public IQueryable<VideoMetadata> SelectAllVideoMetadatas()
        {
            throw new NotImplementedException();
        }

        public ValueTask<VideoMetadata> SelectVideoMetadataByIdAsync(Guid videoMetadataId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<VideoMetadata> UpdateVideoMetadataAsync(VideoMetadata videoMetadata)
        {
            throw new NotImplementedException();
        }
    }
}
