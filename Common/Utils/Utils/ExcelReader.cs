#define FIRSTASHEADER

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.OleDb;

namespace Utils
{

    public sealed class ExcelReader : IDisposable
    {
        #region fileds
        private string _fileName;
        private string _sheet;
        private object MissingValue = Type.Missing;

        private Microsoft.Office.Interop.Excel.Application _excel;
        private Microsoft.Office.Interop.Excel.Workbook _wb;
        private Microsoft.Office.Interop.Excel.Worksheet _ws;
        private Microsoft.Office.Interop.Excel.Range _rg;
        private OleDbConnection _conn;
        private OleDbCommand _comm;
        private OleDbDataReader _myReader;

        private int _rowNum;
        private int _rowCount;
        private int _colCount;
        private string[] _excelContent;

        private bool _preLoad;
        private bool _fastMode;
        // private bool _autoPreLoad;
        #endregion

        #region Init
        public ExcelReader(string fileName, string sheet)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Excel: " + fileName + " not found.");
            }
            if (String.IsNullOrEmpty(sheet))
            {
                throw new ArgumentNullException("Sheet: " + sheet + " not found.");
            }
            this._fileName = fileName;
            this._sheet = sheet;
            Init();

        }
        public ExcelReader()
        {
            Init();
        }
        private void Init()
        {
            this._preLoad = false;
            this._fastMode = false;
            // this._autoPreLoad = false;
        }
        public void Dispose()
        {
            Close();
        }
        #endregion

        #region Property
        public bool FastMode
        {
            get { return _fastMode; }
            set
            {
                _fastMode = value;
            }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public string Sheet
        {
            get { return _sheet; }
            set { _sheet = value; }
        }

        #endregion

        #region Open
        public void Open()
        {
            try
            {
                if (this._fastMode)
                {
                    OpenExcelODBC();
                }
                else
                {
                    OpenExcelCom();
                }

            }
            catch (Exception e)
            {
                throw new IOException("Can not open " + this._fileName + " : " + e.Message);
            }

        }

        private void OpenExcelODBC()
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + this._fileName + ";" + "Extended Properties=Excel 8.0;";
            _conn = new OleDbConnection(strConn);
            _conn.Open();
            string sql = "select * from [" + this._sheet + "$]";
            _comm = new OleDbCommand(sql, _conn);
            _myReader = _comm.ExecuteReader();

        }

        private void OpenExcelCom()
        {
#if	FIRSTASHEADER
            _rowNum = 1;
#else
            _rowNum = 0;
#endif
            bool found = false;
            _excel = new Microsoft.Office.Interop.Excel.Application();
            _excel.Visible = false;
            _wb = this._excel.Workbooks.Open(this._fileName, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue);
            //_wb.f
            foreach (Microsoft.Office.Interop.Excel.Worksheet i in this._wb.Worksheets)
            {
                if (i.Name == this._sheet)
                {
                    this._ws = i;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                throw new ArgumentException("Sheet: " + this._sheet + " not found.");
            }
            this._rowCount = GetRowCount();
            this._colCount = GetColCount();
        }
        #endregion

        private string[] GetExcelContent()
        {
            try
            {
                int rowCount = GetRowCount();
                int colCount = GetColCount();
                string[] excelContent = new string[rowCount * colCount];

                string cellStart = BuildCellName(1, 1);
                string cellEnd = BuildCellName(rowCount, colCount);

                this._rg = (Microsoft.Office.Interop.Excel.Range)this._ws.get_Range(cellStart, cellEnd);
                this._rg.ShrinkToFit = true;

                int cellIndex = 0;
                for (int i = 1; i <= rowCount; i++)
                {
                    for (int j = 1; j <= colCount; j++)
                    {
                        excelContent[cellIndex++] = ((Microsoft.Office.Interop.Excel.Range)this._rg.Cells[i, j]).Text.ToString();
                        if (i == 1)
                        {
#if FIRSTASHEADER
                            if (String.IsNullOrEmpty(excelContent[cellIndex++]))
                            {
                                cellIndex--;
                                colCount = j - 1;
                                this._colCount = j - 1;
                            }
#endif
                        }
                    }
                }
                return excelContent;
            }
            catch
            {
                throw new IOException("Can not load data.");
            }
            finally
            {
                Close();
            }
        }

        public int GetRowCount()
        {
            if (this._fastMode)
            {
                this._rowCount = -1;
            }
            else
            {
                this._rowCount = this._ws.UsedRange.Rows.Count;
            }

            return this._rowCount;
        }

        public int GetColCount()
        {
            if (this._fastMode)
            {
                this._rowCount = this._myReader.FieldCount;
            }
            else
            {
                this._colCount = this._ws.UsedRange.Columns.Count;
            }
            return this._colCount;
        }

        public bool MoveNext()
        {
            if (this._fastMode)
            {
                return this._myReader.Read();
            }
            else
            {
                this._rowNum++;
                if (_rowNum <= this._rowCount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //for end user, the first column in excel is index 1
        //but in program, the first column in excel is index 0
        public string ReadByIndex(int index)
        {
            if (this._fastMode)
            {
                return this._myReader.GetValue(index - 1).ToString();
            }
            else
            {
                return this.ReadCell(this._rowNum, index);
            }
        }

        private string ReadCell(int row, int col)
        {
            if (row < 1)
            {
                row = 1;
            }

            if (col < 1)
            {
                col = 1;
            }
            try
            {
                if (this._preLoad)
                {
                    int cellIndex = (row - 1) * this._colCount + col - 1;
                    return this._excelContent[cellIndex];
                }
                else
                {
                    this._rg = (Microsoft.Office.Interop.Excel.Range)this._ws.UsedRange.Cells[row, col];
                    this._rg.ShrinkToFit = true;
                    //string value = 
                    return this._rg.Text.ToString();
                    //    value = this._rg.Value2.ToString();
                    //   return value;
                }

            }
            catch (Exception e)
            {
                return "";
            }
        }

        public string ReadEntireRow(int colStart, int colEnd)
        {
            if (colStart < 1)
            {
                colStart = 1;
            }
            if (colStart > this._colCount)
            {
                colStart = this._colCount;
            }
            if (colEnd < colStart)
            {
                colEnd = colStart;
            }
            if (colEnd > this._colCount)
            {
                colEnd = this._colCount;
            }
            StringBuilder value = new StringBuilder();
            if (this._fastMode)
            {
                for (int i = colStart; i <= colEnd; i++)
                {
                    value.Append(this._myReader.GetValue(i - 1) + "\t");
                }
            }
            else
            {
                if (this._preLoad)
                {
                    for (int i = colStart; i <= colEnd; i++)
                    {
                        int cellIndex = (_rowNum - 1) * this._rowCount + i - 1;
                        value.Append(this._excelContent[cellIndex] + "\t");
                    }
                }
                else
                {
                    string cellStart = BuildCellName(this._rowNum, colStart);
                    string cellEnd = BuildCellName(this._rowNum, colEnd);
                    this._rg = (Microsoft.Office.Interop.Excel.Range)this._ws.get_Range(cellStart, cellEnd);
                    this._rg.ShrinkToFit = true;
                    int colNum = colEnd - colStart + 1;
                    for (int i = 1; i <= colNum; i++)
                    {
                        value.Append(((Microsoft.Office.Interop.Excel.Range)this._rg.Cells[1, i]).Text + "\t");
                    }
                }
            }
            return value.ToString();
        }

        private string BuildCellName(int row, int col)
        {
            char[] colArr =   {' ','a','b','c','d','e','f','g','h','i','j','k','l'   
                               ,'m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            int a, b;
            string sTemp;

            if (col < 27)
                sTemp = colArr[col].ToString();
            else
            {
                a = (col - 1) / 26;
                b = col - a * 26;
                sTemp = colArr[a].ToString() + (string)colArr[b].ToString();
            }

            return sTemp + row.ToString();
        }

        public void Close()
        {
            try
            {
                if (this._fastMode)
                {
                    if (this._conn != null)
                    {
                        this._comm.Dispose();
                        this._comm = null;
                        this._conn.Close();
                        this._conn = null;
                    }
                }
                else
                {
                    if (this._excel != null)
                    {
                        this._wb.Close(false, this._fileName, this.MissingValue);
                        this._excel.Quit();
                        int gen = System.GC.GetGeneration(this._excel);
                        this._excel = null;
                        System.GC.Collect(gen);
                    }

                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
