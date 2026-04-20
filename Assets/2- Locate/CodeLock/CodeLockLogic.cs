using UnityEngine;
using TMPro;
public class CodeLockLogic : MonoBehaviour
{
    public string currentCode;
    public TextMeshProUGUI displayText;

    private string playerInput = "";
    private bool playerInTrigger = false;

    public TextMeshProUGUI place;


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
        Debug.Log("Code: " + currentCode);
    }

    void Update()
    {
        if (!playerInTrigger) return;

        foreach (char c in Input.inputString)
        {
            if (char.IsDigit(c))
            {
                playerInput += c;
            }

            if (c == '\b' && playerInput.Length > 0) // Backspace
            {
                playerInput = playerInput.Substring(0, playerInput.Length - 1);
            }

            if (c == '\n' || c == '\r') // Enter
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

        playerInput = ""; // очистка после попытки
    }

    void CorrectCode()
    {
        Debug.Log("Верно");
        // твой метод
        door.SetActive(false);
    }

    void WrongCode()
    {
        Debug.Log("Неверно");
        // твой метод
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
