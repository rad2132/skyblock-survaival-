using System;
using System.Collections.Generic;

namespace InventorySystem.Events
{
    public abstract class QuickAccessInventoryPanelEvent
    {
        private readonly List<Action> _callbacks = new(); 

        public void Subscribe(Action callback) => _callbacks.Add(callback);

        public void Unsubscribe(Action callback)
        {
            if(_callbacks.Contains(callback)) _callbacks.Remove(callback);
        }

        public void Publish()
        {
            foreach (Action callback in _callbacks) callback();
        }
    }
}