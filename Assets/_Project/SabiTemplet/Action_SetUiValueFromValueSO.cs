using TMPro;
using UnityEngine;

[AddComponentMenu("_SABI/Action/Action_SetUiValueFromValueSO")]
public class Action_SetUiValueFromValueSO : MonoBehaviour, IExecutable
{
    [Space(10)][SerializeField] private TextMeshProUGUI text;
    [Space(10)][SerializeField] private string textBefore;
    [Space(10)][SerializeField] private SoaBaseVariable soaBaseVariable;
    [Space(10)][SerializeField] private string textAfter;


    private void Awake()
    {
        if (text == null) text = GetComponent<TextMeshProUGUI>();
        UpdateUi();
    }

    private void OnEnable() => soaBaseVariable.OnValueChange += UpdateUi;

    private void OnDisable() => soaBaseVariable.OnValueChange -= UpdateUi;

    void UpdateUi() => text.text = textBefore + soaBaseVariable.GetValueAsString() + textAfter;

    public void Execute()
    {
        UpdateUi();
    }
}