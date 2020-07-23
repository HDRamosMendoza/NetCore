using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_1_CRUD_ASPNET_CORE_21.Models
{
    public class Video:BaseEntity
    {
        [Required]
        public string Title { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public string Url { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
        
        /* List Tag */
        public List<Tag> Tags { get; set; }

        /* Ejemplo de mensajes */
        /*
         * [Required(ErrorMessage = "Required")]
         * [Range(1,999,ErrorMessage = "Range")]
         * public int Clave { get; set;}
         * 
         * [Required(ErrorMessage = "Required")]
         * [Column(TypeName= "VARCHAR(80)")]
         * public int Clave { get; set;}  
        */
    }
}
