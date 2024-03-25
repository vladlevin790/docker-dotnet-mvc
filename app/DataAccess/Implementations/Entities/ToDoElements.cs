using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using app.DataAccess.Implementations.Entities;

namespace app.DataAccess.Implementations.Entities
{

    [Table("to_do_element")]
    public class ToDoElement : BaseEntity
    {
        [Column("text")]
        public string Text {get; set;}

        [Column("completed")]
        public bool Completed {get; set;}

        public ToDoElement(string text){
            Id = 0;
            Text = text;
            Completed = false;
        }
    }
}