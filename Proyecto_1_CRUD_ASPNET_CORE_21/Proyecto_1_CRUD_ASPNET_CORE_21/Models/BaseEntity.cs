using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_1_CRUD_ASPNET_CORE_21.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime UpdateDate { get; set; }
    }
}