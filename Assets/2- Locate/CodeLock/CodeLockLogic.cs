using UnityEngine;
using TMPro;


public class CodeLockLogic : MonoBehaviour
{
    public bool IsPowerActive = false;              // in combiner
    [SerializeField] private DoorManager doorManager; // in door , doorManager.IsOpen

    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private TextMeshProUGUI trueCode;

    private string generatedCode;
    private string currentInput = "";

    bool OnColliderY;
    [SerializeField] private GameObject TXT;

    void Start()
    {
        GenerateCode();
        TXT.SetActive(false);
    }

    void GenerateCode()
    {
        generatedCode = Random.Range(1000, 9999).ToString(); 
        trueCode.text = generatedCode;

    }
    void CheckCode()
    {
        if (currentInput == trueCode.text)
        {
            OnCorrectCode();
        }
        else
        {
            OnWrongCode();
        }
        currentInput = "";
        displayText.text = "";
    }




    public void KeyNumber(int Num)
    {
        currentInput += Num.ToString();

        displayText.text = currentInput;

        if (currentInput.Length >= 4)
        {
            CheckCode();
        }
    }

    void OnCorrectCode()
    {

        if (doorManager != null)
            doorManager.IsOpen = true;
    }

    void OnWrongCode()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnColliderY = true;
            TXT.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnColliderY = false;
            TXT.SetActive(false);
        }
    }


    void Update()
    {
        if (IsPowerActive == true && OnColliderY)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
            {
                KeyNumber(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                KeyNumber(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                KeyNumber(2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                KeyNumber(3);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                KeyNumber(4);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
            {
                KeyNumber(5);
            }

            if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
            {
                KeyNumber(6);
            }

            if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
            {
                KeyNumber(7);
            }

            if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
            {
                KeyNumber(8);
            }

            if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
            {
                KeyNumber(9);
            }
        }
       
    }


}