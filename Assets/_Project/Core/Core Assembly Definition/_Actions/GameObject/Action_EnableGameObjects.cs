using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SABI.GameObject
{
    [AddComponentMenu("_SABI/Action/_GameObject/Action_EnableGameObjects")]
    public class Action_EnableGameObjects : MonoBehaviour, IExecutable
    {
        [Space(10)]
        [TabGroup("Settings")]
        [SerializeField]
        private bool invokeOnStart = false;

        [Space(10)]
        [TabGroup("Settings")]
        [SerializeField]
        private EnableGameObjectOnStartModes mode = EnableGameObjectOnStartModes.Nothing;

        [Space(10)]
        [TabGroup("Settings")]
        [ShowIf("@mode==EnableGameObjectOnStartModes.EnableOneWithIndex")]
        [SerializeField]
        private int activateOnStartIndex = 0;

        [Space(10)]
        [TabGroup("Settings")]
        [ShowIf("@mode==EnableGameObjectOnStartModes.EnableMultipleWithRandom")]
        [SerializeField]
        private int howMuchToEnable = 2;

        [Space(10)]
        [TabGroup("Settings")]
        [SerializeField]
        private bool disableEverythingElse = true;

        [Space(10)]
        [TabGroup("Settings")]
        [SerializeField]
        private bool useModulusOfIndex = false;

        [Space(10)]
        [TabGroup("References")]
        [SerializeField]
        private bool resetReferenceWithChildrenOnAwake = false;

        [Space(10)]
        [Space(10)]
        [TabGroup("References")]
        [SerializeField]
        private UnityEngine.GameObject[] allItems;

        private int _currentEnabledItem = 0;

        private void Awake()
        {
            if (resetReferenceWithChildrenOnAwake)
            {
                ResetReferenceWithChildren();
            }
        }

        [TabGroup("References")]
        [Button]
        [PropertySpace(25)]
        void ResetReferenceWithChildren()
        {

            int childCount = transform.childCount;
            if (childCount == 0) return;
            allItems = new UnityEngine.GameObject[childCount];

            for (int i = 0; i < childCount; i++)
            {
                allItems[i] = transform.GetChild(i).gameObject;
            }

        }

        private void Start()
        {
            if (invokeOnStart) InvokeBasedOnMode();
        }

        public void InvokeBasedOnMode()
        {
            if (mode == EnableGameObjectOnStartModes.EnableOneWithIndex) EnableOneWithIndex(activateOnStartIndex);

            else if (mode == EnableGameObjectOnStartModes.EnableOneRandomly) EnableOneRandomly();

            else if (mode == EnableGameObjectOnStartModes.EnableMultipleWithRandom)
                EnableMultipleRandomly(howMuchToEnable);
        }

        [ContextMenu("FillAllItemsWithChild")]
        void FillAllItemsWithChild()
        {
            foreach (var VARIABLE in GetComponentsInChildren<Transform>())
            {
                allItems.Append(VARIABLE.gameObject);
            }
        }

        void DisableAll()
        {
            foreach (var VARIABLE in allItems)
            {
                VARIABLE.SetActive(false);
            }
        }

        [TabGroup("Control")]
        [Button]
        public void EnableMultipleRandomly() => EnableMultipleRandomly(howMuchToEnable);


        public void EnableMultipleRandomly(int howMuchItemsToEnable)
        {
            DisableAll();

            if (howMuchItemsToEnable > DoGetMaximumIndex())
            {
                Debug.LogError(" Cant enable more items than it have at game object " + gameObject.name + " - sabi");
                return;
            }

            while (howMuchItemsToEnable > 0)
            {
                int itemToShow = Random.Range(0, DoGetMaximumIndex());
                if (!allItems[itemToShow].activeInHierarchy)
                {
                    allItems[itemToShow].SetActive(true);
                    howMuchItemsToEnable--;
                }
            }
        }

        [TabGroup("Control")]
        [Button]
        public void EnableOneWithIndex() => EnableOneWithIndex(activateOnStartIndex);

        public void EnableOneWithIndex(int index)
        {
            if (disableEverythingElse) DisableAll();

            if ((index < allItems.Length) && (index >= 0))
            {
                allItems[index].SetActive(true);
                _currentEnabledItem = index;
            }
            else
            {
                if (useModulusOfIndex)
                {
                    int newIndex = index % DoGetMaximumIndex() + 1;
                    allItems[newIndex].SetActive(true);
                    _currentEnabledItem = newIndex;
                }
                else
                {
                    Debug.LogWarning("EnableOneWithIndex Out of range index = " + index + " Possible values = 0 - " +
                                     allItems.Length);
                }
            }
        }

        public int DoGetMaximumIndex() => allItems.Length;

        [TabGroup("Control")]
        [Button]
        public void EnableOneRandomly()
        {
            if (disableEverythingElse) DisableAll();
            allItems[Random.Range(0, allItems.Length)].SetActive(true);
        }

        [TabGroup("Control")]
        [Button]
        public void EnableNextItemWithRepeat()
        {
            if (_currentEnabledItem + 1 == DoGetMaximumIndex()) EnableOneWithIndex(0);
            else
            {
                EnableOneWithIndex(_currentEnabledItem + 1);
            }
        }

        [TabGroup("Control")]
        [Button]
        public void EnablePreviewsItemWithRepeat()
        {
            if (_currentEnabledItem - 1 == -1) EnableOneWithIndex(DoGetMaximumIndex() - 1);
            else EnableOneWithIndex(_currentEnabledItem - 1);
        }

        [TabGroup("Control")]
        [Button]
        public void EnableNextItem() =>
            EnableOneWithIndex(Mathf.Clamp(_currentEnabledItem + 1, 0, DoGetMaximumIndex()));

        [TabGroup("Control")]
        [Button]
        public void EnablePreviewsItem() =>
            EnableOneWithIndex(Mathf.Clamp(_currentEnabledItem - 1, 0, DoGetMaximumIndex()));

        public enum EnableGameObjectOnStartModes
        {
            Nothing,
            EnableOneWithIndex,
            EnableOneRandomly,
            EnableMultipleWithRandom
        }

        public void Execute()
        {
            InvokeBasedOnMode();
        }
    }
}