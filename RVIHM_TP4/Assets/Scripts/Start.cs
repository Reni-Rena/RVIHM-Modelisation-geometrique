using UnityEngine;

public class Start : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public GameObject StartScreen;


    public void Startgame()
    {
        player.transform.position = target.position;
        StartScreen.SetActive(false);
    }

}
