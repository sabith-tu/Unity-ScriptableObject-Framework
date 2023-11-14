using System.Collections;
using System.Collections.Generic;
using SABI.SOA;
using UnityEngine;

[AddComponentMenu("_SABI/Data/StringSceneVariable")]
public class StringSceneVariable : MonoBehaviour
{
    [SerializeField] private StringReference value;

    public string GetValue() => value.GetValue();
    
    public void SetValue(string newValue) => value.SetValue(newValue);
}
