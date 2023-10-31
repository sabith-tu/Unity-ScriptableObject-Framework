using Sirenix.OdinInspector;
using UnityEngine;

public class AudioPlayerSO : MonoBehaviour
{
    [SerializeField] private AudioClipSO audioClipSO;
    [SerializeField] private bool spawnAnAudioSourceAtRuntime = false;

    [SerializeField] [HideIf(nameof(spawnAnAudioSourceAtRuntime))]
    private AudioSource audioSource;

    private void Awake()
    {
        GetAudioSourceReference();
    }

    void GetAudioSourceReference()
    {
        if (spawnAnAudioSourceAtRuntime)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
        else
        {
            if (audioSource == null) audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayOneRandomly()
    {
        audioSource.PlayOneShot(audioClipSO.GetRandomAudioClip());
    }

    public void PlayOneWithIndex(int value)
    {
        if (value >= audioClipSO.GetAudioClipLength())
        {
            Debug.LogError(
                $"$ at game object {gameObject.name} AudioPlayerSO is trying to play an audio with index out of range - sabi");
            return;
        }

        audioSource.PlayOneShot(audioClipSO.GetAudioClipAtIndex(value));
    }
}