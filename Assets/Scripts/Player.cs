using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Player : MonoBehaviour 
{
    [Range(0, 20)]public float speed;

    [Range(0, 100)]public float Health;
    [Range(0, 100)]public float stamina;
    [Range(0, 100)]public float jumpPower;

    [HideInInspector] public int groundRayerMask;

    [HideInInspector]public Vector2 inputDirectMove = Vector2.zero;
    [HideInInspector]public Vector3 playerDirectMove = Vector3.zero;

    [HideInInspector]public Rigidbody _rigidbody;

    
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        groundRayerMask = LayerMask.GetMask("Ground");
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void CalCulDirecMove(ref Vector2 direction1, ref Vector3 direction2)
    {
        direction2 = transform.forward * direction1.y + transform.right * direction1.x;
        direction2.y = _rigidbody.velocity.y;
    }

    public void ApplyMove(Vector3 direction)
    {
        direction.y = _rigidbody.velocity.y;
        _rigidbody.velocity = direction;
    }

    public bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 2f, groundRayerMask))
            {
                return true;
            }
        }

        return false;
    }
}
