using System.Collections;
using System.Collections.Generic;
using SABI.SOA;
using UnityEngine;

[AddComponentMenu("_SABI/Data/FloatSceneVariable")]
public class FloatSceneVariable : MonoBehaviour
{
    [SerializeField] private FloatReference value;

    public float GetValue() => value.GetValue();
    
    public void SetValue(float newValue) => value.SetValue(newValue);
}
