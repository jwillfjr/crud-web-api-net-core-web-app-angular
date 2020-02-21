using System;

namespace ExampleCRUD.Infra.Data.EFMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EFMigrationDbContext())
            {
                db.SaveChanges();
            }
        }
    }
}
