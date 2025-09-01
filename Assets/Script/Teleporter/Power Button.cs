using UnityEngine;

public class PowerButton : MonoBehaviour
{
    VariableTeleporter variableTeleporter;
    Animator animator;
    AudioSource audioSource;

    [SerializeField] AudioClip turnOn;
    [SerializeField] AudioClip turnOff;

    const string BOX_TAG = "Box";
    const string PLAYER_TAG = "Player";

    private void Start()
    {
        variableTeleporter = GetComponentInParent<VariableTeleporter>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.clip = turnOn;
        audioSource.Play();

        if (other.gameObject.CompareTag(BOX_TAG) || other.gameObject.CompareTag(PLAYER_TAG))
        {
            animator.SetTrigger("Press");
            variableTeleporter.TurnOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        audioSource.clip = turnOff;
        audioSource.Play();

        if (other.gameObject.CompareTag(BOX_TAG) || other.gameObject.CompareTag(PLAYER_TAG))
        {
            animator.SetTrigger("Release");
            variableTeleporter.TurnOff();
        }
    }
}
