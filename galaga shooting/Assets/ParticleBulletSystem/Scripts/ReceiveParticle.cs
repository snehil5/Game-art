using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ParticleBulletSystem
{
    public class ReceiveParticle : MonoBehaviour
    {
        [Tooltip("\nWhen ReceiveParticle to attach the game object is to hit, it will send a Message to this SendMessageTarget.")]
        public GameObject sendMessageTarget;
        [Tooltip("String to be used in the sendmessage")]
        public string message = "Damage";
        public bool receiveForce = false;

        private Rigidbody rigi;
        List<ParticleCollisionEvent> collisionEvents;
        new ParticleSystem particleSystem;
        int safeLength;
        int numCollisionEvents;
        Vector3 force;
        float power = 1;

        void Awake()
        {
            if (sendMessageTarget == null)
            {
                sendMessageTarget = gameObject;
            }
            rigi = sendMessageTarget.GetComponent<Rigidbody>();
            collisionEvents = new List<ParticleCollisionEvent>();
        }

        void OnParticleCollision(GameObject other)
        {
            particleSystem = other.GetComponent<ParticleSystem>();

            safeLength = particleSystem.GetSafeCollisionEventSize();
            if (collisionEvents.Count < safeLength)
                collisionEvents = new List<ParticleCollisionEvent>(safeLength);

            power = 1;
            if (ParticleManager.manager.particleObject.Contains(other))
            {
                int num = ParticleManager.manager.particleObject.IndexOf(other);
                power = ParticleManager.manager.GetPower(num);
            }

            numCollisionEvents = particleSystem.GetCollisionEvents(gameObject, collisionEvents);
            
            force = Vector3.zero;
            if (receiveForce)
            {
                int i = 0;
                while (i < numCollisionEvents)
                {
                    force += collisionEvents[i].velocity;
                    i++;
                }
                rigi.AddForce(force * power);
            }

            sendMessageTarget.SendMessage(message, power * numCollisionEvents, SendMessageOptions.DontRequireReceiver);
        }
    }
}