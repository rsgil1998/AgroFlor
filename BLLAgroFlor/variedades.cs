//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BLLAgroFlor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class variedades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public variedades()
        {
            this.registro = new HashSet<registro>();
        }

        [ScaffoldColumn(false)]
        public int id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Nombre requerido"), MaxLength(150)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [DataType(DataType.Duration)]
        [Range(0, 10000, ErrorMessage = "Ingresa un número valido")]
        [Display(Name = "Total matas")]
        public int total_matas { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registro> registro { get; set; }
    }
}