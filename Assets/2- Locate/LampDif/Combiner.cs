using UnityEngine;

public class Combiner : MonoBehaviour
{
    public DeckManager _deckManager;
    public CodeLockLogic _codeLockLogic;


    public GameObject part1;
    public GameObject part2;

    public GameObject Stickpart1;
    public GameObject Stickpart2;


    void Start()
    {
        part1.SetActive(false);
        part2.SetActive(false);
    }

    void Update()
    {
        if (_deckManager.StationPower)
        {
            if (part1.activeSelf && part2.activeSelf)
            {
                _codeLockLogic.IsPowerActive = true; 
            }
            else
            {
                _codeLockLogic.IsPowerActive = false;
            }
        }
        else
        {
            _codeLockLogic.IsPowerActive = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StickPart1"))
        {
            part1.SetActive(true);
            Stickpart1.SetActive(false);
        }
        else if (other.CompareTag("StickPart2"))
        {
            part2.SetActive(true);
            Stickpart2.SetActive(false);
        }
    }

    
}


//IsPowerActive - CodeLockLogic
// StationPower - DeckManager
