using UnityEngine;

public class Power : MonoBehaviour
{
    VariableTeleporter variableTeleporter;
    AudioSource audioSource;
    Animator animator;

    bool state = false;

    private void Start()
    {
        variableTeleporter = GetComponentInParent<VariableTeleporter>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void StartPower()
    {
        if (state) return;

        animator.SetTrigger("TurnOn");
        audioSource.Play();
        variableTeleporter.TurnOn();
        state = true;
    }
}
