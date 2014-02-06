using System;
using System.Collections.Generic;
using System.Linq;

namespace FilesShelf.Models
{
    public class Movie : Media
    {
        public IList<Person> Directors { get; set; }

        public IList<Person> Writers { get; set; }

        public IList<Person> Actors { get; set; }

        public decimal? ImdbRating { get; set; }

        public long? NumberofVotes { get; set; }

        public string Runtime { get; set; }

        public Movie()
        {
            this.Directors = new List<Person>();
            this.Writers = new List<Person>();
            this.Actors = new List<Person>();
        }

        public override string ToString()
        {
            var info = new List<string>();

            info.Add("Title: " + this.Title);
            info.Add("Cover url: " + this.Cover);
            info.Add("Director/s: " + string.Concat(this.Directors.Select(x => Environment.NewLine + "  " + x)));
            info.Add("Writer/s: " + string.Concat(this.Writers.Select(x => Environment.NewLine + "  " + x)));
            info.Add("Actors: " + string.Concat(this.Actors.Select(x => Environment.NewLine + "  " + x)));
            var releaseDate = this.PublicationDate;
            if (releaseDate != null)
            {
                info.Add("Publish date: " + releaseDate.Value.ToString("dd MMMM yyyy"));
            }
            info.Add(String.Format("IMDB Rating: {0} from {1} users ", this.ImdbRating.GetValueOrDefault(), this.NumberofVotes));
            info.Add("Genres: " + string.Concat(this.Genres.Select(x => Environment.NewLine + "  " + x)));
            info.Add("Description: " + this.Description);
            info.Add("Runtime: " + this.Runtime);

            return string.Join(Environment.NewLine, info);
        }
    }
}
