using System.ComponentModel.DataAnnotations.Schema;

namespace SecretSanta.Core.Domain
{   
    [Table("whopickedwho")]
    public class whopickedwho
    {
        public int Person1 { get; set; }
        public int Person2 { get; set; }
        public string Year { get; set; }
    }
}
