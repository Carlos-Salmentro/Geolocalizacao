using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;
using System.Globalization;
using Projeto_Geo.Domain;

namespace Projeto_Geo.Repository
{
    public class PopularBancoBasePrefeitura
    {
        private readonly AppDbContext _context;
        private readonly BaseDados _baseDados;

        public PopularBancoBasePrefeitura(AppDbContext context, BaseDados baseDados)
        {
            _context = context;
            _baseDados = baseDados;
        }

        static string filePath = "C:\\Users\\carlo\\OneDrive\\Área de Trabalho\\projeto_geo\\LOG2020_CEM_RMSP - Copia.xls";

        public static void MobiliarBaseDados(string filePath, AppDbContext _context, BaseDados _baseDados)
        {
            IWorkbook workbook;

            if (filePath.EndsWith(".xls") == false)
            {
                throw new Exception("Arquivo errado");
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(fs);
            }

            ISheet sheet = workbook.GetSheetAt(0);

            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                IRow currentRow = sheet.GetRow(row);

                int id = int.Parse(currentRow.GetCell(0).ToString());
                double lenght = double.Parse(currentRow.GetCell(1).ToString(), new CultureInfo("pt-br"));
                int dir = int.Parse(currentRow.GetCell(2).ToString());
                string municipio = currentRow.GetCell(3).ToString();
                string distrito = currentRow.GetCell(4).ToString();
                string bairro = currentRow.GetCell(5).ToString();
                string nomeSigla = currentRow.GetCell(6).ToString();
                string sigla = currentRow.GetCell(7).ToString();
                string tipo = currentRow.GetCell(8).ToString();
                string nomeTit = currentRow.GetCell(9).ToString();
                string nomePrep = currentRow.GetCell(10).ToString();
                string nome = currentRow.GetCell(11).ToString();
                string startLeft = currentRow.GetCell(12).ToString();
                string endLeft = currentRow.GetCell(13).ToString();
                string startRight = currentRow.GetCell(14).ToString();
                string endRight = currentRow.GetCell(15).ToString();
                int parity = int.Parse(currentRow.GetCell(16).ToString());
                int leftZip = int.Parse(currentRow.GetCell(17).ToString());
                int rightZip = int.Parse(currentRow.GetCell(18).ToString());
                int cepE = int.Parse(currentRow.GetCell(19).ToString());
                int cepD = int.Parse(currentRow.GetCell(20).ToString());
                int extensaoM = int.Parse(currentRow.GetCell(21).ToString());
                string nomeCaps = currentRow.GetCell(22).ToString();
                string onibusMsp = currentRow.GetCell(23).ToString();
                double distCenM = double.Parse(currentRow.GetCell(24).ToString(), new CultureInfo("pt-br"));
                double distCenD = double.Parse(currentRow.GetCell(25).ToString(), new CultureInfo("pt-br"));
                string cdlogCem = currentRow.GetCell(26).ToString();

                BaseDados baseDados = new BaseDados(id, lenght, dir, municipio, distrito, bairro, nomeSigla, tipo, nomeTit, nomePrep, nome, startLeft, endLeft, startRight, endRight, parity, leftZip, rightZip, cepE, cepD, extensaoM, nomeCaps,
                    onibusMsp, distCenM, distCenD, cdlogCem);
            }
        }
    }

}






