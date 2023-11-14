using System.Collections;
using System.Collections.Generic;
using SABI.SOA;
using UnityEngine;

[AddComponentMenu("_SABI/Data/IntSceneVariable")]
public class IntSceneVariable : MonoBehaviour
{
    [SerializeField] private IntReference value;

    public int GetValue() => value.GetValue();
    
    public void SetValue(int newValue) => value.SetValue(newValue);
}
