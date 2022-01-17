using System;
using System.ComponentModel.DataAnnotations;

namespace VirtualEntityODataSource.Data.Entities.Base
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
