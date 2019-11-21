namespace WebLibera.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LiberaModel : DbContext
    {
        public LiberaModel()
            : base("name=LiberaModel")
        {
            Database.SetInitializer<LiberaModel
                >(null);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<AnsweredQuestions> FAQ { get; set; }


     
    }
}