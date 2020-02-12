namespace webTask2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<webTask2.Models.TaskDataModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(webTask2.Models.TaskDataModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Users.Add(new Models.User() { ID = 1, Name = "hesham", UserName = "user", Password = "123" });
            context.Users.Add(new Models.User() { ID = 2, Name = "mohamed", UserName = "admin", Password = "123" });
            context.Users.Add(new Models.User() { ID = 3, Name = "ali", UserName = "guest", Password = "123" });

            context.SaveChanges();

        }
    }
}
