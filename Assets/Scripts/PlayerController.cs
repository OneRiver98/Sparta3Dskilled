using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    private void FixedUpdate()
    {
        if (CharacterManager.Instance.Player.conditionController.stamina.statValue >= 0f)
        {
            ApplyMove(playerDirectMove);
        }
    }

    private void LateUpdate()
    {
        CameraLookRotate();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && CharacterManager.Instance.Player.IsGrounded() && CharacterManager.Instance.Player.conditionController.stamina.statValue >= 5.0f)
        {
            _rigidbody.AddForce(Vector2.up * trueJumpPower, ForceMode.Impulse);
            CharacterManager.Instance.Player.jumping = true;
        }
    }
}
