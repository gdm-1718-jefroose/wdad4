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
    public class ApplicationDbContextSeeder {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = serviceProvider.GetService<ApplicationDbContext>()) {

                // Create organisations
                if(!context.Organisations.Any()) {
                    context.Organisations.AddRange(new List<Organisation>()
                    {
                        new Organisation { Name = "De Biotoop", Description = "De Biotoop kindercrêche" }
                    });
                    await context.SaveChangesAsync();
                }

                // Create locations
                var organisation = context.Organisations.FirstOrDefault();
                var organisationId = organisation.Id;
                if(!context.Locations.Any()) {
                    context.Locations.AddRange(new List<Location>()
                    {
                        new Location { Name = "Begijnhoflaan 115", Description = "Begijnhoflaan 115", Street = "Begijnhoflaan", HouseNr = "115", PostalCode = "9000", City = "Gent", OrganisationId = organisationId },
                        new Location { Name = "Groot-Brittaniëlaan 72", Description = "Groot-Brittaniëlaan 72", Street = "Groot-Brittaniëlaan", HouseNr = "72", PostalCode = "9000", City = "Gent", OrganisationId = organisationId },
                        new Location { Name = "Groot-Brittanniëhof 120", Description = "Groot-Brittanniëhof 120", Street = "Groot-Brittanniëhof 120", HouseNr = "120", PostalCode = "9000", City = "Gent", OrganisationId = organisationId },
                        new Location { Name = "Groot-Brittanniëlaan 74", Description = "Groot-Brittanniëlaan 74", Street = "Groot-Brittanniëlaan", HouseNr = "74", PostalCode = "9000", City = "Gent", OrganisationId = organisationId },
                        new Location { Name = "Ham 187", Description = "Ham 187", Street = "Ham", HouseNr = "187", PostalCode = "9000", City = "Gent", OrganisationId = organisationId }
                    });
                    await context.SaveChangesAsync();
                }

                // Create groups
                var random = new Random();
                if(!context.Groups.Any()) 
                {
                    context.Groups.AddRange(new List<Group>()
                    {
                        new Group { Name = "De Konijntjes", Description = "De Konijntjes", LocationId = random.Next(1, 5) },
                        new Group { Name = "De Dolfijntje", Description = "De Dolfijntje",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Hondjes", Description = "De Hondjes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Visjes", Description = "De Visjes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Zebratjes", Description = "De Zebratjes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Paardjes", Description = "De Paardjes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Schaapjes", Description = "De Schaapjes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Vogeltjes", Description = "De Vogeltjes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Pauwkes", Description = "De Pauwkes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Salamanderkes", Description = "De Salamanderkes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Katjes", Description = "De Katjes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Slangetjes", Description = "De Slangetjes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Bijtjes", Description = "De Bijtjes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Vleermuisjes", Description = "De Vleermuisjes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Biggetjes", Description = "De Biggetjes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Muisjes", Description = "De Muisjes",  LocationId = random.Next(1, 5) },
                        new Group { Name = "De Sprinkhaantjes", Description = "De Sprinkhaantjes",  LocationId = random.Next(1, 5) }
                    });
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