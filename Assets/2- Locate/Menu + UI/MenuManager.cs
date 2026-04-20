using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject Settings;
    [SerializeField] GameObject Credits;
    [SerializeField] GameObject YES;



    [SerializeField] GameObject GameMenu;

    [SerializeField] bool IsGame = false;
    [SerializeField] bool IsDieMenu = false;

    // 0 - Menu 1 - Load 2 - Game


    void Start()
    {
        if (Settings != null)
            Settings.SetActive(false);

        if (Credits != null)
            Credits.SetActive(false);

        if (YES != null)
            YES.SetActive(false);

        if (GameMenu != null)
            GameMenu.SetActive(false);
    }


    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void ButtonSettings()
    {
        Settings.SetActive(!Settings.activeSelf);
    }

    public void ButtonCredits()
    {
        Credits.SetActive(!Credits.activeSelf);
    }

    public void ButtonExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonExit()
    {
        YES.SetActive(!YES.activeSelf);
    }

    public void ButtonYes()
    {
        Application.Quit();
    }

    public void ReturnToGame()
    {
        GameMenu.SetActive(!GameMenu.activeSelf);
        if (GameMenu.activeSelf)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


    void Update()
    {
        if (IsGame && Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToGame();
        }
            

        if (IsDieMenu && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
