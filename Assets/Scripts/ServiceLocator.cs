using UnityEngine;
using System;
using System.Collections.Generic;

public class ServiceLocator
{
    private readonly Dictionary<Type, IService> _services = new();

    public ServiceLocator()
    {
        Current = this;
    }

    public static ServiceLocator Current { get; private set; }

    public void Register<TService>(TService service) where TService : IService
    {
        if (_services.ContainsKey(typeof(IService)))
        {
            Debug.LogWarning($"Service {typeof(TService).Name} already registered. Overriding.");
        }
        else
        {
            _services[typeof(TService)] = service;
        }
    }

    public TService Get<TService>() where TService : IService
    {
        if (_services.TryGetValue(typeof(TService), out var service))
        {
            return (TService)service;
        }

        throw new Exception($"Service {typeof(TService).Name} does not exist.");
    }

    public void Unregister<TService>() where TService : IService
    {
        var type = typeof(TService);

        _services.Remove(type);
    }

    public void Clear()
    {
        _services.Clear();
    }

    public interface IService
    {
    }
}