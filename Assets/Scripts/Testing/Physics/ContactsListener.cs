using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public static class ContactsListener
{
    private static Dictionary<int, Action<int, int, ModifiableContactPair>> modifiers = new();

    public static void RegisterModifier(int bodyId, Action<int, int, ModifiableContactPair> modifier) {
      
        if (!modifiers.TryAdd(bodyId, modifier) || modifiers.Count > 1) return;
        Physics.ContactModifyEvent += PhysicsOnContactModifyEvent;

    }


    public static void UnregisterModifier(int bodyId)
    {
        if (!modifiers.Remove(bodyId) || modifiers.Count > 0) return;

        Physics.ContactModifyEvent -= PhysicsOnContactModifyEvent;

    }

    private static void PhysicsOnContactModifyEvent(PhysicsScene scene, NativeArray<ModifiableContactPair> pairs)
    {
        foreach (var modifyableContactPair in pairs) {
         
            if (modifiers.TryGetValue(modifyableContactPair.bodyInstanceID, out var m)) 
                m(modifyableContactPair.bodyInstanceID, modifyableContactPair.otherBodyInstanceID, modifyableContactPair);
         
            else if (modifiers.TryGetValue(modifyableContactPair.otherBodyInstanceID, out m))
                m(modifyableContactPair.otherBodyInstanceID, modifyableContactPair.bodyInstanceID, modifyableContactPair);
           
        }
    }
}
