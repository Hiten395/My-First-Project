using UnityEngine;

public class PowerLight : MonoBehaviour
{
    [SerializeField] Material material;

    MeshRenderer meshRenderer;
    VariableTeleporter variableTeleporter;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        variableTeleporter = GetComponentInParent<VariableTeleporter>();
        if (variableTeleporter.power == true)
        {
            TurnOn();
        }
    }

    public void TurnOn()
    {
        meshRenderer.material = material;
    }
}
