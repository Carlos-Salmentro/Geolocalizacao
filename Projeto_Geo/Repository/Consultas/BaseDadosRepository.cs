using Projeto_Geo.Domain;
using Projeto_Geo.Servicos.Interfaces;



namespace Projeto_Geo.Repository.Consultas
{
    public class BaseDadosRepository : IBaseDados
    {
        private AppDbContext _context;
                
        public BaseDadosRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddBaseDados(BaseDados baseDados)
        {
            _context.BaseDados.Add(baseDados);
            _context.SaveChanges();
        }

        public void AddRangeBaseDados(List<BaseDados> baseDados)
        {
            _context.BaseDados.AddRange(baseDados);
            _context.SaveChanges();
        }

        public void UpDateBaseDados(BaseDados baseDados)
        {
            BaseDados aux = _context.BaseDados.FirstOrDefault(x => x.Id == baseDados.Id);
            aux = baseDados;
            _context.SaveChanges();
        }

        public void DeleteBaseDados(BaseDados baseDados)
        {
            BaseDados aux = _context.BaseDados.FirstOrDefault(x => x.Id == baseDados.Id);
            _context.BaseDados.Remove(aux);
            _context.SaveChanges();

        }
    }
}
