using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InterfaceEventsService : MonoBehaviour
{

    private static  readonly Dictionary<Type, List<IInterfaceSubscriber>> interface_subscribers = new Dictionary<Type, List<IInterfaceSubscriber>>();


    public static void callEvent<TSubscriber>(Action<TSubscriber> action) where TSubscriber : class, IInterfaceSubscriber {

        var subscribers = interface_subscribers[typeof(TSubscriber)];

        foreach (var sub in subscribers) {

            action?.Invoke(sub as TSubscriber);
        }
    
    }
    public static void subscribe(IInterfaceSubscriber subscriber) {

        var types = getSubscriberTypes(subscriber);
        foreach (var type in types) {

            if (!interface_subscribers.ContainsKey(type)) {
                interface_subscribers[type] = new List<IInterfaceSubscriber>();
            }

            interface_subscribers[type].Add(subscriber);
        }
    }

    public static void deSubscribe(IInterfaceSubscriber subscriber) {
       
        var subscriberTypes = getSubscriberTypes(subscriber);
        foreach (var type in subscriberTypes)
        {
            if (interface_subscribers.ContainsKey(type))
            {
                interface_subscribers[type].Remove(subscriber);
            }
        }
    }

    private static IEnumerable<Type> getSubscriberTypes(IInterfaceSubscriber subscriber) {

        var type = subscriber.GetType();
        var all_types = type.GetInterfaces().ToList();

        return all_types;
    }
}

public interface IInterfaceSubscriber { }

public interface IServiceInitSubscriber : IInterfaceSubscriber {
    public void onGetServices();
}