using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    public class DiagonalMatrix<T> : AbstractMatrix<T>
    {
        private T[] _arr;
        public DiagonalMatrix(int size)
        {
            if (size < 0)
                throw new ArgumentException("Size can not be less than 0.");
            Size = size;
            _arr = new T[size];
        }

        public DiagonalMatrix(params T[] data)
        {
            if (data==null)
                throw new ArgumentNullException();
            Size = data.Length;
            _arr = new T[Size];
            data.CopyTo(_arr,0);
        }
        public override int Size { get; protected set; }
        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i > Size - 1 || j > Size - 1)
                    throw new ArgumentOutOfRangeException();
                if (i == j)
                    return _arr[i];
                else
                    return default(T);
            }
            set //добавить событие
            {
                if (i < 0 || j < 0 || i > Size - 1 || j > Size - 1)
                    throw new ArgumentOutOfRangeException();
                if (i!=j && !value.Equals(default(T)))
                    throw new ArgumentException("You can not set value in nondiagonal element!");
                if (i == j)
                    _arr[i] = value;
                changeEvent.GenerateChange(i, j, this.GetType());
            }
        }
    }
}
