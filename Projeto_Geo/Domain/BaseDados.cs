using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Projeto_Geo.Domain
{
    [Table("base_dados")]
    public class BaseDados
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("lenght")]
        [Required]
        public double Lenght { get; set; }

        [Column("dir")]
        [Required]
        public int Dir { get; set; }

        [Column("municipio")]
        [Required]
        public string Municipio { get; set; }

        [Column("distrito")]
        [Required]
        public string Distrito { get; set; }

        [Column("bairro")]
        public string? Bairro { get; set; }

        [Column("nomesigla")]
        public string? NomeSigla { get; set; }

        [Column("tipo")]
        [Required]
        public string Tipo { get; set; }

        [Column("nometit")]
        public string? NomeTit { get; set; }

        [Column("nomeprep")]
        public string? NomePrep { get; set; }

        [Column("nome")]
        [Required]
        public string Nome { get; set; }

        [Column("start_left")]
        public string? StartLeft { get; set; }

        [Column("end_left")]
        public string? EndLeft { get; set; }

        [Column("start_right")]
        public string? StartRight { get; set; }

        [Column("end_right")]
        public string? EndRight { get; set; }

        [Column("parity")]
        [Required]
        public int Parity { get; set; }

        [Column("left_zip")]
        public int? LeftZip { get; set; }

        [Column("right_zip")]
        public int? RightZip { get; set; }

        [Column("cep_e")]
        public string? CepE { get; set; }

        [Column("cep_d")]
        public string? CepD { get; set; }

        [Column("extensao_m")]
        [Required]
        public int ExtensaoM { get; set; }

        [Column("nome_caps")]
        [Required]
        public string NomeCaps { get; set; }

        [Column("onibus_msp")]
        public bool? OnibusMsp { get; set; }

        [Column("dist_cen_m")]
        [Required]
        public double DistCenM { get; set; }

        [Column("dist_cen_d")]
        public double? DistCenD { get; set; }

        [Column("cdlog_cem")]
        public string CdlogCem { get; set; }

        [Column("nome_concat")]
        public string NomeConcat { get; set; }

        public BaseDados(){ }

        public BaseDados(int id, double lenght, int dir, string municipio, string distrito, string? bairro, string? nomeSigla, string tipo, string? nomeTit, string? nomePrep, string nome, string? startLeft, string? endLeft, string? startRight, string? endRight, int parity, int? leftZip, int? rightZip, string? cepE, string? cepD, int extensaoM, string nomeCaps, string? onibusMsp, double distCenM, double? distCenD, string cdlogCem)
        {
            Id = id;
            Lenght = lenght;
            Dir = dir;
            Municipio = municipio.Trim();
            Distrito = distrito.Trim();
            Bairro = bairro.Trim();
            NomeSigla = nomeSigla.Trim();
            Tipo = tipo.Trim();
            NomeTit = nomeTit.Trim();
            NomePrep = nomePrep.Trim();
            Nome = nome.Trim();
            StartLeft = startLeft.Trim();
            EndLeft = endLeft.Trim();
            StartRight = startRight.Trim();
            EndRight = endRight.Trim();
            Parity = parity;
            LeftZip = leftZip;
            RightZip = rightZip;
            CepE = cepE;
            CepD = cepD;
            ExtensaoM = extensaoM;
            NomeCaps = nomeCaps.Trim();
            OnibusMsp = string.IsNullOrEmpty(onibusMsp) ? false : true;
            DistCenM = distCenM;
            DistCenD = distCenD;
            CdlogCem = cdlogCem;
            NomeConcat = $"{tipo.Trim()} {nomeTit.Trim()} {nomePrep.Trim()} {nome.Trim()}";
        }
    }
}
