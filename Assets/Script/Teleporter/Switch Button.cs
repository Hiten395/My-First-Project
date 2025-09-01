using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    AudioSource audioSource;
    VariableTeleporter variableTeleporter;

    private void Start()
    {
        variableTeleporter = GetComponentInParent<VariableTeleporter>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Switch()
    {
        audioSource.Play();
        variableTeleporter.Switch(1);
    }
}
