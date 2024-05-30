using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    private void FixedUpdate()
    {
         ApplyMove(playerDirectMove);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && CharacterManager.Instance.Player.IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }
}
