using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace FilesShelf.Models
{
    public class MoviesLibrary : MediaLibrary
    {
       
        public override void CreateMediaLibrary()
        {
            throw new NotImplementedException();
        }

        public static Movie CreateMovie(string title)
        {
            var movie = new Movie { Title = title };

            var apis = new Action<Movie>[]
            {   
                ExtendUsingOmdb,
                ExtendUsingMyMovie,
                
            };

            foreach (var action in apis)
            {
                try
                {
                    action(movie);

                    if (!(String.IsNullOrEmpty(movie.Title)))
                    {
                        break;
                    }
                }
                catch (WebException) { }
            }


            return movie;
        }

        private static void ExtendUsingOmdb(Movie movie)
        {
            var response = GetApiResponse(string.Format("http://www.omdbapi.com/?t={0}&r=json&plot=full&tomatoes=true", movie.Title));

            if (response.Contains("False"))
            {
                return;
            }

            dynamic parsed = JsonConvert.DeserializeObject(response);

            var newMovie = new Movie();

            try { newMovie.Title = parsed.Title; }
            catch (RuntimeBinderException) { }
            try { newMovie.Cover = parsed.Poster; }
            catch (RuntimeBinderException) { }
            try { newMovie.PublicationDate = parsed.Released; }
            catch (RuntimeBinderException) { }
            catch (FormatException) { }
            try { newMovie.Description = parsed.Plot; }
            catch (RuntimeBinderException) { }
            try { newMovie.Runtime = parsed.Runtime; }
            catch (RuntimeBinderException) { }
            try { newMovie.ImdbRating = decimal.Parse(parsed.imdbRating); }
            catch (RuntimeBinderException) { }
            try { newMovie.NumberofVotes = long.Parse(parsed.imdbVotes); }
            catch (RuntimeBinderException) { }
            catch (FormatException) { }
            string actors = parsed.Actors;
            List<string> actorsList = new List<string>(actors.Split(new[] { ", " }, StringSplitOptions.None));
            string genres = parsed.Genre;
            List<string> genresList = new List<string>(genres.Split(new[] { ", " }, StringSplitOptions.None));
            string directors = parsed.Director;
            List<string> directorsList = new List<string>(directors.Split(new[] { ", " }, StringSplitOptions.None));
            string writers = parsed.Writer;
            List<string> writersList = new List<string>(writers.Split(new[] { ", " }, StringSplitOptions.None));
            try
            {
                foreach (var actor in actorsList)
                {
                    newMovie.Actors.Add(new Person { FullName = actor });
                }
            }
            catch (RuntimeBinderException) { }
            catch (NullReferenceException) { }

            try
            {
                foreach (var genre in genresList)
                {
                    newMovie.Genres.Add(new Genre { Name = genre });
                }
            }
            catch (RuntimeBinderException) { }
            catch (NullReferenceException) { }

            try
            {
                foreach (var director in directorsList)
                {
                    newMovie.Actors.Add(new Person { FullName = director });
                }
            }
            catch (RuntimeBinderException) { }
            catch (NullReferenceException) { }

            try
            {
                foreach (var writer in writersList)
                {
                    newMovie.Actors.Add(new Person { FullName = writer });
                }
            }
            catch (RuntimeBinderException) { }
            catch (NullReferenceException) { }


            Merge(movie, newMovie);
        }

        private static void ExtendUsingMyMovie(Movie movie)
        {

            var response = GetApiResponse(string.Format("http://mymovieapi.com/?title={0}&type=xml&plot=full&episode=1&limit=1&yg=0&mt=none&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0", movie.Title));


            if (response.Contains("Film not found"))
            {
                return;
            }

            if (response.Contains("Parameter was invalid"))
            {
                return;
            }

            var result = XDocument.Parse(response);

            var root = result.Element("IMDBDocumentList").Element("item");
            var title = root.Element("title").Value;
            var type = root.Element("type").Value;
            var coverUrl = root.Element("poster").Element("cover").Value;
            DateTime? releaseDate = null;
            var imdbRating = root.Element("rating").Value;
            var numberOfVotes = root.Element("rating_count").Value;
            var plot = root.Element("plot").Value;
            //var runtime = root.Element("runtime").Element("item").Value;
            var actors = root.Element("actors").Elements("item");
            var genres = root.Element("genres").Elements("item");


            var newMovie = new Movie
            {
                Title = title,
                Cover = coverUrl,
                ImdbRating = decimal.Parse(imdbRating),
                NumberofVotes = long.Parse(numberOfVotes),
                Description = plot,
            };

            if (type == "M")
            {
                releaseDate = DateTime.ParseExact(root.Element("release_date").Value, "yyyyMMdd", new CultureInfo("bg-BG"));
                var directors = root.Element("directors").Elements("item");
                var writers = root.Element("writers").Elements("item");
                foreach (var director in directors)
                {
                    newMovie.Directors.Add(new Person { FullName = director.Value });
                }

                foreach (var writer in writers)
                {
                    newMovie.Writers.Add(new Person { FullName = writer.Value });
                }
            }

            foreach (var actor in actors)
            {
                newMovie.Actors.Add(new Person { FullName = actor.Value });
            }


            foreach (var genre in genres)
            {
                newMovie.Genres.Add(new Genre { Name = genre.Value });
            }

            newMovie.PublicationDate = releaseDate;

            Merge(movie, newMovie);

        }

        public void RemoveMovie()
        {
            throw new System.NotImplementedException();
        }

    }
}
