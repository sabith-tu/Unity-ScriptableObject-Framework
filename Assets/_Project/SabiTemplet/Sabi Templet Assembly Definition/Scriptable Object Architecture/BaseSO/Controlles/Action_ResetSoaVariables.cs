using UnityEngine;

[AddComponentMenu("_SABI/Action/Action_ResetSoaVariables")]
public class Action_ResetSoaVariables : MonoBehaviour, IExecutable
{
    [SerializeField] [Space(10)] private bool invokeOnStart = true;
    [SerializeField] [Space(10)] private SoaBaseVariable[] soaVariables;

    private void Start()
    {
        if (invokeOnStart) Reset();
    }

    private void Reset()
    {
        foreach (var VARIABLE in soaVariables)
        {
            VARIABLE.Reset();
        }
    }

    public void Execute()
    {
        Reset();
    }
}