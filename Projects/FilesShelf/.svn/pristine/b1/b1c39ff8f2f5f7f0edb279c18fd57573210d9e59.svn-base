using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesShelf.Models
{
    public enum GroupByType {ByTitleStartingLetter,ByAuthor,ByGenres};
    
    public class QueryRequest
    {
        #region Fields and Properties

        //search term string
        public string SearchTerm { get; set; }
        //search group by param
        public GroupByType GroupingType { get; set; }

        #endregion

        #region Methods

        //default constructor
        public QueryRequest(string searchTerm, GroupByType groupingType)
        {
            this.GroupingType = groupingType;
            this.SearchTerm = searchTerm;
        }

        #endregion

    }
}
