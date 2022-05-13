using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EvaApi.Models
{
    [Table("Producto")]
    public partial class Producto
    {
        public Producto()
        {
            Sale = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Nombre { get; set; }
        [StringLength(10)]
        public string Unidad { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Precio { get; set; }

        public virtual ICollection<Sale> Sale { get; set; }
    }
}
/*
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EvaApi.Models
{
    [Table("Producto")]
    public partial class Producto
    {
        public Producto()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Nombre { get; set; }
        [StringLength(10)]
        public string Unidad { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Precio { get; set; }

        [InverseProperty(nameof(Sale.IdProductoNavigation))]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
*/