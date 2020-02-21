using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExampleCRUD.Domain.Entities
{
    public abstract class Person : EntityBase
    {
        private string cpfCnpj;
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public string CpfCnpj
        {
            get => cpfCnpj; set => cpfCnpj = Regex.Replace(value, @"[):;.,'=-]", "");
        }

    }
}
