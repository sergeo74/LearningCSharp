using AutoLotDAL.Models;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;


namespace AutoLotDAL.EF
{
    using System;
    using System.Data.Entity;

    public partial class AutoLotEntities : DbContext
    {
        static readonly DatabaseLogger DatabaseLogger =
            new DatabaseLogger("sqllog.txt", true);
        public AutoLotEntities() : base("name=AutoLotConnection")
        {
            //DbInterception.Add(new ConsoleWriterlnterceptor());
            DatabaseLogger.StartLogging();
            DbInterception.Add(DatabaseLogger);

            // Код перехватчика.
            var context = (this as IObjectContextAdapter).ObjectContext;
            context.ObjectMaterialized += OnObjectMaterialized;
            context.SavingChanges += OnSavingChanges;
        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Inventory)
                .WillCascadeOnDelete(false);
        }

        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(DatabaseLogger);
            DatabaseLogger.StopLogging();
            base.Dispose(disposing);
        }

        private void OnSavingChanges(object sender, EventArgs eventArgs)
        {
            // Параметр sender имеет тип ObjectContext.
            // Можно получать текущие и исходные значения,
            //а также отменять/модифицировать операцию
            // сохранения любым желаемым образом.
            var context = sender as ObjectContext;
            if (context == null) return;
            foreach (ObjectStateEntry item in
                context.ObjectStateManager.GetObjectStateEntries(
                    EntityState.Modified | EntityState.Added))
            {
                // Делать здесь что-то важное.
                if ((item.Entity as Inventory) != null)
                {
                    var entity = (Inventory)item.Entity;
                    if (entity.Color == "Red")
                    {
                        item.RejectPropertyChanges(nameof(entity.Color));
                    }
                }
            }
        }

        private void OnObjectMaterialized(object sender,
            System.Data.Entity.Core.Objects.ObjectMaterializedEventArgs e)
        {

        }
    }
}
