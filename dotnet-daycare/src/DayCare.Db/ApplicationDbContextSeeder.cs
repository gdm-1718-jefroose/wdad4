using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions;
using DayCare.Models;
using DayCare.Models.Security;

namespace DayCare.Db
{
    public class ApplicationDbContextSeeder 
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = serviceProvider.GetService<ApplicationDbContext>()) 
            {
                // Random instance
                var random = new Random();

                // Organisation
                if (!context.Organisations.Any())
                {
                    context.Organisations.AddRange(new List<Organisation>()
                    {
                        new Organisation { Name = "De Biotoop", Description = "De Biotoop" }
                    });
                    await context.SaveChangesAsync();
                }

                // Locations
                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(new List<Location>()
                    {
                        new Location { Name = "Begijnhoflaan 115", Description = "Begijnhoflaan 115", Street = "Begijnhoflaan", HouseNr = "115", PostalCode = "9000", City = "Gent", OrganisationId = 1 },
                        new Location { Name = "Groot-Brittaniëlaan 72", Description = "Groot-Brittaniëlaan 72", Street = "Groot-Brittaniëlaan", HouseNr = "72", PostalCode = "9000", City = "Gent", OrganisationId = 1 },
                        new Location { Name = "Groot-Brittanniëhof 120", Description = "Groot-Brittanniëhof 120", Street = "Groot-Brittanniëhof 120", HouseNr = "120", PostalCode = "9000", City = "Gent", OrganisationId = 1 },
                        new Location { Name = "Groot-Brittanniëlaan 74", Description = "Groot-Brittanniëlaan 74", Street = "Groot-Brittanniëlaan", HouseNr = "74", PostalCode = "9000", City = "Gent", OrganisationId = 1 },
                        new Location { Name = "Ham 187", Description = "Ham 187", Street = "Ham", HouseNr = "187", PostalCode = "9000", City = "Gent", OrganisationId = 1 }
                    });
                    await context.SaveChangesAsync();
                }

                // Groups
                if (!context.Groups.Any())
                {
                    context.Groups.AddRange(new List<Group>()
                    {
                        new Group { Name = "De Konijntjes", Description = "De Konijntjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Dolfijntje", Description = "De Dolfijntje", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Hondjes", Description = "De Hondjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Visjes", Description = "De Visjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Zebratjes", Description = "De Zebratjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Paardjes", Description = "De Paardjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Schaapjes", Description = "De Schaapjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Vogeltjes", Description = "De Vogeltjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Pauwkes", Description = "De Pauwkes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Salamanderkes", Description = "De Salamanderkes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Katjes", Description = "De Katjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Slangetjes", Description = "De Slangetjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Bijtjes", Description = "De Bijtjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Vleermuisjes", Description = "De Vleermuisjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Biggetjes", Description = "De Biggetjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Muisjes", Description = "De Muisjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) },
                        new Group { Name = "De Sprinkhaantjes", Description = "De Sprinkhaantjes", MinCapacity = (short) random.Next(4, 8), MaxCapacity = (short) random.Next(12, 18), LocationId = random.Next(1, 5) }
                    });
                    await context.SaveChangesAsync();
                }

                // Bogus Data https://www.nuget.org/packages/Bogus/
                // It's like faker in JavaScript, PHP and Ruby
                // ------------------------------------------------

                // Generate Persons
                if(!context.Persons.Any()) 
                {
                    var childrenAmount = random.Next(100, 240);

                    // Parents
                    var parentSkeleton = new Faker<DayCare.Models.Parent>()
                        .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                        .RuleFor(u => u.SurName, f => f.Name.LastName())
                        .RuleFor(u => u.DayOfBirth, f => GenerateDateTime(1970, 1987, 1, 13, 1, 32))
                        .RuleFor(u => u.Gender, f => f.PickRandom<GenderType>())
                        .RuleFor(u => u.MartialStatus, f => f.PickRandom<MartialStatusType>())
                        .FinishWith((f, u) =>
                        {
                            Console.WriteLine("User Created! Id={0}", u.Id);
                        });
                        
                    var parents = new List<DayCare.Models.Parent>();
                    for(var i = 0;i<childrenAmount*2;i++) {
                        var parent = parentSkeleton.Generate();
                        parents.Add(parent);
                    }
                    context.Persons.AddRange(parents);
                    await context.SaveChangesAsync();

                    // Children
                    var childSkeleton = new Faker<DayCare.Models.Child>()
                        .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                        .RuleFor(u => u.SurName, f => f.Name.LastName())
                        .RuleFor(u => u.DayOfBirth, f => GenerateDateTime(2013, 2016, 1, 13, 1, 32))
                        .RuleFor(u => u.Gender, f => f.PickRandom<GenderType>())
                        .FinishWith((f, u) =>
                        {
                            Console.WriteLine("Child Created! Id={0}", u.Id);
                        });

                    var children = new List<DayCare.Models.Child>();
                    for(var i = 0;i<childrenAmount;i++) {
                        var child = childSkeleton.Generate();
                        children.Add(child);
                    }
                    context.Persons.AddRange(children);
                    await context.SaveChangesAsync();
                }

                if(!context.Categories.Any()) 
                {
                    var lorem = new Bogus.DataSets.Lorem(locale: "nl");
                    var categorySkeleton = new Faker<DayCare.Models.Category>()
                        .RuleFor(c => c.Name, f => lorem.Word())
                        .RuleFor(c => c.Description, f => String.Join(" ", lorem.Words(5)))
                        .FinishWith((f, u) =>
                        {
                            Console.WriteLine("Category created with Bogus: {0}!", u.Name);
                        });
                    
                    var categories = new List<Category>();

                    for(var i = 0; i < 10;i++)
                    {
                        var category = categorySkeleton.Generate();
                        categories.Add(category);
                    }

                    context.Categories.AddRange(categories);
                    await context.SaveChangesAsync();
                }

                if(!context.Tags.Any()) 
                {
                    var lorem = new Bogus.DataSets.Lorem(locale: "nl");
                    var tagSkeleton = new Faker<DayCare.Models.Tag>()
                        .RuleFor(c => c.Name, f => lorem.Word())
                        .RuleFor(c => c.Description, f => String.Join(" ", lorem.Words(3)))
                        .FinishWith((f, u) =>
                        {
                            Console.WriteLine("Tag created with Bogus: {0}!", u.Name);
                        });
                    
                    var tags = new List<Tag>();

                    for(var i = 0; i < 10;i++)
                    {
                        var tag = tagSkeleton.Generate();
                        tags.Add(tag);
                    }

                    context.Tags.AddRange(tags);
                    await context.SaveChangesAsync();
                }

                if(!context.Posts.Any()) 
                {
                    var lorem = new Bogus.DataSets.Lorem(locale: "nl");
                    var postSkeleton = new Faker<DayCare.Models.Post>()
                        .RuleFor(c => c.Name, f => lorem.Word())
                        .RuleFor(c => c.Description, f => String.Join(" ", lorem.Words(5)))
                        .RuleFor(c => c.Body, f => lorem.Paragraphs(random.Next(5, 15)))
                        .FinishWith((f, u) =>
                        {
                            Console.WriteLine("Post created with Bogus: {0}!", u.Name);
                        });
                    
                    var posts = new List<Post>();
                    var categories = context.Categories.ToList();

                    for(var i = 0; i < 10;i++)
                    {
                        var post = postSkeleton.Generate();
                        post.CategoryId = categories[random.Next(categories.Count - 1)].Id;
                        posts.Add(post);
                    }

                    context.Posts.AddRange(posts);
                    await context.SaveChangesAsync();
                }
            }
        }

        private static DateTime GenerateDateTime(int yFrom, int yTo, int mFrom, int mTo, int dFrom, int dTo) {
            var random = new Random();
            try
            {
                return new DateTime(random.Next(yFrom, yTo), random.Next(mFrom, mTo), random.Next(dFrom, dTo));
            }
            catch(Exception ex) {
                return GenerateDateTime(yFrom, yTo, mFrom, mTo, dFrom, dTo);
            }
        }
    }
}