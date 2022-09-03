using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.DataBase.Entities
{
    public class DALObject
    {
        [Key]
        public int Id { get; set; }
    }
}
