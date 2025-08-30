using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] int ButtonCount = 1;

    Animator animator;

    int count = 0;
    bool state = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Button(int trigger)
    {
        count += trigger;

        if (count == ButtonCount)
        {
            state = true;
            Open();
        }

        if (count < ButtonCount && state)
        {
            Close();
        }
    }

    void Open()
    {
        animator.SetTrigger("Open");
    }

    void Close()
    {
        animator.SetTrigger("Close");
    }
}
