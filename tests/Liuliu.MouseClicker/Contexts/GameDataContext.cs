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
            modelBuilder.Entity<EquipmentSuit>().ToTable("EquipmentSuits").HasKey(p => p.Id).HasRequired(t=>t.PlayerInfo)
                .WithMany(t=>t.EquipmentSuitList)
                .HasForeignKey(t=>t.PlayerInfoId)
                .WillCascadeOnDelete(false);
            Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<GameDataContext>(modelBuilder));
        }

        public virtual DbSet<PlayerInfo> PlayerInfos { get; set; }
        public virtual DbSet<EquipmentSuit> EquipmentSuits { get; set; }
    }
}
