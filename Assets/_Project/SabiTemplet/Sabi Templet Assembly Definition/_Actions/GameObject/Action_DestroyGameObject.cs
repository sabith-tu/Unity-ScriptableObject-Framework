using Sirenix.OdinInspector;
using UnityEngine;


namespace SABI.GameObject
{
    [AddComponentMenu("_SABI/Action/_GameObject/Action_DestroyGameObject")]
    public class Action_DestroyGameObject : MonoBehaviour , IExecutable
    {
        public enum DestroyGameObjectTypes
        {
            DestroyThis,
            DestroyCustom
        }


        [Space(10)] [SerializeField] private
            DestroyGameObjectTypes destroyGameObjectTypes = DestroyGameObjectTypes.DestroyThis;

        [Space(10)] [SerializeField] [ShowIf("@destroyGameObjectTypes==DestroyGameObjectTypes.DestroyCustom")]
        private UnityEngine.GameObject[] whatToDestroy;

        [Space(10)] [SerializeField] private bool addDelay = false;

        [Space(10)] [SerializeField] [ShowIf("addDelay")]
        private float delay = 1;


        public void DestroyIt()
        {
            foreach (var VARIABLE in whatToDestroy)
            {
                if (addDelay) Destroy(VARIABLE, delay);
                else Destroy(VARIABLE);
            }
        }

        public void DestroyWithReference(UnityEngine.GameObject value)
        {
            Destroy(value);
        }

        private void Awake()
        {
            if (destroyGameObjectTypes == DestroyGameObjectTypes.DestroyThis)
            {
                whatToDestroy = new UnityEngine.GameObject[1];
                whatToDestroy[0] = this.gameObject;
            }
        }

        public void SetDelay(float value) => delay = value;
        public void Execute()
        {
            DestroyIt();
        }
    }
}