using System.ComponentModel.DataAnnotations;

namespace SecretSanta.Core.Domain
{
    public class Peeps
    {
        [Key]
        public int ID { get; set; }
        public string Year { get; set; }
        public string name { get; set; }
        public string pic { get; set; }
        
        public bool picking { get; set; }
        public bool picked { get; set; }
        public string uniquePass { get; set; }
        
        public bool WhatNo { get; set; }
        
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string postcode { get; set; }
        
        public string extra { get; set; }
        public string creepy { get; set; }
        public string consent { get; set; }
        
    }
}
