using System.Linq;
using Catalog.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.DataAccess
{
    public static class CatalogDbContextInitializer
    {
        public static void Initialize(CatalogDbContext context)
        {
            RunMigrations(context);
            Seed(context);
        }

        private static void RunMigrations(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        private static void Seed(DbContext context)
        {
            if (!context.Set<Product>().Any())
            {
                var logitech = Brand.Create("Logitech");
                var keyboard = Product.Create("Keyboard", logitech);
                keyboard.AddImage(Image.Create("logitech_keyboard_01.png"));
                keyboard.AddComment(Comment.Create("Nice product!", "Seed"));

                var trust = Brand.Create("Trust");
                var webcam = Product.Create("Webcam", trust);
                webcam.AddImage(Image.Create("trust_webcam.png"));
                webcam.AddComment(Comment.Create("Nice product!", "Seed"));

                var razer = Brand.Create("Razer");
                var mouse = Product.Create("Mouse", razer);
                mouse.AddImage(Image.Create("razer_mouse.png"));
                mouse.AddComment(Comment.Create("Nice product!", "Seed"));

                context.Set<Product>().AddRange(keyboard, webcam, mouse);
            }

            context.SaveChanges();
        }
    }
}