using System.Collections;
using System.Collections.Generic;
using SABI.SOA;
using UnityEngine;

[AddComponentMenu("_SABI/Data/BoolSceneVariable")]
public class BoolSceneVariable : MonoBehaviour
{
    [SerializeField] private BoolReference value;

    public bool GetValue() => value.GetValue();
    
    public void SetValue(bool newValue) => value.SetValue(newValue);
}
