using Liuliu.MouseClicker.Models.Entities;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Contexts
{
    public class GameDataContext:DbContext
    {
        public GameDataContext():base("GameDataConnectionString")
        {
           // Database.SetInitializer<GameDataContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<PlayerInfo>().ToTable("PlayerInfos").HasKey(p => p.Id);
           
            Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<GameDataContext>(modelBuilder));
        }

        public virtual DbSet<PlayerInfo> PlayerInfos { get; set; }
     
    }
}
