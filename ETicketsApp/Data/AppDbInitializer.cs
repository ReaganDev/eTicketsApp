﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicketsApp.Data.Enum;
using ETicketsApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ETicketsApp.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //CINEMA
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();
                }

                // ACTORS
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Name = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            Name = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 3",
                            Bio = "This is the Bio of the third actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 4",
                            Bio = "This is the Bio of the fourth actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 5",
                            Bio = "This is the Bio of the fifth actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                // PRODUCERS
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            Name = "Producer 1",
                            Bio = "This is the Bio of the first producer",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            Name = "Producer 2",
                            Bio = "This is the Bio of the second producer",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 3",
                            Bio = "This is the Bio of the third producer",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 4",
                            Bio = "This is the Bio of the fourth producer",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 5",
                            Bio = "This is the Bio of the fifth producer",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                // MOVIES
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            MovieUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            Category = Category.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            MovieUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            Category = Category.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            MovieUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            Category = Category.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            MovieUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            Category = Category.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            MovieUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            Category = Category.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            MovieUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            Category = Category.Drama
                        }
                    });
                    context.SaveChanges();
                }

                // ACTORS & MOVIES
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRole.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
                }

                if (!await roleManager.RoleExistsAsync(UserRole.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRole.User));
                }

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var adminUser = await userManager.FindByEmailAsync("Admin@etickets.com");
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        FullName = "Admin",
                        UserName = "Admin",
                        Email = "Admin@etickets.com",
                        EmailConfirmed = true
                    };

                    var a = await userManager.CreateAsync(newAdminUser, "Admin95%");
                    if (a.Succeeded)
                    {

                    }
                    await userManager.AddToRoleAsync(newAdminUser, UserRole.Admin);
                }

                var appUser = await userManager.FindByEmailAsync("Pearl@etickets.com");
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        FullName = "Peace Bassey",
                        UserName = "Pearl95",
                        Email = "Pearl@etickets.com",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newAppUser, "Pearl95%");
                    await userManager.AddToRoleAsync(newAppUser, UserRole.User);
                }
            }
        }
    }
}
