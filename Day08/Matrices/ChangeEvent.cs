using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    #region ChangeEvent
    public sealed class ChangeEvent
    {
        public event EventHandler<ChangeElementEventArgs> ChangeElement = delegate {};

        private void OnChangeElement(ChangeElementEventArgs e)
        {
            EventHandler<ChangeElementEventArgs> temp = ChangeElement;
            if (temp != null)
            {
                temp(this, e);
            }
        }
        //  определение метода, транслирующего входную информацию в желаемое событие
        public void GenerateChange(int i, int j, Type classType)
        {
            OnChangeElement(new ChangeElementEventArgs(i, j, classType));
        }
    }
    #endregion

    #region ChangeElementEventArgs
    public sealed class ChangeElementEventArgs : EventArgs
    {
        private readonly int _i;
        private readonly int _j;
        private readonly Type _className;
        public ChangeElementEventArgs(int i,int j, Type clName)
        {
            _i = i;
            _j = j;
            _className = clName;
        }
        public int I { get { return _i; } }
        public int J { get { return _j; } }
        public Type ClassName { get { return _className; } }
    }
    #endregion
}
