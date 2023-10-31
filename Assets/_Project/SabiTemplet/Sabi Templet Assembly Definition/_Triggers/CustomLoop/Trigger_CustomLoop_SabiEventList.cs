using System.Collections;
using SABI.SOA;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Trigger/_Trigger_CustomLoop/SabiEventList")]
    public class Trigger_CustomLoop_SabiEventList : SerializedMonoBehaviour
    {
        [Space(10)][SerializeField] private bool isActive = true;

        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        [Range(0.1f, 3f)]
        private float delayInLoop = 0.25f;

        [Space(10)]
        [HideReferenceObjectPicker]
        [EnableIf("isActive")]
        [SerializeField]
        private SabiEventAdvanced whatToInvoke = new();

        [Space(10)] private WaitForSeconds _waitForSeconds;

        private void OnEnable()
        {
            if (isActive) StartCoroutine(nameof(CustomRoutine));
        }

        private void OnDisable() => StopAllCoroutines();

        private void Start() => _waitForSeconds = new WaitForSeconds(delayInLoop);

        IEnumerator CustomRoutine()
        {
            while (true)
            {
                whatToInvoke.Invoke();
                yield return _waitForSeconds;
            }
        }
    }
}