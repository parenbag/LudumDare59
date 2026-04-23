using UnityEngine;
using TMPro;

public class CodeLockLogic : MonoBehaviour
{
    [Header("Code Settings")]
    [SerializeField] private int codeLength = 4;
    private string currentCode;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private TextMeshProUGUI debugCodeText;

    [Header("Dependencies")]
    [SerializeField] private DoorManager doorManager;

    [Header("State")]
    public bool IsPowerActive = false; // для скриптов

    private string playerInput = "";
    private bool playerInTrigger = false;

    private void Start()
    {
        GenerateCode();

        if (displayText != null)
            displayText.text = "";

        if (debugCodeText != null)
            debugCodeText.text = currentCode; // для теста


    }

    private void Update()
    {
        if (!playerInTrigger || !IsPowerActive)
            return;

        HandleInput();

        if (displayText != null)
            displayText.text = playerInput;
    }

    private void GenerateCode()
    {
        currentCode = "";

        for (int i = 0; i < codeLength; i++)
        {
            currentCode += Random.Range(0, 10).ToString();
        }
    }

    private void HandleInput()
    {
        
        for (int i = 0; i <= 9; i++)
        {
            if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i)) ||
                Input.GetKeyDown((KeyCode)((int)KeyCode.Keypad0 + i)))
            {
                if (playerInput.Length < codeLength)
                {
                    playerInput += i.ToString();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace) && playerInput.Length > 0)
        {
            playerInput = playerInput.Substring(0, playerInput.Length - 1);
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CheckCode();
        }
    }

    private void CheckCode()
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

    private void CorrectCode()
    {
        if (doorManager == null)
        {
            Debug.LogWarning("DoorManager not assigned!");
            return;
        }

        doorManager.IsOpen = true;
        Debug.Log("Code correct");
    }

    private void WrongCode()
    {
        Debug.Log("Wrong code");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInTrigger = true;

        if (displayText != null)
            displayText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInTrigger = false;
        playerInput = "";

        if (displayText != null)
            displayText.gameObject.SetActive(false);
    }

    public void SetPower(bool state)
    {
        IsPowerActive = state;
    }
}