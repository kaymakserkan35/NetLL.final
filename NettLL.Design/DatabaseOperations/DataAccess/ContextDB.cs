using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NettLL.Design.DatabaseOperations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.DataAccess
{
    internal class ContextDB : DbContext
    {
        static ContextDB singletonInstance=null;
        public ContextDB()
        {
            
        }

        public static ContextDB getSingleton()
        {
            if (singletonInstance == null) singletonInstance = new ContextDB();
            return singletonInstance;
        }
        public ContextDB(DbContextOptions<ContextDB> options) :
            base(options)
        { }

        public virtual DbSet<UserMoiveWord> UserMoiveWord { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Moive> Moive { get; set; }
        public virtual DbSet<MoiveWord> MoiveWord { get; set; }
        public virtual DbSet<Sound> Sound { get; set; }
        public virtual DbSet<Word> Word { get; set; }
        public virtual DbSet<WordCategory> WordCategory { get; set; }
        public virtual DbSet<WordSound> WordSound { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string url = Options.pathDatabase;
            string ConnectionString = new SqliteConnectionStringBuilder()
            {
                DataSource = url,
                ForeignKeys = true

            }.ConnectionString;
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(connectionString: ConnectionString);
            }
        }


    }
}
