using UnityEngine;
using UnityEngine.InputSystem;

public class PlyaerInputController : MonoBehaviour
{
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            CharacterManager.Instance.Player.inputDirectMove = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            CharacterManager.Instance.Player.inputDirectMove = Vector2.zero;
        }
        CharacterManager.Instance.Player.CalCulDirecMove(ref CharacterManager.Instance.Player.inputDirectMove, ref CharacterManager.Instance.Player.playerDirectMove);
        Debug.Log(CharacterManager.Instance.Player.playerDirectMove);
    }
}