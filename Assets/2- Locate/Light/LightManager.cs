using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public List<GameObject> objectsToToggle = new List<GameObject>();

    public DeckManager deckManager;

    public bool Room1;
    public bool Room2;
    public bool Room3;
    public bool Room4;

    void Update() 
    {
        if (objectsToToggle.Count <= 0)
            return;
 
        objectsToToggle[0].SetActive(deckManager.StationPower);


    }

    public void SetActiveAll(bool state)
    {
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null)
                obj.SetActive(state);
        }
    }
}