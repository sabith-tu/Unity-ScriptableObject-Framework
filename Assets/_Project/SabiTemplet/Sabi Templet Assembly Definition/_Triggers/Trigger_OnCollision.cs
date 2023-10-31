using System;

namespace SABI.Invoke
{
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnityEngine.Events;

    [AddComponentMenu("_SABI/Trigger/Trigger_OnCollision")]
    public class Trigger_OnCollision : SerializedMonoBehaviour
    {
        [Space(10)]
        [SerializeField]
        [TabGroup("Settings")]
        private bool isActive = true;

        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        [TabGroup("Settings")]
        private TagCheckModes tagCheckModes = TagCheckModes.CheckForPlayerTag;

        [Space(10)]
        [EnableIf("isActive")]
        [ShowIf("@tagCheckModes == TagCheckModes.CustomTag")]
        [SerializeField]
        [TabGroup("Settings")]
        private string tagToCheck;

        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        [TabGroup("Settings")]
        private bool shouldLog = false;

        [Space(10)]
        [EnableIf("isActive")]
        [ShowIf("shouldLog")]
        [SerializeField]
        [TabGroup("Settings")]
        private string customMessage;

        [Header("Collided GameObject Control")]
        [Space(10)]
        [SerializeField]
        [TabGroup("Settings")]
        private bool shouldSaveReference = false;

        [Space(10)]
        [SerializeField]
        [TabGroup("Settings")]
        private bool shouldInvokeUnityEventWithReference = false;

        [Space(10)]
        [SerializeField]
        [ShowIf("shouldInvokeUnityEventWithReference")]
        [TabGroup("Settings")]
        private UnityEvent<GameObject> onCollidedWithReference;

        [Space(10)]
        [SerializeField]
        [TabGroup("Settings")]
        private bool shouldDestroyIt = false;


        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        [TabGroup("Trigger")]
        private bool isTriggerEnterActive;

        [Space(10)]
        [ShowIf("isTriggerEnterActive")]
        [SerializeField]
        [TabGroup("Trigger")]
        [HideReferenceObjectPicker]
        private SabiEventAdvanced InvokeOnTriggerEnter = new();


        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        [TabGroup("Trigger")]
        private bool isTriggerExitActive;

        [Space(10)]
        [ShowIf("isTriggerExitActive")]
        [SerializeField]
        [TabGroup("Trigger")]
        [HideReferenceObjectPicker]
        private SabiEventAdvanced InvokeOnTriggerExit = new();


        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        [TabGroup("Collision")]
        private bool isColliderEnterActive;

        [Space(10)]
        [ShowIf("isColliderEnterActive")]
        [SerializeField]
        [TabGroup("Collision")]
        [HideReferenceObjectPicker]
        private SabiEventAdvanced InvokeOnColliderEnter = new();


        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        [TabGroup("Collision")]
        private bool isColliderExitActive;

        [Space(10)]
        [ShowIf("isColliderExitActive")]
        [SerializeField]
        [TabGroup("Collision")]
        [HideReferenceObjectPicker]
        private SabiEventAdvanced InvokeOnColliderExit = new();


        private GameObject lastCollidedObject;

        private void Start()
        {
            if (tagCheckModes == TagCheckModes.CheckForPlayerTag && isActive) tagToCheck = "Player";
        }

        private void OnCollisionEnter(Collision other)
        {
            if (isActive == false) return;
            if ((other.collider.CompareTag(tagToCheck) == false) &&
                (tagCheckModes != TagCheckModes.DontCheckTag)) return;
            if (isColliderEnterActive == false) return;

            if (shouldLog)
                Debug.Log(
                    $" Collision Enter with tag {tagToCheck} from game object {other.gameObject.name} : {customMessage} ");
            ControlCollided(other.gameObject);
            InvokeOnColliderEnter.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isActive == false) return;
            if ((other.CompareTag(tagToCheck) == false) && (tagCheckModes != TagCheckModes.DontCheckTag)) return;
            if (isTriggerEnterActive == false) return;

            if (shouldLog)
                Debug.Log(
                    $" Trigger Enter with tag {tagToCheck}  from game object {other.gameObject.name} : {customMessage} ");
            ControlCollided(other.gameObject);
            InvokeOnTriggerEnter.Invoke();
        }

        private void OnCollisionExit(Collision other)
        {
            if (isActive == false) return;
            if ((other.collider.CompareTag(tagToCheck) == false) &&
                (tagCheckModes != TagCheckModes.DontCheckTag)) return;
            if (isColliderExitActive == false) return;

            if (shouldLog)
                Debug.Log(
                    $" Collision Exit with tag {tagToCheck}  from game object {other.gameObject.name} : {customMessage} ");
            InvokeOnColliderExit.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (isActive == false) return;
            if ((other.CompareTag(tagToCheck) == false) && (tagCheckModes != TagCheckModes.DontCheckTag)) return;
            if (isTriggerExitActive == false) return;

            if (shouldLog)
                Debug.Log(
                    $" Trigger Exit with tag {tagToCheck}  from game object {other.gameObject.name} : {customMessage} ");
            InvokeOnTriggerExit.Invoke();
        }

        void ControlCollided(GameObject value)
        {
            if (shouldSaveReference)
                lastCollidedObject = value;

            if (shouldInvokeUnityEventWithReference)
                onCollidedWithReference.Invoke(value);

            if (shouldDestroyIt)
                Destroy(value);
        }

        public GameObject GetLastCollidedGameObject() => lastCollidedObject;

        public enum TagCheckModes
        {
            DontCheckTag,
            CheckForPlayerTag,
            CustomTag
        }
    }
}