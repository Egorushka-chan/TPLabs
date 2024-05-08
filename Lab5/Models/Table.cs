using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class Table
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Наименование")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Тип")]
        public string Type { get; set; }
        [DisplayName("Кол-во столбцов")]
        public int CountCollums { get; set; }

        [DisplayName("Дата создания")]
        [DataType(DataType.Date)]
        public DateTime CreationTime { get; set; }

    }
}
