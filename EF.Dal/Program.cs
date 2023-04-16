// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

EF.Dal.EfStructures.ApplicationDbContext context = new EF.Dal.EfStructures.ApplicationDbContextFactory().CreateDbContext(null);
context.SaveChanges();