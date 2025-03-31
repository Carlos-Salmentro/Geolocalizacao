using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Globalization;
using Projeto_Geo.Domain;
using Projeto_Geo.Servicos.Interfaces;
using Projeto_Geo.Repository.Consultas;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Projeto_Geo.Repository;
using System.Security.Cryptography.X509Certificates;

namespace Projeto_Geo.Servicos
{
    public class PopularBancoBasePrefeitura
    {
        private readonly AppDbContext _context;
        private readonly BaseDados _baseDados;
        private BaseDadosRepository _baseDadosRepository;
        private readonly IConfiguration _configuration;
        private readonly ValidadorXLSX _validadorXLSX;

        public PopularBancoBasePrefeitura(AppDbContext context, BaseDados baseDados, BaseDadosRepository baseDadosRepository, IConfiguration configuration, ValidadorXLSX validadorXLSX)
        {
            _context = context;
            _baseDados = baseDados;
            _baseDadosRepository = baseDadosRepository;
            _configuration = configuration;
            _validadorXLSX = validadorXLSX;

        }

        public void MobiliarBaseDados(AppDbContext _context, BaseDados _baseDados, BaseDadosRepository _baseDadosRepository)
        {
            string filePath = _configuration["AppSettings:filePath"];
            List<BaseDados> baseDadosAux = new List<BaseDados>();

            if (_context.BaseDados.Any())
            {
                return;
            }

            IWorkbook workbook;

            if (filePath.EndsWith(".xlsx") == false)
            {
                throw new Exception("Arquivo errado");
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(fs);  // Corrigido para HSSFWorkbook
            }

            ISheet sheet = workbook.GetSheetAt(0);

            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                IRow currentRow = sheet.GetRow(row);


                //incluir o Globalization nos doubles

                int id = Convert.ToInt32(_validadorXLSX.GetCellValue(currentRow.GetCell(0), 0));
                double lenght = Convert.ToDouble(_validadorXLSX.GetCellValue(currentRow.GetCell(1), 0.0));
                int dir = Convert.ToInt32(_validadorXLSX.GetCellValue(currentRow.GetCell(2), 0));
                string municipio = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(3), string.Empty));
                string distrito = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(4), string.Empty));
                string? bairro = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(5), null));
                string? nomeSigla = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(6), null));
                string tipo = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(7), string.Empty));
                string nomeTit = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(8), string.Empty));
                string? nomePrep = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(9), null));
                string nome = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(10), string.Empty));
                string? startLeft = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(11), null));
                string? endLeft = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(12), null));
                string? startRight = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(13), null));
                string? endRight = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(14), null));
                int parity = Convert.ToInt32(_validadorXLSX.GetCellValue(currentRow.GetCell(15), 0));
                int? leftZip = _validadorXLSX.GetCellValue(currentRow.GetCell(16)) == null ? null : Convert.ToInt32(_validadorXLSX.GetCellValue(currentRow.GetCell(16)));
                int? rightZip = _validadorXLSX.GetCellValue(currentRow.GetCell(17)) == null ? null : Convert.ToInt32(_validadorXLSX.GetCellValue(currentRow.GetCell(17)));
                string? cepE = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(18), string.Empty));
                string? cepD = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(19), string.Empty));
                int extensaoM = Convert.ToInt32(_validadorXLSX.GetCellValue(currentRow.GetCell(20), 0));
                string nomeCaps = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(21), string.Empty));
                string? onibusMsp = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(22), null));
                double distCenM = Convert.ToDouble(_validadorXLSX.GetCellValue(currentRow.GetCell(23), 0.0));
                double? distCenD = Convert.ToDouble(_validadorXLSX.GetCellValue(currentRow.GetCell(24), null));
                string cdlogCem = Convert.ToString(_validadorXLSX.GetCellValue(currentRow.GetCell(25), string.Empty));

                BaseDados baseDados = new BaseDados(id, lenght, dir, municipio, distrito, bairro, nomeSigla, tipo, nomeTit,
                    nomePrep, nome, startLeft, endLeft, startRight, endRight, parity, leftZip, rightZip, cepE, cepD,
                    extensaoM, nomeCaps, onibusMsp, distCenM, distCenD, cdlogCem);


                baseDadosAux.Add(baseDados);
                //_baseDadosRepository.AddBaseDados(baseDados);
            }
            _baseDadosRepository.AddRangeBaseDados(baseDadosAux);

        }



    }

}






