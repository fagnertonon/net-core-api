using DGuard.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace DGuard.Aplicacao.API.Models
{
    public class Video : Entity
    {
        public string Description { get; set; }
        public byte[] Content { get; set; }
        public Guid ServerId { get; set; }
        public virtual Server Server { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
