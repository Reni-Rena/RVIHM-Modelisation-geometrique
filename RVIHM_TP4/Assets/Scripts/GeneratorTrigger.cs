using UnityEngine;
using Unity.AI.Navigation;

public class GeneratorTrigger : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public NavMeshSurface surface;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            obstacle1.SetActive(false);
            obstacle2.SetActive(false);
            surface.BuildNavMesh();
        }
    }
}
