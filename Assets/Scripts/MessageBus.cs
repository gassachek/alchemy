using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class MessageBus
    {
        private static Dictionary<Type, Delegate> _subscribers = new Dictionary<Type, Delegate>();

        public static void Subscribe(object subscriber, Type type)
        {
            
        }
    }
}