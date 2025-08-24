using UnityEngine;
using System.Collections;

public class WhitePortal : MonoBehaviour
{
    [SerializeField] float timeToTeleport = 1f;
    [SerializeField] ParticleSystem VFX;

    BlackPortal blackPortal;

    bool isTeleportable = true;

    private void Start()
    {
        //Black Portal Should Be Above The White Portal In Hiererchy Window
        blackPortal = transform.parent.GetChild(0).GetComponent<BlackPortal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTeleportable == false)
        {
            isTeleportable = true;
            return;
        }
        Debug.Log(VFX);
        VFX.Play();
        StartCoroutine(TeleportRoutine(other.gameObject));
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }

    IEnumerator TeleportRoutine(GameObject other)
    {
        yield return new WaitForSeconds(timeToTeleport);
        Teleport(other);
    }

    public void AvoidLopp()
    {
        isTeleportable = false;
    }

    void Teleport(GameObject other)
    {
        blackPortal.AvoidLopp();
        other.transform.position = blackPortal.gameObject.transform.position + new Vector3(0, 1.2f, -0.5f);
    }
}
