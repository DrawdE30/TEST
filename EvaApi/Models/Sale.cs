using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EvaApi.Models
{
    public partial class Sale
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int IdProducto { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Cantidad { get; set; }

        [ForeignKey(nameof(IdProducto))]

        public virtual Producto Producto { get; set; }
    }
}

/*
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EvaApi.Models
{
    public partial class Sale
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int IdProducto { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Cantidad { get; set; }

        [ForeignKey(nameof(IdProducto))]
        [InverseProperty(nameof(Producto.Sales))]

        public virtual Producto IdProductoNavigation { get; set; }
    }
}
*/