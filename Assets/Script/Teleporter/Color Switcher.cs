using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    Material[] colors;

    MeshRenderer meshRenderer;

    int ID = 0;

    private void ColorSet()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = colors[ID];
    }

    public void SwitchColor(int amount)
    {
        for (int i = 1; i <= amount; i++)
        {

            ID += 1;

            if (ID == colors.Length)
            {
                ID = 0;
            }
        }

        meshRenderer.material = colors[ID];
    }

    public void GetColor(Material[] color)
    {
        colors = color;
        ColorSet();
    }
}
