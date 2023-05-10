using ApiDotNet6.Domain.Validadtions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }

        public Person(string document, string name, string phone)
        {
            Validadtion(document, name, phone);
        }

        public Person(int id, string document, string name, string phone)
        {
            DomainValidationException.When(id < 0, "Id Inváilido!");
            Id = id;
            Validadtion(document, name, phone);
        }

        private void Validadtion(string document, string name, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Documento deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Celular deve ser informado!");

            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}
