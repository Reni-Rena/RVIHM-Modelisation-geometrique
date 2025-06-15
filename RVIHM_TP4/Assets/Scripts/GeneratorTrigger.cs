using UnityEngine;
using Unity.AI.Navigation;

public class GeneratorTrigger : MonoBehaviour
{
    public GameObject obstacle;
    public NavMeshSurface surface;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            obstacle.SetActive(false);
            surface.BuildNavMesh();
        }
    }
}
