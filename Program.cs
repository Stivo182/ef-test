// See https://aka.ms/new-console-template for more information
using ef_test;

Console.WriteLine("Hello, World!");

ApplicationDbContext context = new ApplicationDbContextFactory().CreateDbContext(null);
context.SaveChanges();