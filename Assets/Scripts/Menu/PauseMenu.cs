using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
 
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;
    public Stats stats;
    // Update is called once per frame

    private void Start()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;

        Resume();
    }

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ManageMenu();
        }
    }

    private void ManageMenu()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Save()
    {
        Data data = stats.getData();
        SaveSystem.Save(data);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
