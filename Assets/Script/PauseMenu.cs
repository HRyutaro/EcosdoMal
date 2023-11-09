using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;
    public string cena;

     public void SairGame()
    {
        //Mensagem no Unity de saida do jogo

        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

void Start()
{
    Time.timeScale = 1f;
}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }   
    } 

    void PauseScreen()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ResumeGame()
    {
            isPaused = false;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
    }

}
