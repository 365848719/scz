using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scz.DesignPattern
{
    public delegate  void NotifyEventHandler(TenXun2 tenXun2);

    public abstract class TenXun2
    {
        private NotifyEventHandler _notifyEventHandler;

        public string Symbol { get; set; }
        public string Info { get; set; }
        protected TenXun2(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        public void AddObserver(NotifyEventHandler handler)
        {
            if (handler != null)
            {
                _notifyEventHandler += handler;
            }
        }

        public void RemoveObserver(NotifyEventHandler handler)
        {
            if (handler != null)
            {
                this._notifyEventHandler -= handler;
            }
        }

        public void Notify()
        {
            _notifyEventHandler?.Invoke(this);
        }
    }

    public class TenXunGame2 : TenXun2
    {
        public TenXunGame2(string symbol, string info) : base(symbol, info)
        {
        }
    }

    public class Subscriber2
    {
        public string Name { get; }
        public Subscriber2(string name)
        {
            this.Name = name;
        }

        public void Execute(TenXun2 tenXun2)
        {
            Console.WriteLine($"通知{this.Name} of {tenXun2.Symbol} 's ,Info is {tenXun2.Info} ");
        }
    }
}
