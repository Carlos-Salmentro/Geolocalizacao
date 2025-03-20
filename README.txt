Este projeto visa possibilitar o mapeamento de endereços de forma a levar
ao Codlog (código da prefeitura para endereços) e o número por meio de
arquivos variados de entrada como xml|json|csv|xls|xlsx|sql.

-- Recursos utilizados:
- Visual Studio (.NET9)
- MySQL

-- Dependências:
- Microsoft.EntityFrameworkCore 8.0.14
- Microsoft.EntityFrameworkCore.Abstractions 8.0.14
- Microsoft.EntityFrameworkCore.Design 8.0.14
- Microsoft.EntityFrameworkCore.Relational 8.0.14
- Microsoft.EntityFrameworkCore.Tools 8.0.14
- Pomelo.EntityFrameworkCore.MySql 8.0.3


-- Banco de dados --
A conexão com o banco de dados está nomeada como geolocalizacao_prefeituira
e configurada no Visual Studio através da pasta Repository e da classe
AppDbContext.

A tabela base da prefeitura que contêm o Codlog e as informações para se
chegar a ele estão em BaseDados (base_dados). Essa tabela pode ser encontrada
no seguinte link (https://centrodametropole.fflch.usp.br/pt-br/noticia/cem-oferece-maior-base-de-dados-gratuita-de-logradouros-da-regiao-metropolitana-de-sao).
Em base_dados, além das informações como vieram do link, há mais uma onde
é concatenado o Tipo + Titulo + Preposição + Nome.



