using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SABI.GameObject
{
    [AddComponentMenu("_SABI/Action/_GameObject/Action_SpawnGameObjects")]
    public class Action_SpawnGameObjects : MonoBehaviour, IExecutable
    {
        [Space(10)] [TabGroup("Settings")] [SerializeField]
        private bool invokeOnStart = false;


        [Space(10)] [TabGroup("Settings")] [SerializeField]
        private SpawnGameObjectOnStartModes mode = SpawnGameObjectOnStartModes.Nothing;

        [TabGroup("Settings")]
        [ShowIf("@onStart==SpawnGameObjectOnStartModes.SpawnOneWithIndex")]
        [Space(10)]
        [SerializeField]
        private int spawnOnStartIndex = 0;

        [TabGroup("Settings")]
        [ShowIf("@onStart==SpawnGameObjectOnStartModes.SpawnMultipleWithRandom")]
        [SerializeField]
        [Space(10)]
        private int howMuchItemsToSpawn = 2;

        [TabGroup("Settings")] [SerializeField] [Space(10)]
        private Vector3 spawnPositionOffset;

        [TabGroup("Settings")] [SerializeField] [Space(10)]
        private bool UseSpawnPositionRandomness = false;

        [TabGroup("Settings")] [ShowIf("UseSpawnPositionRandomness")] [SerializeField] [Space(10)]
        private Vector3 spawnPositionRandomnessMinimum;

        [TabGroup("Settings")] [ShowIf("UseSpawnPositionRandomness")] [SerializeField] [Space(10)]
        private Vector3 spawnPositionRandomnessMaximum;

        [TabGroup("Settings")] [SerializeField] [Space(10)]
        private bool spawnAtParentPosition = true;

        [TabGroup("Settings")] [HideIf("spawnAtParentPosition")] [SerializeField] [Space(10)]
        private Transform customPositionToSpawn;

        [TabGroup("Settings")] [SerializeField] [Space(10)]
        private SpawnRotation spawnRotation = SpawnRotation.QurtaionIdentity;

        [TabGroup("Settings")] [SerializeField] [ShowIf("@spawnRotation==SpawnRotation.Custom")] [Space(10)]
        private Vector3 customRotation;

        [TabGroup("References")] [SerializeField] [Space(10)]
        private bool resetReferenceWithChildrenOnAwake = false;

        private Quaternion _spawnRotation;
        private Vector3 _spawnPosition;

        [TabGroup("References")] [SerializeField] [Space(10)]
        private List<UnityEngine.GameObject> allItems;


        private void Awake() => ResetReferenceWithChildren();

        [TabGroup("References")]
        [Button]
        [PropertySpace(25)]
        void ResetReferenceWithChildren()
        {
            if (resetReferenceWithChildrenOnAwake)
            {
                int childCount = transform.childCount;
                if (childCount == 0) return;
                allItems = new List<UnityEngine.GameObject>();

                for (int i = 0; i < childCount; i++)
                {
                    allItems.Add(transform.GetChild(i).gameObject);
                }
            }
        }

        public void AddNewItemToSpawner(UnityEngine.GameObject newItem) => allItems.Add(newItem);


        private void Start()
        {
            if (invokeOnStart) InvokeBasedOnMode();
        }

        public void InvokeBasedOnMode()
        {
            if (mode == SpawnGameObjectOnStartModes.SpawnOneWithIndex) SpawnOneWithIndex(spawnOnStartIndex);

            else if (mode == SpawnGameObjectOnStartModes.SpawnOneRandomly) SpawnOneRandomly();

            else if (mode == SpawnGameObjectOnStartModes.SpawnMultipleWithRandom)
                SpawnMultipleRandomly(howMuchItemsToSpawn);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawCube(
                new Vector3(
                    spawnPositionOffset.x + transform.position.x,
                    spawnPositionOffset.y + transform.position.y,
                    spawnPositionOffset.z + transform.position.z
                ),
                new Vector3(
                    +(spawnPositionRandomnessMaximum.x * 2) + 0.8f,
                    +(spawnPositionRandomnessMaximum.y * 2) + 0.8f,
                    +(spawnPositionRandomnessMaximum.z * 2) + 0.8f
                ));
        }


        [TabGroup("Control")]
        [Button]
        public void SpawnOneWithIndex() => SpawnOneWithIndex(spawnOnStartIndex);

        public void SpawnOneWithIndex(int index)
        {
            if ((index < allItems.Count) && (index >= 0))
            {
                _spawnPosition = spawnAtParentPosition ? transform.position : customPositionToSpawn.position;
                _spawnPosition += spawnPositionOffset;

                if (UseSpawnPositionRandomness)
                {
                    _spawnPosition += new Vector3(
                        Random.Range(spawnPositionRandomnessMinimum.x, spawnPositionRandomnessMaximum.x),
                        Random.Range(spawnPositionRandomnessMinimum.y, spawnPositionRandomnessMaximum.y),
                        Random.Range(spawnPositionRandomnessMinimum.z, spawnPositionRandomnessMaximum.z)
                    );
                }


                switch (spawnRotation)
                {
                    case SpawnRotation.QurtaionIdentity:
                        _spawnRotation = Quaternion.identity;
                        break;
                    case SpawnRotation.GameobjectRotation:
                        _spawnRotation = transform.rotation;
                        break;
                    case SpawnRotation.Custom:
                        _spawnRotation = Quaternion.Euler(customRotation);
                        break;
                }

                Instantiate(allItems[index], _spawnPosition, _spawnRotation);
            }
            else
            {
                Debug.LogWarning("EnableOneWithIndex Out of range index = " + index +
                                 " Possible values = 0 - " + allItems.Count);
            }
        }

        int DoGetMaximumIndex() => allItems.Count;

        [TabGroup("Control")]
        [Button]
        public void SpawnOneRandomly() => SpawnOneWithIndex(Random.Range(0, allItems.Count));

        [TabGroup("Control")]
        [Button]
        public void SpawnMultipleRandomly() => SpawnMultipleRandomly(howMuchItemsToSpawn);

        public void SpawnMultipleRandomly(int howMuchItemsToSpawn)
        {
            ;

            if (howMuchItemsToSpawn > DoGetMaximumIndex())
            {
                Debug.LogError(" Cant enable more items than it have at game object " + gameObject.name + " - sabi");
                return;
            }


            while (howMuchItemsToSpawn > 0)
            {
                int itemToShow = Random.Range(0, DoGetMaximumIndex());
                if (!allItems[itemToShow].activeInHierarchy)
                {
                    allItems[itemToShow].SetActive(true);
                    howMuchItemsToSpawn--;
                }
            }
        }

        public enum SpawnRotation
        {
            QurtaionIdentity,
            GameobjectRotation,
            Custom
        }

        public enum SpawnGameObjectOnStartModes
        {
            Nothing,
            SpawnOneWithIndex,
            SpawnOneRandomly,
            SpawnMultipleWithRandom
        }

        public void Execute()
        {
            InvokeBasedOnMode();
        }
    }
}