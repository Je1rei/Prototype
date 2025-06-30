using UnityEngine;
using System;
using System.Collections.Generic;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

    public static void Register<T>(T service) where T : class
    {
        var type = typeof(T);
        if (_services.ContainsKey(type))
        {
            Debug.LogWarning($"Service {type.Name} already registered. Overriding.");
            _services[type] = service;
        }
        else
        {
            _services.Add(type, service);
        }
    }

    public static T Get<T>() where T : class
    {
        var type = typeof(T);
        if (_services.TryGetValue(type, out var service))
        {
            return (T)service;
        }

        Debug.LogError($"Service {type.Name} not found!");
        return null;
    }

    public static void Unregister<T>() where T : class
    {
        var type = typeof(T);
        if (_services.ContainsKey(type))
        {
            _services.Remove(type);
        }
    }

    public static void Clear()
    {
        _services.Clear();
    }
}