using UnityEngine;

public class PowerButton : MonoBehaviour
{
    VariableTeleporter variableTeleporter;
    Animator animator;

    const string BOX_TAG = "Box";
    const string PLAYER_TAG = "Player";

    private void Start()
    {
        variableTeleporter = GetComponentInParent<VariableTeleporter>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(BOX_TAG) || other.gameObject.CompareTag(PLAYER_TAG))
        {
            animator.SetTrigger("Press");
            variableTeleporter.TurnOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(BOX_TAG) || other.gameObject.CompareTag(PLAYER_TAG))
        {
            animator.SetTrigger("Release");
            variableTeleporter.TurnOff();
        }
    }
}
