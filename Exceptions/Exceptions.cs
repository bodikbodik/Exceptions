using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    public class MatrixException : Exception
    {
        public MatrixException()
        {
        }

        public MatrixException(string message) : base(message)
        {
        }

        public MatrixException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MatrixException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    public class Matrix
        {
            public int Rows
            {
            get;
            }
            public int Columns
            {
            get;
            }
            public double[,] Array
            {
            get;
            }
            public Matrix(int rows, int columns)
            {
               if (rows <= 0 )
               {
                  throw new ArgumentOutOfRangeException("rows", "ArgumentOutOfRangeException");
               }
               if (columns <= 0)
               {
                  throw new ArgumentOutOfRangeException("rows", "ArgumentOutOfRangeException");
               }
            Array = new double[rows, columns];
            Rows = rows;
            Columns = columns;
            }
            public Matrix(double[,] array)
            {
                if (array == null)
                {
                  throw new ArgumentNullException("array");
                }
                else
                {
                  
                  Rows = array.GetLength(0);
                  Columns = array.GetLength(1);
                  Array = array;
                }
            }
            public double this[int row, int column]
            {
                get
                { 
                if(row < 0 || (row >= Rows))
                    {
                    throw new ArgumentException("row");
                    }
                if(column < 0 || (column >= Columns))
                    {
                    throw new ArgumentException("column");
                    }
                    return Array[row, column];
                    
                }
                set 
                { 
                if(row < 0 || (row >= Rows))
                    {
                    throw new ArgumentException("row");
                    }
                if(column < 0 || (column >= Columns))
                    {
                    throw new ArgumentException("column");
                    }
                    Array[row, column] = value;
                    
                }
            }
            public Matrix Add(Matrix matrix)
            {
            if (matrix == null)
                throw new ArgumentNullException("matrix");
            else
            {
                if ((Rows!=matrix.Rows) || (Columns!=matrix.Columns))
                    throw new MatrixException();
                else
                {
                    double[,] newmatrix = new double[Rows,Columns];
                    for (int i = 0; i < Rows; i++)
                        for (int j = 0; j < Columns; j++)
                            newmatrix[i,j] = Array[i, j] + matrix.Array[i,j];
                    return new Matrix(newmatrix);
                }
            }
            }
            public Matrix Subtract(Matrix matrix)
            {
            if (matrix == null)
                throw new ArgumentNullException("matrix");
            else
            {
                if ((Rows!=matrix.Rows) || (Columns!=matrix.Columns))
                    throw new MatrixException();
                else
                {
                    double[,] newmatrix = new double[Rows,Columns];
                    for (int i = 0; i < Rows; i++)
                        for (int j = 0; j < Columns; j++)
                            newmatrix[i,j] = Array[i, j] - matrix.Array[i,j];
                    return new Matrix(newmatrix);
                }
            }
            }
            public Matrix Multiply(Matrix matrix)
            {
            if (matrix == null)
                throw new ArgumentNullException("matrix");
            
                if (Columns != matrix.Rows) 
                    throw new MatrixException();
               
                    double[,] newmatrix = new double[Rows , matrix.Columns];
                    for (int i = 0; i < Rows; i++)
                        for (int j = 0; j < matrix.Columns; j++)
                            for (int k = 0; k < Columns; k++)
                                newmatrix[i,j] += Array[i, k] * matrix[k,j];
                    return new Matrix(newmatrix);
               
            
            }
    }
    
}