using UnityEngine;

public class Player : MonoBehaviour 
{
    [Range(0, 20)]public float speed;

    [Range(0, 100)]public float Health;
    [Range(0, 100)]public float stamina;
    [Range(0, 100)]public float jumpPower;

    [HideInInspector]public Vector2 inputDirectMove = Vector2.zero;
    [HideInInspector]public Vector3 playerDirectMove = Vector3.zero;

    [HideInInspector]public Rigidbody _rigidbody;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void CalCulDirecMove(ref Vector2 direction1, ref Vector3 direction2)
    {
        direction2 = transform.forward * direction1.y + transform.right * direction1.x;
        direction2.y = _rigidbody.velocity.y;
    }

    public void ApplyMove(Vector3 direction)
    {
        _rigidbody.velocity = direction * speed;
    }
}
