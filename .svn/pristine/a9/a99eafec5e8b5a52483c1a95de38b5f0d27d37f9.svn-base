using System.IO;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public interface IExcelDataRenderer
    {
        void Populate(Workbook workbook);
    }

    public class ExcelWriter
    {
        public Stream RenderExcelDataToMemoryStream(IExcelDataRenderer dataRenderer)
        {
            Workbook workbook = new Workbook();
            dataRenderer.Populate(workbook);
            MemoryStream memoryStream = new MemoryStream();
            workbook.Save(memoryStream);

            memoryStream.Position = 0L;
            return memoryStream;
        }
    }
}
