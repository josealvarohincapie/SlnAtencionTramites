namespace AtencionTramites.Model.ModelAtencionTramites
{
    using AtencionTramites.Model.Classes;
    using System;
    using System.Data.Entity;

    public partial class DbAtencionTramites : DbContext
    {
        private DbContextTransaction DatabaseTransaction { get; set; }

        public DbAtencionTramites()
            : base(new Variables().DbAtencionTramites)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;

            DatabaseTransaction = this.Database.BeginTransaction();
        }

        public void Commit()
        {
            DatabaseTransaction.Commit();
        }

        public void Rollback()
        {
            DatabaseTransaction.Rollback();
        }

        public void Close()
        {
            DatabaseTransaction.Dispose();
        }
    }
}