using Microsoft.AspNetCore.Razor.TagHelpers;
using NPOI.SS.UserModel;

namespace Projeto_Geo.Servicos
{
    public class ValidadorXLSX
    {
        public object GetCellValue(ICell cell, object defaultValue = null)
        {
            if (cell == null || cell.CellType == CellType.Blank)
            {
                return defaultValue;
            }

            switch (cell.CellType)
            {
                case CellType.String:
                    return cell.ToString().Trim();

                case CellType.Numeric:
                    return cell.NumericCellValue;

                case CellType.Boolean:
                    return cell.BooleanCellValue;

                default:
                    return defaultValue;
            }
        }
    }
}
