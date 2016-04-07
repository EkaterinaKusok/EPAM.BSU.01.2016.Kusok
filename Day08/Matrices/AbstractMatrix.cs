using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    public abstract class AbstractMatrix<T>
    {
        protected static ChangeEvent changeEvent = new ChangeEvent();

        public abstract int Size { get; protected set; }

        static AbstractMatrix()
        {
            ChangesWatcher changesWatcher = new ChangesWatcher();
            changesWatcher.Register(changeEvent);
        } 

        public virtual T this[int i, int j]
        {
            get { return default(T); }
            set { changeEvent.GenerateChange(i,j, this.GetType());}
        }
    }



    #region Listeners: ChangesWatcher
    public sealed class ChangesWatcher
    {
        //CustomTimer вызывает этот метод для уведомления
        //объекта ChangesWatcher о прибытии нового почтового сообщени
        private void ChangeMsg(Object sender, ChangeElementEventArgs eventArgs)
        {
            Debug.Print("You change ({0},{1}) element in {2}", eventArgs.I,eventArgs.J,eventArgs.ClassName.ToString());
        }
        public void Register(ChangeEvent changeEvent)
        {
            changeEvent.ChangeElement += ChangeMsg;
        }
        public void Unregister(ChangeEvent changeEvent)
        {
            changeEvent.ChangeElement -= ChangeMsg;
        }
    }
    #endregion
}
