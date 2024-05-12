using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("Tbl_Kategoriler")]
    public partial class TblKategoriler
    {
        public TblKategoriler()
        {
            TblUruns = new HashSet<TblUrun>();
        }
        [Key]
        public int KategoriId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? KategoriAd { get; set; }
        [InverseProperty("TblKategoriler")]

        public virtual ICollection<TblUrun> TblUruns { get; set; }

    }
}
