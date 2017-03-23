using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookModel.Models
{
    public class ComicBook
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public int IssueNumber { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; }

        public Series Series { get; set; }

        public string DisplayText
        {
            get
            {
                return $"{Series?.Title} #{IssueNumber}";
            }
        }
    }
}
