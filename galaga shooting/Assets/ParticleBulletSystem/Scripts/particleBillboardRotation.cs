using UnityEngine;
using System.Collections;
namespace ParticleBulletSystem
{
    [RequireComponent(typeof(ParticleSystem))]
    public class particleBillboardRotation : MonoBehaviour
    {
        [Tooltip("If you do not set this, MainCamera will be applied automatically.")]
        public Transform cam;
        private ParticleSystem particle;
        private ParticleSystem.Particle[] particles;
        
        int length;
        double angle;
        Vector3 cross;
        Vector3 up;

        // Use this for initialization
        void Start()
        {
            if (cam == null)
            {
                cam = Camera.main.transform;
            }
            particle = GetComponent<ParticleSystem>();
            particles = new ParticleSystem.Particle[particle.main.maxParticles];
        }

        // Update is called once per frame
        void LateUpdate()
        {
            length = particle.GetParticles(particles);
            up = cam.up;
            for (int i = 0; i < length; i++)
            {
                angle = Vector3.Angle(up, particles[i].velocity);
                cross = Vector3.Cross(up, particles[i].velocity);
                if (cross.y < 0)
                {
                    angle = -angle;
                }
                particles[i].rotation = (float)angle;
            }
            particle.SetParticles(particles, length);
        }
    }
}