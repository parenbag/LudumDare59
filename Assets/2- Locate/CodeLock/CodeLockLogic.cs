using UnityEngine;
using TMPro;
public class CodeLockLogic : MonoBehaviour
{
    public string currentCode;
    public TextMeshProUGUI displayText;

    private string playerInput = "";
    private bool playerInTrigger = false;

    public TextMeshProUGUI place;

    public bool IsPowerActive = false;

    //TEST

    public GameObject door;

    void Start()
    {
        GenerateCode();
        displayText.text = "";
        place.text = currentCode;

    }

    void GenerateCode()
    {
        currentCode = Random.Range(1000, 9999).ToString();
    }

    void Update()
    {
        if (!playerInTrigger || !IsPowerActive) return;

        foreach (char c in Input.inputString)
        {
            if (char.IsDigit(c))
            {
                playerInput += c;
            }

            if (c == '\b' && playerInput.Length > 0) 
            {
                playerInput = playerInput.Substring(0, playerInput.Length - 1);
            }

            if (c == '\n' || c == '\r') 
            {
                CheckCode();
            }
        }

        displayText.text = playerInput;
    }

    void CheckCode()
    {
        if (playerInput == currentCode)
        {
            CorrectCode();
        }
        else
        {
            WrongCode();
        }

        playerInput = "";
    }

    void CorrectCode()
    {
        door.SetActive(false);
    }

    void WrongCode()
    {
        Debug.Log("Неверно");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            displayText.gameObject.SetActive(true);
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            displayText.gameObject.SetActive(false);
            playerInput = "";
        }
    }
}
