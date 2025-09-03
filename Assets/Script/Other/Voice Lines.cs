using UnityEngine;

public class VoiceLines : MonoBehaviour
{
    [SerializeField] GameObject[] speakers;

    AudioSource audioSource;

    int count;

    public void PlayVoiceLine()
    {
        audioSource = speakers[count].GetComponent<AudioSource>();
        audioSource.Play();
        count++;
    }
}
