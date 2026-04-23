using UnityEngine;


public class BattryCheck : MonoBehaviour
{
    public int ID_battery = 0; // 1 | 2
    public DeckManager deckManager;

    public DragItem dragItem;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deck"))
        {
            if (ID_battery == 1)
            {
                deckManager.battery1Installed = true;
            }
            if (ID_battery == 2)
            {
                deckManager.battery2Installed = true;
            }
            if(ID_battery != 1 && ID_battery != 2)
            {
                return;
            }
            transform.position = deckManager.batteryOut.position;
            transform.rotation = deckManager.batteryOut.rotation;
            dragItem.StopDraggingImmediately();
        }

        if (other.CompareTag("SunBattery"))
        {
            if (ID_battery == 1)
            {
                deckManager.battery1InSunButtery = true;
            }
            if (ID_battery == 2)
            {
                deckManager.battery2InSunButtery = true;
            }
            if (ID_battery != 1 && ID_battery != 2)
            {
                return;
            }
            transform.position = deckManager.batteryIn.position;
            transform.rotation = deckManager.batteryIn.rotation;
            dragItem.StopDraggingImmediately();
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Deck"))
        {
            if (ID_battery == 1)
            {
                deckManager.battery1Installed = false;
            }
            if (ID_battery == 2)
            {
                deckManager.battery2Installed = false;
            }
            if (ID_battery != 1 && ID_battery != 2)
            {
                return;
            }
            deckManager.played = false;
        }

        if (other.CompareTag("SunBattery"))
        {
            if (ID_battery == 1)
            {
                deckManager.battery1InSunButtery = false;
            }
            if (ID_battery == 2)
            {
                deckManager.battery2InSunButtery = false;
            }
            if (ID_battery != 1 && ID_battery != 2)
            {
                return;
            }
            deckManager.played = false;
        }

    }
}
