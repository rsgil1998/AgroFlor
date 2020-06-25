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

    public partial class config
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public config()
        {
            this.floricola = new HashSet<floricola>();
        }

        [ScaffoldColumn(false)]
        public int id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Medidas requeridas"), MaxLength(150)]
        [Display(Name = "Medidas")]
        public string medidas { get; set; }

        [DataType(DataType.Duration)]
        [Range(10, 50, ErrorMessage = "Ingrese un número de tallos correcto")]
        [Display(Name = "Número de tallos por bonche")]
        public int tallos_bonche { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<floricola> floricola { get; set; }
    }
}