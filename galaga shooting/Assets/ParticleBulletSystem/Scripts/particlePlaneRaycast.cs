using UnityEngine;
using System.Collections;

namespace ParticleBulletSystem
{
    public class particlePlaneRaycast : MonoBehaviour
    {
        [Tooltip("Number for reference in particlemanager the variable particle\nParticle")]
        public int number;
        [Tooltip("This bullet of destination, it will show the sight.. If you specify this, Number is ignored.")]
        public ParticleSystem particle;
        private ParticleSystem.Particle[] particles;
        [Tooltip("ParticleSystem to use as the target site")]
        public ParticleSystem hitParticle;
        [Tooltip("To be used in PlaneRaycast. Plane spread up and right of Transform")]
        public Transform planeObject;

        int length;
        ParticleSystem.EmitParams em;
        Plane plane;
        Ray ray;
        float rayDistance;

        void Start()
        {
            if (particle == null)
            {
                particle = ParticleManager.manager.particle[number];
            }
            particles = new ParticleSystem.Particle[particle.main.maxParticles];
            if (planeObject == null)
            {
                planeObject = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        // Update is called once per frame
        void Update()
        {
            length = particle.GetParticles(particles);
            hitParticle.Clear();
            if (length <= 0)
                return;

            em = ParticleManager.manager.emitParamsDefault;
            plane = new Plane(planeObject.forward, planeObject.position);

            for (int i = 0; i < length; i++)
            {
                ray.origin = particles[i].position;
                ray.direction = particles[i].velocity;

                if (plane.Raycast(ray, out rayDistance))
                {
                    em.position = ray.GetPoint(rayDistance);
                    em.velocity = Vector3.zero;
                    em.startLifetime = 1.0f;
                    em.startSize = particles[i].GetCurrentSize(particle);

                    hitParticle.Emit(em, 1);
                }
            }
        }
    }
}