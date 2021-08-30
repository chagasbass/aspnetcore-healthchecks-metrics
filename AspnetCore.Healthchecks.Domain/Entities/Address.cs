using System;

namespace AspnetCore.Healthchecks.Metrics.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        protected Address() { Id = Guid.NewGuid(); }

        public Address(string cep, string street, string district, string city, string state)
        {
            Id = Guid.NewGuid();
            CEP = cep;
            Street = street;
            District = district;
            City = city;
            State = state;
        }

    }
}
