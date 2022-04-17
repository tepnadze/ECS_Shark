using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]
public class ContactsModify : MonoBehaviour
{
    private int body_instance_id;
    
    
    private Vector3 ground_direction = Vector3.up;
    private Vector3 world_direction;


    private Vector3 ground_normal;
    private Vector3 cube_normal;


    private void Awake()
    {
        world_direction = transform.TransformDirection(ground_direction);
        body_instance_id = GetComponent<Rigidbody>().GetInstanceID();

        GetComponent<Collider>().hasModifiableContacts = true;

    }

    private void OnEnable  ()  => ContactsListener.RegisterModifier(body_instance_id, ContactModify);
    

    private void OnDisable ()  => ContactsListener.UnregisterModifier(body_instance_id);

    
    private void ContactModify(int platformId, int otherId, ModifiableContactPair pair) {

        var normal_multiply = pair.bodyInstanceID == platformId ? 1 : -1;
        for (int j = 0; j < pair.contactCount; j++) {

            if (Vector3.Dot(world_direction, pair.GetNormal(j)) * normal_multiply > 0f) {
                pair.IgnoreContact(j);
            }
        }
    }

    private void PhysicsContactModify(PhysicsScene scene, NativeArray<ModifiableContactPair> pair) 
    {
   
        foreach (var contact in pair) {

            if (contact.bodyInstanceID != body_instance_id && contact.otherBodyInstanceID != body_instance_id) continue;
           
            for(int i = 0; i < contact.contactCount; i++) {

                var bounce_value     = contact.GetBounciness(i);
                var dynamic_friction = contact.GetDynamicFriction(i);
                var contact_normal   = contact.GetNormal(i);
             
                Debug.Log(contact_normal);

                if (contact_normal.y < 0f)
                    contact.IgnoreContact(i);

                Debug.DrawRay(contact.GetPoint(i), contact_normal * 5f, Color.red, 1f);

            }
        }
    }
}
