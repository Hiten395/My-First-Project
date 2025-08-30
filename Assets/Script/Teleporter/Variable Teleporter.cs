using UnityEngine;
using System.Collections;

public class VariableTeleporter : MonoBehaviour
{
    [SerializeField] GameObject[] locations;
    [SerializeField] Material[] color;
    [SerializeField] ParticleSystem[] VFX;
    [SerializeField] Vector3 VFXoffset;
    [SerializeField] float timeToTeleport;
    [SerializeField] public bool power = true;

    VariableTeleporter[] variableTeleporters;
    ColorSwitcher colorSwitcher;
    CharacterController characterController;
    GameObject currentDestination;
    Player player;

    int isTeleportable = 0;

    int i;
    int currentDestinationID = 0;

    const string PLAYER_TAG = "Player";

    private void Start()
    {
        colorSwitcher = GetComponentInChildren<ColorSwitcher>();
        colorSwitcher.GetColor(color);

        variableTeleporters = new VariableTeleporter[locations.Length];

        for (i = 0; i < locations.Length; i++)
        {
            variableTeleporters[i] = locations[i].GetComponent<VariableTeleporter>();
        }
        currentDestination = locations[0];

        if (variableTeleporters[currentDestinationID].power == false)
        {
            Switch(1);
        }
    }

    public void Switch(int amount)
    {
        if (power == false) return;

        int colorSwitchBy = amount;

        currentDestinationID += amount;

        if (currentDestinationID == locations.Length)
        {
            currentDestinationID = 0;
        }

        while (variableTeleporters[currentDestinationID].power == false)
        {
            currentDestinationID += 1;
            colorSwitchBy += 1;

            if (currentDestinationID == locations.Length)
            {
                currentDestinationID = 0;
            }
        }

        colorSwitcher.SwitchColor(colorSwitchBy);

        currentDestination = locations[currentDestinationID];
        //Debug.Log(currentDestination + " " + currentDestinationID);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isTeleportable > 0)
        {
            isTeleportable -= 1;
            return;
        }

        if (power == false) return;

        StartCoroutine(TeleportRoutine(other.gameObject));
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }

    public void AvoidLopp()
    {
        isTeleportable += 1;
    }

    public void TurnOn()
    {
        power = true;
        PowerLight powerLight = GetComponentInChildren<PowerLight>();
        powerLight.TurnOn();
    }

    public void TurnOff()
    {
        power = false;

        foreach(var location in variableTeleporters)
        {
            location.Switch(0);
        }


        PowerLight powerLight = GetComponentInChildren<PowerLight>();
        powerLight.TurnOff();
    }

    IEnumerator TeleportRoutine(GameObject other)
    {
        Instantiate(VFX[currentDestinationID], transform.position + new Vector3(0.55f,-0.1f,-0.6f), VFX[currentDestinationID].transform.rotation, this.gameObject.transform);
        yield return new WaitForSeconds(timeToTeleport);
        Teleport(other);
    }

    void Teleport(GameObject other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            characterController = other.GetComponent<CharacterController>();
            player = other.GetComponent<Player>();
            characterController.enabled = false;
            other.transform.position = currentDestination.transform.position + new Vector3(0, 0.5f, 0);
            player.PickUp();
            characterController.enabled = true;
            variableTeleporters[currentDestinationID].AvoidLopp();
            return;
        }
        other.transform.position = currentDestination.transform.position + new Vector3(0,1.5f,0);
        Box box = other.GetComponent<Box>();
        box.Drop();
        variableTeleporters[currentDestinationID].AvoidLopp();
    }

}
