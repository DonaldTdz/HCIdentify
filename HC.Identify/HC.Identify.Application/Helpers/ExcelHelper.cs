using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Application.Helpers
{
    public static class ExcelHelper
    {
        private static IWorkbook workbook = null;
        private static FileStream fs = null;
        private static bool disposed;
        //创建一个Excel
        public static string CreateExcelExport(string fileName, string sheetName, string sheetTitle, DataTable data, string[] cloumName, int[] cloumWidth)
        {
            string errMsg = string.Empty;
            ISheet sheet = null;
            try
            {
                //this.CheckFileIsOpen();
                fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                if (fileName.LastIndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook();
                else if (fileName.LastIndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook();
                sheet = workbook.CreateSheet(sheetName);
                FillSheetForResultReport(sheetTitle, data, sheet, true, cloumName, cloumWidth);
                workbook.Write(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message.ToString();
                throw ex;
            }

            return errMsg;

        }

        //可以传入数据格式
        public static string CreateExcelExport(string fileName, string sheetName, string sheetTitle, DataTable data, string[] cloumName, int[] cloumWidth, string[] dataFormat)
        {
            string errMsg = string.Empty;
            ISheet sheet = null;
            try
            {
                //this.CheckFileIsOpen();
                fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                if (fileName.LastIndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook();
                else if (fileName.LastIndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook();
                sheet = workbook.CreateSheet(sheetName);
                FillSheet(sheetTitle, data, sheet, true, cloumName, cloumWidth, dataFormat);
                workbook.Write(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message.ToString();
                throw ex;
            }

            return errMsg;

        }

        /// <summary>
        /// Get Cell Style
        /// </summary>
        /// <param name="color">字体颜色 HSSFColor.BLACK.index</param>
        /// <param name="fontHeight">字体大小</param>
        /// <param name="bokdWeight">加粗 FontBoldWeight.BOLD</param>
        /// <param name="fontName">字体</param>
        /// <param name="alignment">水平位置 HorizontalAlignment</param>
        /// <param name="vAlignment">上下位置 VerticalAlignment</param>
        /// <param name="backGroundColorIndex">背景颜色索引 HSSFColor.AUTOMATIC.index</param>
        /// <param name="fillPattenTpe">填充范围</param>
        /// <param name="formatId">单元格样式</param>
        /// <returns></returns>
        public static ICellStyle GetCellStyle(short fontColorIndex, short fontHeight, FontBoldWeight bokdWeight, string fontName, HorizontalAlignment alignment, VerticalAlignment vAlignment,
           short backGroundColorIndex, FillPattern fillPattenTpe, short formatId)
        {
            if (workbook == null)
            {
                return null;
            }
            IFont font = workbook.CreateFont();
            font.Color = fontColorIndex;// HSSFColor.BLACK.index; 
            font.FontHeightInPoints = fontHeight;// 28;
            font.FontName = fontName;// "黑体"; 
            font.Boldweight = (short)bokdWeight;
            ICellStyle style = workbook.CreateCellStyle();
            style.SetFont(font);
            style.Alignment = alignment;// HorizontalAlignment.LEFT;
            style.VerticalAlignment = vAlignment;// VerticalAlignment.BOTTOM;
            style.FillForegroundColor = backGroundColorIndex;
            style.FillPattern = fillPattenTpe;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderTop = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.DataFormat = formatId;
            return style;
        }

        /// <summary>
        /// 填充Sheet 内容和设置样式 对于结果报表
        /// </summary>
        /// <param name="sheetTitle"></param>
        /// <param name="data"></param>
        /// <param name="sheet"></param>
        private static void FillSheetForResultReport(string sheetTitle, DataTable data, ISheet sheet, bool updateHeader, string[] cloumName, int[] cloumWidth)
        {
            IRow row = null;
            IDataFormat format = workbook.CreateDataFormat();
            ICell cellContent = null;
            //double cellValue = 0;
            if (updateHeader)
            {
                #region 头部

                IRow rowHeader = sheet.CreateRow(0);
                ICell cell = rowHeader.CreateCell(0);

                cell.SetCellValue(sheetTitle);
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, data.Columns.Count - 1));
                cell.CellStyle = GetCellStyle(HSSFColor.Black.Index, 20, FontBoldWeight.None, "黑体", HorizontalAlignment.Center,
                    VerticalAlignment.Bottom, HSSFColor.Automatic.Index, FillPattern.NoFill, format.GetFormat(""));
                rowHeader.Height = 50 * 10;
                IRow rowTitle = sheet.CreateRow(1);
                rowTitle.Height = 50 * 10;
                for (int i = 0; i < cloumName.Count(); i++)
                {
                    rowTitle.CreateCell(i).SetCellValue(cloumName[i]);
                    rowTitle.Cells[i].CellStyle = GetCellStyle(HSSFColor.Black.Index, 14, FontBoldWeight.None, "黑体",
                                               HorizontalAlignment.Center, VerticalAlignment.Center, HSSFColor.LightGreen.Index,
                                               FillPattern.NoFill, format.GetFormat(""));
                }
                //设置标题宽度
                //sheet.SetColumnWidth(0, 50 * 42);//序 
                for (int i = 0; i < cloumWidth.Count(); i++)
                {
                    sheet.SetColumnWidth(i, 50 * cloumWidth[i]);
                }
                sheet.CreateFreezePane(0, 2, 0, 2);

                #endregion
            }
            #region 数据内容
            int count = 2;
            ICellStyle style = GetCellStyle(HSSFColor.Black.Index, 12, FontBoldWeight.None, "宋体",
                                               HorizontalAlignment.Center, VerticalAlignment.Center,
                                               HSSFColor.LightGreen.Index, FillPattern.NoFill, HSSFDataFormat.GetBuiltinFormat("@"));
            for (int i = 0; i < data.Rows.Count; i++)
            {
                row = sheet.CreateRow(count);
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    #region 填充信息
                    cellContent = row.CreateCell(j);
                    //cellValue = data.Rows[i][j];
                    row.Height = 8 * 50;
                    #endregion
                    #region 内容的样式
                    //double.TryParse(data.Rows[i][j].ToString(), out cellValue);
                    cellContent.SetCellValue(data.Rows[i][j].ToString());
                    row.Cells[j].CellStyle = style;

                    #endregion
                }
                count++;
            }
            #endregion
        }

        /// <summary>
        /// 填充Sheet 内容和设置样式
        /// </summary>
        /// <param name="sheetTitle"></param>
        /// <param name="data"></param>
        /// <param name="sheet"></param>
        private static void FillSheet(string sheetTitle, DataTable data, ISheet sheet, bool updateHeader, string[] cloumName, int[] cloumWidth)
        {
            IRow row = null;
            IDataFormat format = workbook.CreateDataFormat();
            ICell cellContent = null;
            //double cellValue = 0;
            if (updateHeader)
            {
                #region 头部

                IRow rowHeader = sheet.CreateRow(0);
                ICell cell = rowHeader.CreateCell(0);

                cell.SetCellValue(sheetTitle);
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, data.Columns.Count - 1));
                cell.CellStyle = GetCellStyle(HSSFColor.Black.Index, 20, FontBoldWeight.None, "黑体", HorizontalAlignment.Center,
                    VerticalAlignment.Bottom, HSSFColor.Automatic.Index, FillPattern.NoFill, format.GetFormat(""));
                rowHeader.Height = 50 * 10;
                IRow rowTitle = sheet.CreateRow(1);
                rowTitle.Height = 50 * 10;
                for (int i = 0; i < cloumName.Count(); i++)
                {
                    rowTitle.CreateCell(i).SetCellValue(cloumName[i]);
                    rowTitle.Cells[i].CellStyle = GetCellStyle(HSSFColor.Black.Index, 14, FontBoldWeight.None, "黑体",
                                               HorizontalAlignment.Center, VerticalAlignment.Center, HSSFColor.LightGreen.Index,
                                               FillPattern.NoFill, format.GetFormat(""));
                }
                //设置标题宽度
                //sheet.SetColumnWidth(0, 50 * 42);//序 
                for (int i = 0; i < cloumWidth.Count(); i++)
                {
                    sheet.SetColumnWidth(i, 50 * cloumWidth[i]);
                }
                sheet.CreateFreezePane(0, 2, 0, 2);

                #endregion
            }
            #region 数据内容
            int count = 2;
            ICellStyle style = GetCellStyle(HSSFColor.Black.Index, 12, FontBoldWeight.None, "宋体",
                                               HorizontalAlignment.Center, VerticalAlignment.Center,
                                               HSSFColor.LightGreen.Index, FillPattern.NoFill, format.GetFormat(""));
            for (int i = 0; i < data.Rows.Count; i++)
            {
                row = sheet.CreateRow(count);
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    #region 填充信息
                    cellContent = row.CreateCell(j);
                    //cellValue = data.Rows[i][j];
                    row.Height = 8 * 50;
                    #endregion
                    #region 内容的样式
                    //double.TryParse(data.Rows[i][j].ToString(), out cellValue);
                    cellContent.SetCellValue(data.Rows[i][j].ToString());
                    row.Cells[j].CellStyle = style;
                    #endregion
                }
                count++;
            }
            #endregion
        }

        /// <summary>
        /// 填充Sheet 内容和设置样式
        /// </summary>
        private static void FillSheet(string sheetTitle, DataTable data, ISheet sheet, bool updateHeader, string[] cloumName, int[] cloumWidth, string[] dataFormat)
        {
            IRow row = null;
            IDataFormat format = workbook.CreateDataFormat();
            ICell cellContent = null;
            //double cellValue = 0;
            if (updateHeader)
            {
                #region 头部

                IRow rowHeader = sheet.CreateRow(0);
                ICell cell = rowHeader.CreateCell(0);

                cell.SetCellValue(sheetTitle);
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, data.Columns.Count - 1));
                cell.CellStyle = GetCellStyle(HSSFColor.Black.Index, 20, FontBoldWeight.None, "黑体", HorizontalAlignment.Center,
                    VerticalAlignment.Bottom, HSSFColor.Automatic.Index, FillPattern.NoFill, format.GetFormat(""));
                rowHeader.Height = 50 * 10;
                IRow rowTitle = sheet.CreateRow(1);
                rowTitle.Height = 50 * 10;
                for (int i = 0; i < cloumName.Count(); i++)
                {
                    rowTitle.CreateCell(i).SetCellValue(cloumName[i]);
                    rowTitle.Cells[i].CellStyle = GetCellStyle(HSSFColor.Black.Index, 14, FontBoldWeight.None, "黑体",
                                               HorizontalAlignment.Center, VerticalAlignment.Center, HSSFColor.LightGreen.Index,
                                               FillPattern.NoFill, format.GetFormat(""));
                }
                //设置标题宽度
                //sheet.SetColumnWidth(0, 50 * 42);//序 
                for (int i = 0; i < cloumWidth.Count(); i++)
                {
                    sheet.SetColumnWidth(i, 50 * cloumWidth[i]);
                }
                sheet.CreateFreezePane(0, 2, 0, 2);

                #endregion
            }
            #region 数据内容
            int count = 2;
            ICellStyle style = GetCellStyle(HSSFColor.Black.Index, 12, FontBoldWeight.None, "宋体",
                                               HorizontalAlignment.Center, VerticalAlignment.Center,
                                               HSSFColor.LightGreen.Index, FillPattern.NoFill, format.GetFormat(""));

            for (int i = 0; i < data.Rows.Count; i++)
            {
                row = sheet.CreateRow(count);
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    #region 填充信息
                    cellContent = row.CreateCell(j);
                    //cellValue = data.Rows[i][j];
                    row.Height = 8 * 50;
                    #endregion
                    #region 内容的样式
                    //double.TryParse(data.Rows[i][j].ToString(), out cellValue);
                    cellContent.SetCellValue(data.Rows[i][j].ToString());
                    //设置数据格式
                    style.DataFormat = format.GetFormat(dataFormat[j]);
                    row.Cells[j].CellStyle = style;
                    #endregion
                }
                count++;
            }
            #endregion
        }
    }
}
