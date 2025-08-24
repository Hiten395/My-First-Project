using UnityEngine;

public class TwoTriggerDoor : MonoBehaviour
{
    Animator animator;

    bool Trigger1 = false;
    bool Trigger2 = false;

    bool doorState = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Button1(bool state)
    {
        Trigger1 = state;
        DoorState();
    }

    public void Button2(bool state)
    {
        Trigger2 = state;
        DoorState();
    }

    void DoorState()
    {

        if (Trigger1 && Trigger2)
        {
            Open();
        }
        if (Trigger1 == false || Trigger2 == false)
        {
            if (doorState)
            {
                Close();
            }
        }

    }



    void Open()
    {
        animator.SetTrigger("Open");
        doorState = true;
    }

    void Close()
    {
        animator.SetTrigger("Close");
        doorState = false;
    }
}
