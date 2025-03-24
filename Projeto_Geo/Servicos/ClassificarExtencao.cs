using Microsoft.AspNetCore.Mvc;
using Projeto_Geo.Servicos.Interfaces;

namespace Projeto_Geo.Servicos
{
    public class ClassificarExtencao : IReceberArquivo
    {
        public IResult ReceberArquivo([FromBody] IFormFile formFile)
        {
            //testando se houve algum arquivo enviado
            if (formFile == null || formFile.Length == 0)
            {
                throw new Exception("Arquivo não encontrado. Favor conferir e reenviar.");
            }

            //testando se a extenção é válida
            string fileExtension = Path.GetExtension(formFile.FileName).ToLowerInvariant();

            if (fileExtension != ".xlm" || fileExtension != ".csv" || fileExtension != ".xlm")
            {
                throw new Exception("teste");
            }

            switch (fileExtension)
            {

                case ".xml":

                    return Results.NotFound();
                    break;


                case ".csv":
                    return Results.NotFound();
                    break;


                default:
                    return Results.NotFound();
                    break;
            }
        }
    }
}
