using UnityEngine;

[CreateAssetMenu(menuName = "SO/Audio/AudioClipSO")]
public class AudioClipSO : ScriptableObject
{
    [SerializeField] private AudioClip[] audioClips;

    public int GetAudioClipLength() => audioClips.Length;
    public AudioClip GetRandomAudioClip() => audioClips[Random.Range(0, audioClips.Length)];
    public AudioClip GetAudioClipAtIndex(int value) => audioClips[value];
}