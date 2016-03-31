using System;

namespace Timer
{
    #region CustomTimer
    public sealed class CustomTimer
    {
        // Определение члена-события 
        public event EventHandler<EndTimerEventArgs> EndTimer;//= delegate {};

        // Определение метода, ответственного за уведомление зарегистрированных объектов о событии
        private void OnNewMail(EndTimerEventArgs e)
        {
            EventHandler<EndTimerEventArgs> temp = EndTimer;
            if (temp != null)
            {
                temp(this, e);
            }
        }
        //  определение метода, транслирующего входную информацию в желаемое событие
        public void SimulateEndTimer(int seconds)
        {
            OnNewMail(new EndTimerEventArgs(seconds));
        }
    }
    #endregion

    #region EndTimerEventArgs
    // определение типа, хранящего информацию, которая передается получателям уведомления о событии.
    public sealed class EndTimerEventArgs : EventArgs
    {
        private readonly int _seconds;
        public EndTimerEventArgs(int seconds)
        {
            _seconds = seconds;
        }
        public int Seconds { get { return _seconds; } }
    }
    #endregion
}
