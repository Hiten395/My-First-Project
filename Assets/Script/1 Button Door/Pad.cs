using UnityEngine;

public class Pad : MonoBehaviour
{
    const string BOX_TAG = "Box";
    const string PLAYER_TAG = "Player";

    Transform parent;
    Animator animator;
    Door door;

    private void Start()
    {
        animator = GetComponent<Animator>();
        FindDoor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(BOX_TAG) || other.gameObject.CompareTag(PLAYER_TAG))
        {
            animator.SetTrigger("Press");
            door.Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(BOX_TAG) || other.gameObject.CompareTag(PLAYER_TAG))
        {
            animator.SetTrigger("Release");
            door.Close();
        }
    }

    private void FindDoor()
    {
        parent = transform.parent.transform.parent;

        // the door should be above the button in the hierchy 

        Transform child = parent.GetChild(0);

        door = child.gameObject.GetComponent<Door>();
    }
}
