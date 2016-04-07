using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    public class SquareMatrix <T> : AbstractMatrix<T>
    {
        private T[][] _arr;
        public SquareMatrix(int size)
        {
            if (size < 0)
                throw new ArgumentException("Size can not be less than 0.");
            Size = size;
            _arr = new T[size][];
            for (int i = 0; i < size; ++i)
                _arr[i] = new T[size];
        }

        public SquareMatrix(T[,] data)
        {
            if (data == null)
                throw new ArgumentNullException();
            if(data.GetLength(1)!=data.GetLength(2))
                throw new ArgumentException("You enter nonsquare matrix.");
            Size = data.GetLength(1);
            for (int i = 0; i < Size; ++i)
                _arr[i] = new T[Size];
            for (int i = 0; i < Size; ++i)
                for (int j = 0; j < Size; ++j)
                    _arr[i][j] = data[i, j];
        }
        public SquareMatrix(T[][] data)
        {
            if (data == null)
                throw new ArgumentNullException();
            if (data.GetLength(1) != data.GetLength(2))
                throw new ArgumentException("You enter nonsquare matrix.");
            Size = data.GetLength(1);
            for (int i = 0; i < Size; ++i)
            {
                _arr[i] = new T[Size];
                data[i].CopyTo(_arr[i],0);
            }
        }
        public override int Size { get; protected set; }
        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i > Size - 1 || j > Size - 1)
                    throw new ArgumentOutOfRangeException();
                return _arr[i][j];
            }
            set 
            {
                if (i < 0 || j < 0 || i > Size - 1 || j > Size - 1)
                    throw new ArgumentOutOfRangeException();
                _arr[i][j] = value;
                changeEvent.GenerateChange(i, j, this.GetType());
            }
        }
    }
}
