using DGuard.Core.DomainObjects;
using System.Collections.Generic;

namespace DGuard.Aplicacao.API.Models
{
    public class Server : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string IP { get; set; }
        public string IPPort { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
