using System;

namespace AspnetCore.Healthchecks.Metrics.ApplicationServices.Dtos
{
    public class AddressQueryDto
    {
        public Guid Id { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public AddressQueryDto() { }

    }
}
