using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.DataModel
{
    public class BaseTable
    {
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
    }
}
