﻿using ApiDotNet6.Domain.Validadtions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiDotNet6.Domain.Entities
{
    public sealed class Purchase
    {
        public int Id { get; private set; }
        public int ProductID { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }

        public Person Person { get; set; }
        public Product Product { get; set; }

        public Purchase(int productId, int personId, DateTime? date)
        {
            Validation(productId, personId, date);
        }

        public Purchase(int id, int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(id < 0, "Id deve ser informado!");
            Id = id;
            Validation(productId, personId, date);
        }

        public void Validation(int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(productId < 0, "Id produto deve ser informado!");
            DomainValidationException.When(personId < 0, "Id pessoa deve ser informado!");
            DomainValidationException.When(date.HasValue, "Data da compra deve ser informada!");

            PersonId = personId;
            ProductID = productId;
            Date = date.Value;
        }
    }
}
