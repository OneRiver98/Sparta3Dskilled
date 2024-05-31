using UnityEngine;

public class Player : MonoBehaviour 
{
    [Range(0, 20)]public float speed;
    [Range(0, 100)]public float jumpPower;
    protected float trueJumpPower;
    [HideInInspector]public bool jumping = false;

    [Range(-100, 100)]public float minXLook;
    [Range(-100, 100)]public float maxXLook;
    [Range(0, 100)]public float lookSensitivity;
    private float camCurXRot;

    [HideInInspector]public int groundRayerMask;

    [HideInInspector]public Vector2 inputDirectMove = Vector2.zero;
    [HideInInspector]public Vector3 playerDirectMove = Vector3.zero;
    
    [HideInInspector]public Vector2 mouseDelta = Vector2.zero;

    [HideInInspector]public Rigidbody _rigidbody;
    public Animator jumpPlatformAnim;

    [SerializeField]private Transform cameraContainer;

    [HideInInspector]public ConditionController conditionController;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        groundRayerMask = LayerMask.GetMask("Ground");
        _rigidbody = GetComponent<Rigidbody>();
        conditionController = GetComponent<ConditionController>();

        trueJumpPower = jumpPower;
    }

    public void CalCulDirecMove(ref Vector2 vector2, ref Vector3 vector3) // 인풋시스템 wasd 받은 값을 vector3로 바꿔서 앞뒤좌우 움직임 계산
    {
        vector3 = transform.forward * vector2.y + transform.right * vector2.x;
    }

    public void ApplyMove(Vector3 direction)
    {
        direction *= speed;
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
            if (Physics.Raycast(rays[i], 1.5f, groundRayerMask))
            {
                return true;
            }
        }

        return false;
    }

    public void CameraLookRotate()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("JumpingPlatform"))
        {
            trueJumpPower = 30;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("JumpingPlatform"))
        {
            trueJumpPower = jumpPower;
            jumpPlatformAnim.SetTrigger("useJump");
        }
    }
}
