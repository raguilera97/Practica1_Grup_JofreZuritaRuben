using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;
    public string mainMenu;
    

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeResume();
        }
    }

    public void ChangeResume()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
