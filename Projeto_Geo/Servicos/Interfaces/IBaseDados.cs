using Projeto_Geo.Domain;

namespace Projeto_Geo.Servicos.Interfaces
{
    public interface IBaseDados
    {
        public void AddBaseDados(BaseDados baseDados);

        public void AddRangeBaseDados(List<BaseDados> baseDados);

        public void UpDateBaseDados(BaseDados baseDados);

        public void DeleteBaseDados(BaseDados baseDados);
    }
}
