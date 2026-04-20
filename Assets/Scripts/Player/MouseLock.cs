using UnityEngine;

public class MouseLock : MonoBehaviour
{
    [SerializeField] private float mouseSebsitivity = 200f;

    [SerializeField] private Transform playerBody;


    public bool _isUse_Camera = false;

    private float xRotation = 0f;

    [SerializeField] GameObject EscapeMenu;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSebsitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSebsitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        if (!_isUse_Camera)
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }

    }

    


    public void AltLookAround()
    {

    }
    
}
