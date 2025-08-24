using UnityEngine;

public class TwoTriggerButtonSecond : MonoBehaviour
{
    const string BOX_TAG = "Box";
    const string PLAYER_TAG = "Player";

    Transform parent;
    Animator animator;
    TwoTriggerDoor door;

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
            door.Button2(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(BOX_TAG) || other.gameObject.CompareTag(PLAYER_TAG))
        {
            animator.SetTrigger("Release");
            door.Button2(false);
        }
    }

    private void FindDoor()
    {
        parent = transform.parent.transform.parent;

        // the door should be above the button in the hierchy 

        Transform child = parent.GetChild(0);

        door = child.gameObject.GetComponent<TwoTriggerDoor>();
    }
}
