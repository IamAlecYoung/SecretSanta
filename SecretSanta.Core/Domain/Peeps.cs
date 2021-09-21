using System.ComponentModel.DataAnnotations;

namespace SecretSanta.Core.Domain
{
    public class Peeps
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string UniquePassword { get; set; }

        public string PictureLocation { get; set; }
        
        public bool ToPick { get; set; }
        public bool BeenPicked { get; set; }
        
        public bool WhatNo { get; set; }
        
    }
}
