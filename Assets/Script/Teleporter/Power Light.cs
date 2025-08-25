using UnityEngine;

public class PowerLight : MonoBehaviour
{
    [SerializeField] Material material;
    Material offMaterial;

    MeshRenderer meshRenderer;
    VariableTeleporter variableTeleporter;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        offMaterial = meshRenderer.material;
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

    public void TurnOff()
    {
        meshRenderer.material = offMaterial;
    }
}
