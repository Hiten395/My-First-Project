using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] float holdDistance = 5f;

    Rigidbody rigidbody;
    Player player;

    bool isInteractable = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        player = FindFirstObjectByType<Player>();
    }

    private void Update()
    {
        if (!isInteractable) return;

        Vector3 targetPoint = Camera.main.transform.rotation * Vector3.forward;

        rigidbody.linearVelocity = (targetPoint * holdDistance + player.gameObject.transform.position - gameObject.transform.position + new Vector3(0,2,0)) * 3f;

    }

    public void DoStuff(Player player)
    {
        isInteractable = true;
        rigidbody.useGravity = false;
    }

    public void Drop()
    {
        player.hold = false;
        isInteractable = false;
        rigidbody.useGravity = true;
    }
}
