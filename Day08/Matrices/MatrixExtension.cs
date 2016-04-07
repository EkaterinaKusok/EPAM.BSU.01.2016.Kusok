using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    public static class  MatrixExtension
    {
        public static SquareMatrix<dynamic> Add(this AbstractMatrix<dynamic> lhs, AbstractMatrix<dynamic> rhs)
        {
            if (lhs == null || rhs == null)
                throw new ArgumentNullException();
            if (lhs.Size != rhs.Size)
                throw new ArgumentException();
            SquareMatrix<dynamic> result = new SquareMatrix<dynamic>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
                for (int j = 0; j < lhs.Size; j++)
                    result[i, j] = lhs[i, j] + rhs[i, j];
            return result;
        }
    }
}
