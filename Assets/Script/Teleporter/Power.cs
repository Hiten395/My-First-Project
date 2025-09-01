using UnityEngine;

public class Power : MonoBehaviour
{
    VariableTeleporter variableTeleporter;
    AudioSource audioSource;

    bool state = false;

    private void Start()
    {
        variableTeleporter = GetComponentInParent<VariableTeleporter>();
        audioSource = GetComponent<AudioSource>();
    }

    public void StartPower()
    {
        if (state) return;

        audioSource.Play();
        variableTeleporter.TurnOn();
        state = true;
    }
}
