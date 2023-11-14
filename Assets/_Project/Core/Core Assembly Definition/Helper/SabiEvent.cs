using System.Collections.Generic;
using SABI.Helper;
using SABI.SOA;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class SabiEvent
{



    [SerializeField][Space(5)] private string NameOfEvent;
    [SerializeField][Space(5)] private bool isActive = true;


    [FoldoutGroup("Modifiers")]
    [SerializeField]
    [Space(5)]
    private bool useChanceModifier;

    [FoldoutGroup("Modifiers")]
    [SerializeField, ShowIf("useChanceModifier"), Range(0.01f, 1f)]
    [Space(5)]
    private float chance = 0.5f;


    [FoldoutGroup("UnityEvent")]
    [SerializeField]
    [Space(5)]
    private bool useUnityEvent;

    [FoldoutGroup("UnityEvent")]
    [HideReferenceObjectPicker]
    [SerializeField, ShowIf("useUnityEvent")]
    [Space(5)]
    private UnityEvent unityEvent = new();

    [FoldoutGroup("ActionReference")]
    [SerializeField]
    [Space(5)]
    private bool useActionReference;

    [FoldoutGroup("ActionReference")]
    [HideReferenceObjectPicker]
    [SerializeField, ShowIf("useActionReference")]
    [Space(5)]
    private ActionReference actionReference = new();


    [FoldoutGroup("IExecutable")]
    [SerializeField]
    [Space(5)]
    private bool useIExecutable;

    [FoldoutGroup("IExecutable")]
    [HideReferenceObjectPicker]
    [SerializeField, ShowIf("useIExecutable")]
    [Space(5)]
    private List<IExecutable> iExecutableList = new();


    public void Invoke()
    {
        if (!isActive) return;

        if (useChanceModifier)
        {
            if (Chance.GetRandomChance(chance))
            {
                InvokeSabiEvent();
            }
        }
        else
        {
            InvokeSabiEvent();
        }
    }

    public void InvokeSabiEvent()
    {
        if (useUnityEvent) unityEvent.Invoke();
        if (useActionReference) actionReference.InvokeAction();
        if (useIExecutable)
        {
            foreach (var iExecutable in iExecutableList)
            {
                iExecutable.Execute();
            }
        }
    }
}

public class SabiEventAdvanced
{
    enum SabiEventModes
    {
        UnityEvent,
        SabiEvent,
        ListOfSabiEvent
    }
    [BoxGroup]
    [SerializeField]
    [PropertySpace(SpaceAfter = 10)]
    SabiEventModes mode = SabiEventModes.UnityEvent;
    [BoxGroup]
    [HideReferenceObjectPicker]
    [ShowIf("@mode == SabiEventModes.UnityEvent")]
    [SerializeField]
    private UnityEvent whatToInvoke = new();
    [BoxGroup]
    [HideReferenceObjectPicker]
    [ShowIf("@mode == SabiEventModes.SabiEvent")]
    [SerializeField]
    private SabiEvent sabiEvent = new();
    [BoxGroup]
    [HideReferenceObjectPicker]
    [ShowIf("@mode == SabiEventModes.ListOfSabiEvent")]
    [SerializeField]
    private List<SabiEvent> sabiEventList = new();

    public void Invoke()
    {
        switch (mode)
        {
            case SabiEventModes.UnityEvent:
                whatToInvoke.Invoke();
                break;
            case SabiEventModes.SabiEvent:
                sabiEvent.Invoke();
                break;
            case SabiEventModes.ListOfSabiEvent:
                foreach (var sabiEvent in sabiEventList)
                {
                    sabiEvent.Invoke();
                }
                break;
        }
    }
}