using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EvaApi.Models
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [MaxLength(10, ErrorMessage = "El usuario es maximo 10 caracteres.")]
        public string NomUs { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "La password es obligatorio.")]
        [MinLength(8, ErrorMessage = "La password es minimo 8 caracteres.")]
        public string Pass { get; set; }
        
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
