using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    VariableTeleporter variableTeleporter;

    private void Start()
    {
        variableTeleporter = GetComponentInParent<VariableTeleporter>();
    }

    public void Switch()
    {
        variableTeleporter.Switch(1);
    }
}
