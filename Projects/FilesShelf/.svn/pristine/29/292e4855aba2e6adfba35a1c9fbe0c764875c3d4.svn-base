using System;
using System.Collections.Generic;

namespace FilesShelf.Models
{
    public abstract class Media : IRenderable
    {
        public string PathName { get; set; }

        public string Title { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public decimal? UserRating { get; set; }        

        public DateTime? PublicationDate { get; set; }        

        public string Cover { get; set; }

        public string Thumbnail { get; set; }

        public string Description { get; set; }

        protected Media()
        {
            this.Genres = new List<Genre>();
            //TODO: Get file size;
        }

        public Media(string title, string coverUrl, decimal? userRating, DateTime? publicationDate, string description)
        {
            this.Title = title;
            this.Cover = coverUrl;
            this.UserRating = userRating;
            this.PublicationDate = publicationDate;
            this.Description = description;
            this.Genres = new List<Genre>();
            //TODO: Get file size;
        }


        public void Render()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
