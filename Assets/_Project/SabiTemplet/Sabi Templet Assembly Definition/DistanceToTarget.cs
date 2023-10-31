using System.Collections;
using _Project.AI_StateMachine.Interface;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class DistanceToTarget : MonoBehaviour, ITargetSettable
{
    [SerializeField] private float delayInGameLoop = 0.2f;
    [SerializeField] [DisplayAsString] private float distance;


    [SerializeField] private bool checkForTargetDistance = false;

    [SerializeField] [ShowIf(nameof(checkForTargetDistance))]
    private float targetDistance = 10;

    [SerializeField] [DisplayAsString] [ShowIf(nameof(checkForTargetDistance))]
    private bool isFar;

    [SerializeField] [ShowIf(nameof(checkForTargetDistance))]
    private UnityEvent onClose;

    [SerializeField] [ShowIf(nameof(checkForTargetDistance))]
    private UnityEvent onFare;

    private Transform _player;
    private WaitForSeconds _waitForSeconds;


    public void SetTargetTransform(Transform value) => _player = value;

    public float GetDistance() => distance;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(delayInGameLoop);
        StartCoroutine(nameof(DistanceCheckRoutine));
    }

    IEnumerator DistanceCheckRoutine()
    {
        while (true)
        {
            if (_player != null)
            {
                distance = Vector3.Distance(transform.position, _player.position);

                if (checkForTargetDistance)
                {
                    if (distance > targetDistance && !isFar)
                    {
                        isFar = true;
                        onFare.Invoke();
                    }
                    else if (distance <= targetDistance && isFar)
                    {
                        isFar = false;
                        onClose.Invoke();
                    }
                }


                yield return _waitForSeconds;
            }
            else
            {
                yield return null;
            }
        }
    }
}