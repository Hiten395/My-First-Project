using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float maxInteractDistace = 25f;
    [SerializeField] LayerMask layerMask;
    RaycastHit hit;
    

    const string BOX_STRING = "Box";
    const string BUTTON_STRING = "Button";
    const string POWER_STRING = "Power";

    public bool hold = false;

    public void PickUp()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.rotation * Vector3.forward, out hit, maxInteractDistace, layerMask, queryTriggerInteraction: QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.gameObject.CompareTag(BOX_STRING))
            {
                Box box = hit.collider.gameObject.GetComponent<Box>();
                if (hold == false)
                {
                    box.DoStuff(this);
                    hold = true;
                }
                else
                {
                    box.Drop();
                    hold = false;
                }
            }
        }
    }

    public void Button()
    {
         if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.rotation * Vector3.forward, out hit, maxInteractDistace, layerMask, queryTriggerInteraction: QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.gameObject.CompareTag(BUTTON_STRING))
                {
                    SwitchButton switchButton = hit.collider.gameObject.GetComponent<SwitchButton>();
                    switchButton.Switch();
                }
                else
                if (hit.collider.gameObject.CompareTag(POWER_STRING))
                {
                    Power power = hit.collider.gameObject.GetComponent<Power>();
                    Debug.Log(power);
                    power.StartPower();
                }
            }
    }

    public void Test()
    {
        //
    }

}
