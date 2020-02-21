using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExampleCRUD.Domain.Entities
{
    public class User: Person
    {
        public User()
        {

        }
        private string addressZipCode;

        public string Email { get; set; }
        public string AddressStreet { get; set; }
        public string AddressNumber { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZipCode { 
            get => addressZipCode; 
            set => addressZipCode = Regex.Replace(value, @"[):;.,'=-]", ""); 
        }
    }
}
