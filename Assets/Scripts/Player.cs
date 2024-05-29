using UnityEngine;

public class Player : MonoBehaviour 
{
    [Range(0, 20)] public float speed;

    [Range(0, 100)] public float Health;
    [Range(0, 100)] public float stamina;

    
    private void start()
    {

    }
}