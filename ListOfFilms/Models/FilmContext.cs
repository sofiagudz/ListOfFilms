using Microsoft.EntityFrameworkCore;
namespace ListOfFilms   
{
    public class FilmContext:DbContext
    {
        public DbSet<Film> Films { get; set; }
        public FilmContext(DbContextOptions<FilmContext> options)
            : base(options) 
        {
            if (Database.EnsureCreated())
            {
                Films.Add(new Film
                {
                    Name = "Valerian and the City of a Thousand Planets",
                    Director = "Luc Besson",
                    Genre = "Sci-fi/Action",
                    Year = 2017,
                    Poster = "~/img/Valerian and the City of a Thousand Planets.jpg",
                    Description = "Valerian and Laureline, two special operatives for the space station of Alpha, " +
                    "have to protect the city from an evil force that threatens not only its existence, but the future " +
                    "of the universe."
                });
                Films.Add(new Film
                {
                    Name = "The Devil Wears Prada",
                    Director = "David Frankel",
                    Genre = "Comedy/Drama",
                    Year = 2006,
                    Poster = "~/img/The Devil Wears Prada.jpg",
                    Description = "Andy, a young graduate aspiring to be a journalist, comes to New York and becomes an " +
                    "assistant to one of the city's biggest magazine editors, the ruthless and cynical Miranda Priestly."
                });
                Films.Add(new Film
                {
                    Name = "The Wolf of Wall Street",
                    Director = "Martin Scorsese",
                    Genre = "Drama/Crime",
                    Year = 2013,
                    Poster = "~/img/The Wolf of Wall Street.jpg",
                    Description = "Introduced to life in the fast lane through stockbroking, Jordan Belfort takes" +
                    " a hit after a Wall Street crash. He teams up with Donnie Azoff, cheating his way to the top as " +
                    "his relationships slide."
                });
                Films.Add(new Film
                {
                    Name = "Kingsman: The Secret Service",
                    Director = "Matthew Vaughn",
                    Genre = "Action/Comedy",
                    Year = 2014,
                    Poster = "~/img/Kingsman The Secret Service.jpg",
                    Description = "Gary 'Eggsy' Unwin faces several challenges when he gets recruited as a secret " +
                    "agent in a secret spy organisation in order to look for Richmond Valentine, an eco-terrorist."
                });
                Films.Add(new Film
                {
                    Name = "Enola Holmes",
                    Director = "Harry Bradbeer",
                    Genre = "Mystery/Crime",
                    Year = 2020,
                    Poster = "~/img/Enola Holmes.jpg",
                    Description = "While searching for her missing mother, intrepid teen Enola Holmes " +
                    "uses her sleuthing skills to outsmart big brother Sherlock and help a runaway lord."
                });
                Films.Add(new Film
                {
                    Name = "Purple Hearts",
                    Director = "Elizabeth Allen Rosenbaum",
                    Genre = "Musical romance",
                    Year = 2022,
                    Poster = "~/img/Purple Hearts.jpg",
                    Description = "Cassie, a struggling singer-songwriter agrees to marry a troubled " +
                    "Marine, Luke for military benefits. The line between real and pretend begins to blur."
                });
                Films.Add(new Film
                {
                    Name = "The Hunger Games",
                    Director = "Gary Ross",
                    Genre = "Action/Sci-fi",
                    Year = 2012,
                    Poster = "~/img/The Hunger Games.jpg",
                    Description = "Katniss volunteers to replace her sister in a tournament that " +
                    "ends only when one participant remains. Pitted against contestants who have trained for " +
                    "this all their life, she has little to rely on."
                });
                Films.Add(new Film
                {
                    Name = "Avengers: Endgame",
                    Director = "Anthony Russo, Joe Russo",
                    Genre = "Action/Sci-fi",
                    Year = 2019,
                    Poster = "~/img/Avengers Endgame.jpg",
                    Description = "After Thanos, an intergalactic warlord, disintegrates half of the universe, " +
                    "the Avengers must reunite and assemble again to reinvigorate their trounced allies and restore balance."
                });
                Films.Add(new Film
                {
                    Name = "The Social Network",
                    Director = "David Fincher",
                    Genre = "Drama/Historical drama",
                    Year = 2010,
                    Poster = "~/img/The Social Network.png",
                    Description = "Mark Zuckerberg creates a social networking site, Facebook, with his friend Eduardo's " +
                    "help. Though it turns out to be a successful venture, he severs ties with several people along the way."
                });
                Films.Add(new Film
                {
                    Name = "Sharper",
                    Director = "Benjamin Caron",
                    Genre = "Crime/Drama",
                    Year = 2023,
                    Poster = "~/img/Sharper.jpg",
                    Description = "Motivations are suspect, and expectations are turned upside down, as a con artist " +
                    "takes on Manhattan billionaires."
                });
                SaveChanges();
            }
        }
    }
}
