using UnityEngine;

public class Power : MonoBehaviour
{
    VariableTeleporter variableTeleporter;

    private void Start()
    {
        variableTeleporter = GetComponentInParent<VariableTeleporter>();
    }

    public void StartPower()
    {
        variableTeleporter.TurnOn();
    }
}
