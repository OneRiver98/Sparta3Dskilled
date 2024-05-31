using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public Condition health;
    public Condition stamina;

    private void Start()
    {
        CharacterManager.Instance.Player.conditionController.playerCondition = this;
    }
}