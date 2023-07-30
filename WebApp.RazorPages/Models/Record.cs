using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.RazorPages.Models
{
    public class Record
    {
        public int Id { get; set; }

        [Required,
            StringLength(30, MinimumLength = 2),
            RegularExpression(@"[a-zA-Z0-9\-!()?\s]{2,}")]
        public string Title { get; set; } = default!;

        [Required,
            StringLength(30, MinimumLength = 2),
            RegularExpression(@"[a-zA-Z0-9\-!]{2,}"),
            Display(Name = "Performer Name")]
        public string PerformerName { get; set; } = default!;

        [Required,
            StringLength(15, MinimumLength = 3),
            RegularExpression(@"^[A-Z]{1}[a-z]{2,}\s{0,1}[a-zA-Z]*$")]
        public string Genre { get; set; } = default!;

        [DataType(DataType.Time),
            DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:mm\\:ss}")]
        public TimeSpan Duration { get; set; }

        [Precision(18, 2), Range(0, 300)]
        public decimal Price { get; set; }
    }
}
