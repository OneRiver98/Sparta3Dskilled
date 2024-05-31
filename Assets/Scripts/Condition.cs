using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    [Range(0,100)]public float statValue;
    [HideInInspector]private float maxValue;
    public float passiveValue;

    [SerializeField]private Image uiBar;

    private void Awake()
    {
        maxValue = statValue;
    }

    private void Update()
    {
        uiBar.fillAmount = GetPercenttage();
    }

    private float GetPercenttage()
    {
        return statValue / maxValue;
    }

    public void Add(float value)
    {
        statValue = Mathf.Min(statValue + value, maxValue);
    }

    public void Subtract(float value)
    {
        if (statValue <= 0.000000000f) return;
        statValue = statValue - value;
    }
}