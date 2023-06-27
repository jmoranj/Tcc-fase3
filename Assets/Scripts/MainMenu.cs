using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void jogar()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void sair()
    {
        Application.Quit();
    }
    
}

