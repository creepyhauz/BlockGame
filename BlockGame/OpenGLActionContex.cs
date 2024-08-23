using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame
{
    public class OpenGLActionContex
    {
        //Очередь действий.
        private readonly ConcurrentQueue<Action> actions = new ConcurrentQueue<Action>();


        public void UpdateActions() //Выполнение действий из очереди.
        {
            while (actions.TryDequeue(out Action action))
                action();
        }

        public void EnqueueAction(Action action) //Добавление действий в очередь.
        {
            actions.Enqueue(action);
        }
    }
}
