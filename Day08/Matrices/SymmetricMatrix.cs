using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    public class SymmetricMatrix <T>: AbstractMatrix<T>
    {
        private T[][] _arr;
        public SymmetricMatrix(int size)
        {
            if (size < 0)
                throw new ArgumentException("Size can not be less than 0.");
            Size = size;
            _arr = new T[size][];
            for (int i = 0; i < size; ++i)
                _arr[i] = new T[i+1];
        }
        public SymmetricMatrix(T[,] data)
        {
            if (data == null)
                throw new ArgumentNullException();
            if (data.GetLength(1) != data.GetLength(2))
                throw new ArgumentException("You enter nonsquare matrix.");
            Size = data.GetLength(1);
            for (int i = 0; i < Size; ++i)
                _arr[i] = new T[i+1];
            for (int i = 0; i < Size; ++i)
                for (int j = 0; j <= i; ++j)
                    _arr[i][j] = data[i, j];
            for (int i = 0; i < Size; ++i)
                for (int j = i+1; j <= Size; ++j)
                    if(!data[i,j].Equals(_arr[j][i]))
                        throw new ArgumentException("You enter nonsymmetric matrix.");
        }

        public SymmetricMatrix(T[][] data)
        {
            if (data == null)
                throw new ArgumentNullException();
            if (data.GetLength(1) != data.GetLength(2))
                throw new ArgumentException("You enter nonsymmetric matrix.");
            Size = data.GetLength(1);
            for (int i = 0; i < Size; ++i)
            {
                _arr[i] = new T[i+1];
                data[i].CopyTo(_arr[i], 0);
            }
        }
        public override int Size { get; protected set; }
        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i > Size - 1 || j > Size - 1)
                    throw new ArgumentOutOfRangeException();
                if (i < j)
                    return _arr[j][i];
                return _arr[i][j];
            }
            set
            {
                if (i < 0 || j < 0 || i > Size - 1 || j > Size - 1)
                    throw new ArgumentOutOfRangeException();
                if (i < j)
                {
                    if (!_arr[j][i].Equals(value))
                        throw new ArgumentException("You try to do nonsymmetric matrix.");
                }
                else
                    _arr[i][j] = value;
                changeEvent.GenerateChange(i, j, this.GetType());
            }
        }
    }
}
