using UnityEngine;

public class Particle : MonoBehaviour
{
    public ParticleSystem particleSystem;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particleSystem.Play();

        }
    }

}
