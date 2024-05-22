using DemoProject.Models;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.SqlServer;

namespace DemoProject.Brokers.Storages
{
    internal partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;
        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = this.configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseSqlServer(connectionString);
        }
        private async ValueTask<T> InsertAsync<T>(T @object) where T : class
        {
            this.Entry<T>(@object).State = EntityState.Added;
            await this.SaveChangesAsync();

            return @object;
        }
        private  IQueryable<T> SelectAll<T>() where T : class
        => this.Set<T>();
        private async ValueTask<T> SelectAsync<T>(params object[] objectsIds) where T : class
        => await this.FindAsync<T>(objectsIds);
        private async ValueTask<T> UpdateAsync<T>(T @object) where T : class
        {
            this.Entry(@object).State = EntityState.Modified;
            await this.SaveChangesAsync();

            return @object;
        }
        private async ValueTask<T> DeleteAsync<T>(T @object) where T : class
        {
            this.Entry(@object).State = EntityState.Deleted;
            await this.SaveChangesAsync();

            return @object;
        }
    }
}
