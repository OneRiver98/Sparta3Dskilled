using UnityEngine;

public class ConditionController : MonoBehaviour
{
    private Vector2 noMove = Vector2.zero;

    [HideInInspector]public PlayerCondition playerCondition;

    [HideInInspector]public Condition health { get { return playerCondition.health; } }
    [HideInInspector]public Condition stamina { get { return playerCondition.stamina; } }


    private void Update()
    {
        if(CharacterManager.Instance.Player.inputDirectMove == noMove) // 움직일 때 스테미나 감소
        {
            stamina.Add(stamina.passiveValue * Time.deltaTime);
        }
        else
        {
            CharacterManager.Instance.Player.conditionController.stamina.Subtract(1 * Time.deltaTime);
        }

        if (CharacterManager.Instance.Player.jumping) // 점프 할 때 스테미나 감소
        {
            CharacterManager.Instance.Player.conditionController.stamina.Subtract(5);
            CharacterManager.Instance.Player.jumping = false; // 공중에서 스페이스바 눌러도 체력감소 안 되게 적용
        }
    }
}