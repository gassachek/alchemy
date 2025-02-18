using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    private static Dictionary<Type, object> _container = new Dictionary<Type, object>();

    public static void Add<T>(T obj)
    {
        _container.Add(typeof(T), obj);
    }

    public static T Get<T>()
    {
        if (_container.ContainsKey(typeof(T)))
        {
            return (T)_container[typeof(T)];
        }
        return default;
    }
    
}

