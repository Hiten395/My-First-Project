using UnityEngine;

public class Pad : MonoBehaviour
{
    const string BOX_TAG = "Box";
    const string PLAYER_TAG = "Player";

    Animator animator;
    Door door;

    private void Start()
    {
        animator = GetComponent<Animator>();
        door = GetComponentInParent<Door>();
        //FindDoor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(BOX_TAG) || other.gameObject.CompareTag(PLAYER_TAG))
        {
            animator.SetTrigger("Press");
            door.Button(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(BOX_TAG) || other.gameObject.CompareTag(PLAYER_TAG))
        {
            animator.SetTrigger("Release");
            door.Button(-1);
        }
    }
}
