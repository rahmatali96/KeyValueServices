using System.ComponentModel.DataAnnotations;
namespace KeyValueServices.Models
{
    public class Key
    {
        [Key]
        public string key { get; set; }
        public string value { get; set; }
    }
}
