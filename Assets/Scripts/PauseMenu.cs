using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject telaPause;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                telaPause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                telaPause.SetActive(false);
            }
        }
    }
    public void Voltar()
    {
        Time.timeScale = 1;
        telaPause.SetActive(false);
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Sair()
    {
        Application.Quit();
    }
}
