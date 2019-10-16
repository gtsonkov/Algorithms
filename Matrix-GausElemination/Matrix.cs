using System;
using System.Linq;

namespace MatrixGausElemination
{
    public class Matrixs
    {
        public const string MatrixStart = "[";
        public const string MatrixStop = "]";
        public const char RowSeparator = ';';
        public const char RowCellSeparator = ' ';

        public int RowCount { get; }

        public int ColumnCount { get; }

        public int CellCount => InternData.Length;

        public bool IsSquare => RowCount == ColumnCount;

        public bool IsVector => ColumnCount == 1;

        private readonly double[] InternData;

        public double this[int rowIndex, int columnIndex]
        {
            get => this.InternData[Convert2DIndexTo1DIndex(rowIndex, columnIndex)];
            set => this.InternData[Convert2DIndexTo1DIndex(rowIndex, columnIndex)] = value;
        }

        public Matrixs(Matrixs matrix)
            : this(matrix.RowCount, matrix.ColumnCount)
        {
            for (var i = 0; i < InternData.Length; i++)
            {
                InternData[i] = matrix.InternData[i];
            }
        }

        public Matrixs(int size, double placeHolder = 0)
            : this(size, size, placeHolder)
        {
        }

        public Matrixs(int rowCount, int columnCount, double initializationValue = 0)
        {
            if (rowCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rowCount));
            }
            if (columnCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(columnCount));
            }

            RowCount = rowCount;
            ColumnCount = columnCount;
            InternData = new double[RowCount * ColumnCount];

            if (Math.Abs(initializationValue) > 0)
            {
                Set(initializationValue);
            }
        }

        public Matrixs(int rowCount, int columnCount, double[] initializationValues)
        {
            if (rowCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rowCount));
            }
            if (columnCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(columnCount));
            }
            if (initializationValues.Length != rowCount * columnCount)
            {
                throw new ArgumentOutOfRangeException(nameof(initializationValues));
            }

            RowCount = rowCount;
            ColumnCount = columnCount;
            InternData = new double[initializationValues.Length];
            initializationValues.CopyTo(InternData, 0);
        }

        private int Convert2DIndexTo1DIndex(int rowIndex, int columnIndex)
        {
            return rowIndex * ColumnCount + columnIndex;
        }

        public void Set(double value)
        {
            for (var i = 0; i < InternData.Length; i++)
            {
                InternData[i] = value;
            }
        }

        public Matrixs Transpose()
        {
            var result = new Matrixs(ColumnCount, RowCount);

            for (var i = 0; i < result.RowCount; i++)
            {
                for (var j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = this[j, i];
                }
            }

            return result;
        }

        public Matrixs Copy()
        {
            return new Matrixs(this);
        }

        private int FindColumnAbsMax(int index)
        {
            return FindColumnAbsMax(index, index);
        }

        private int FindColumnAbsMax(int rowStartIndex, int columnIndex)
        {
            var maxIndex = rowStartIndex;

            for (var i = rowStartIndex + 1; i < RowCount; i++)
            {
                if (Math.Abs(this[maxIndex, columnIndex]) <= Math.Abs(this[i, columnIndex]))
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }


        public void SwapRows(int rowIndexA, int rowIndexB)
        {
            for (var j = 0; j < ColumnCount; j++)
            {
                var indexA = Convert2DIndexTo1DIndex(rowIndexA, j);
                var indexB = Convert2DIndexTo1DIndex(rowIndexB, j);
                ArrayHelpers.Swap(InternData, indexA, indexB);
            }
        }

        public void SwapColumns(int columnIndexA, int columnIndexB)
        {
            for (var i = 0; i < RowCount; i++)
            {
                var indexA = Convert2DIndexTo1DIndex(i, columnIndexA);
                var indexB = Convert2DIndexTo1DIndex(i, columnIndexB);

                ArrayHelpers.Swap(InternData, indexA, indexB);
            }
        }

        public static Matrixs Parse(string matrixString)
        {
            if (!matrixString.StartsWith(MatrixStart) || !matrixString.EndsWith(MatrixStop))
            {
                throw new FormatException();
            }

            matrixString = matrixString.Remove(0, 1);
            matrixString = matrixString.Remove(matrixString.Length - 1, 1);

            var rows = matrixString.Split(new[] { RowSeparator }, StringSplitOptions.RemoveEmptyEntries);

            if (rows.Length <= 0)
            {
                return new Matrixs(0, 0);
            }

            var cells = ParseRow(rows[0]);
            var matrix = new Matrixs(rows.Length, cells.Length);

            for (var j = 0; j < cells.Length; j++)
            {
                matrix[0, j] = cells[j];
            }

            for (var i = 1; i < matrix.RowCount; i++)
            {
                cells = ParseRow(rows[i]);

                for (var j = 0; j < cells.Length; j++)
                {
                    matrix[i, j] = cells[j];
                }
            }

            return matrix;
        }

        public Matrixs GaussianElimination(double epsilon = 1e-10)
        {
            var result = Copy();

            var kMax = Math.Min(result.RowCount, result.ColumnCount);

            for (var k = 0; k < kMax; k++)
            {
                // Find k-th pivot, i.e. maximum in column max
                var iMax = result.FindColumnAbsMax(k);

                if (Math.Abs(result[iMax, k]) < epsilon)
                {
                    throw new ArithmeticException("Matrix is singular or nearly singular.");
                }

                // Swap maximum row with current row
                SwapRows(k, iMax);

                // Make all rows below the current one, with 0 in current column
                for (var i = k + 1; i < result.RowCount; i++)
                {
                    var factor = result[i, k] / result[k, k];

                    for (var j = k + 1; j < result.ColumnCount; j++)
                    {
                        result[i, j] = result[i, j] - result[k, j] * factor;
                    }

                    result[i, k] = 0;
                }
            }

            return result;
        }

        private static double[] ParseRow(string row)
        {
            var cells = row.Split(new[] { RowCellSeparator }, StringSplitOptions.RemoveEmptyEntries);
            return cells.Select(x => Convert.ToDouble(x.Replace(" ", string.Empty))).ToArray();
        }
    }
    public static class ArrayHelpers
    {
        public static void Swap<TSource>(this TSource[] source, int indexA, int indexB)
        {
            var tmp = source[indexA];
            source[indexA] = source[indexB];
            source[indexB] = tmp;
        }
    }
}