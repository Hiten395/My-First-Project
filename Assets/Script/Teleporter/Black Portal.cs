using UnityEngine;
using System.Collections;

public class BlackPortal : MonoBehaviour
{
    [SerializeField] float timeToTeleport = 1f;
    [SerializeField] ParticleSystem VFX;

    WhitePortal whitePortal;

    bool isTeleportable = true;

    private void Start()
    {
        //Black Portal Should Be Above The White Portal In Hiererchy Window
        whitePortal = transform.parent.GetChild(1).GetComponent<WhitePortal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTeleportable == false)
        {
            isTeleportable = true;
            return;
        }
        StartCoroutine(TeleportRoutine(other.gameObject));
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }

    IEnumerator TeleportRoutine(GameObject other)
    {
        VFX.Play();
        yield return new WaitForSeconds(timeToTeleport);
        Teleport(other);
    }

    public void AvoidLopp()
    {
        isTeleportable = false;
    }

    void Teleport(GameObject other)
    {
        whitePortal.AvoidLopp();
        other.transform.position = whitePortal.gameObject.transform.position + new Vector3(0, 1.2f, -0.5f);
    }
}
