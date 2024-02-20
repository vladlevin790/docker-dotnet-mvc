using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.DataAccess.Contracts;

namespace app.DataAccess.Implementations.Entities
{
    public class BaseEntity:IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}