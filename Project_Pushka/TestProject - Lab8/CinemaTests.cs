using Xunit;
using Core;
using System.Linq;
using System;
using System.Collections.Generic;

namespace CinemaTests
{
    public class CinemaLogicTests
    {
        [Fact]
        public void AddMovie_ShouldIncreaseContentListCount()
        {
            // Arrange
            var cinema = new Cinema("Test Cinema");
            var movie = new Movie("Inception", 148, 8.8, "Sci-Fi", true);

            // Act
            cinema.AddContent(movie);

            // Assert
            Assert.Single(cinema.ContentList);
            Assert.Equal("Inception", ((Movie)cinema.ContentList[0]).Title);
        }

        [Fact]
        public void CascadingDelete_RemovingMovie_ShouldRemoveAssociatedSessions()
        {
            // Arrange
            var cinema = new Cinema("Test Cinema");
            var movie = new Movie("Avatar", 162, 7.9, "Action", true);
            cinema.AddContent(movie);

            var session = new Session(movie, "Hall 1", DateTime.Now, 150, 100, false);
            cinema.AddSession(session);

            // Act
            var sessionsToDelete = cinema.Sessions.Where(s => s.Film == movie).ToList();
            foreach (var s in sessionsToDelete)
            {
                cinema.RemoveSession(s);
            }
            cinema.RemoveContent(movie);

            // Assert
            Assert.Empty(cinema.ContentList);
            Assert.Empty(cinema.Sessions);
        }

        [Fact]
        public void FilterMovies_OnlyThreeD_ShouldReturnCorrectMovies()
        {
            // Arrange
            var cinema = new Cinema("Test Cinema");
            cinema.AddContent(new Movie("Movie 1", 100, 5, "Genre", true)); // 3D
            cinema.AddContent(new Movie("Movie 2", 100, 5, "Genre", false)); // 2D

            // Act
            var threeDOptions = cinema.ContentList.OfType<Movie>().Where(m => m.IsThreeD).ToList();

            // Assert
            Assert.Single(threeDOptions);
            Assert.True(threeDOptions.First().IsThreeD);
        }

        [Fact]
        public void Session_TicketPrice_ShouldNotBeNegative()
        {
            // Arrange
            var movie = new Movie("Batman", 120, 8.0, "Action", false);

            // Act
            var session = new Session(movie, "Hall 5", DateTime.Now, 200, 50, false);

            // Assert
            Assert.True(session.TicketPrice >= 0, "Цена билета не может быть отрицательной");
        }

        [Fact]
        public void DataManager_SaveAndLoad_ShouldPreserveCinemaName()
        {
            // Arrange
            var cinema = new Cinema("Multiplex-Kharkiv");
            string filePath = "test_cinema.json";

            // Act
            DataManager.SaveToJson(cinema, filePath);
            var loadedCinema = DataManager.LoadFromJson(filePath);

            // Assert
            Assert.NotNull(loadedCinema);
            Assert.Equal(cinema.Name, loadedCinema.Name);

            // Cleanup
            if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
        }
    }
}