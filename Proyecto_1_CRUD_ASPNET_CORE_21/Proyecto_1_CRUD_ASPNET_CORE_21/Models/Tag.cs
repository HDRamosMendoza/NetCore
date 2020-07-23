using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_1_CRUD_ASPNET_CORE_21.Models
{
    public class Tag: BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
