using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Collections.Generic;

namespace FilesShelf.Models
{
    public abstract class MediaLibrary : IFilterable, ISortable, IRenderable
    {

        //private List<Media> mediaList = new List<Media>();

        //public List<Media> MediaList
        //{
        //    get { return mediaList; }
        //    set { mediaList = value; }
        //}        

        public MediaLibrary()
        {
            this.CreateMediaLibrary();
        }

        public abstract void CreateMediaLibrary();

        //this method makes a query to the API
        protected static string GetApiResponse(string url)
        {
            string response;

            using (var client = new WebClient())
            {
                response = client.DownloadString(url);
            }

            return response;
        }

        protected static void Merge<T>(T source, T extended)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.GetValue(source) == null || prop.GetValue(source) is ICollection && (prop.GetValue(source) as ICollection).Count == 0)
                {
                    prop.SetValue(source, prop.GetValue(extended));
                }
            }
        }

        public void GetDataForSerialization()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public virtual void FilterBy()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public virtual void Render()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public virtual void SortBy()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public virtual void LoadInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}
