using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace website.Model
{


    

    public class GiethoornAgendaActivity
    {
        public bool IsEvenement { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string DateString { get; set; }
        public string LongDescription { get; set; }
        public DateTime EndDate { get; set; }
        public string ShortDescription { get; set; }
        public int ActivityId { get; set; }
        public int LocationId { get; set; }
        public string Location { get; set; }
        public string Adres { get; set; }
        public string Phone { get; set; }
        public string LocationLargeImageCleanUrl { get; set; }
        public string LocationSmallImageCleanUrl { get; set; }
        public string LargeImageCleanUrl { get; set; }
        public string SmallImageCleanUrl { get; set; }
        public int CategoryId { get; set; }
        public string LargeImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
        public int MaandJaar { get; set; }
        public string DateToLongString { get; set; }
        public IList<object> SubActivities { get; set; }
        public string ArticleLink { get; set; }
        public string GetLoangDateText()
        {
            var nlCulture = new CultureInfo("nl-NL");
            return string.Format(nlCulture.DateTimeFormat, "{0:D}", this.Date);

        }
    }
}
