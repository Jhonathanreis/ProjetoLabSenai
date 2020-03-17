using System.Collections.Generic;

namespace WebApiDB.Domain
{
    public class Sala : BaseEntity
    {
        public string TipoSala { get; set; }
        public int Capacidade { get; set; }
        public int TotalPessoas { get; set; }
        public int TotalComputadores { get; set; }
        public string UnidInstitucional { get; set; }
        List<Acesso> Acessos { get; set; }
    }
}