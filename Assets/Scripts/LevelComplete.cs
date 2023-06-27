using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
   public void LoadMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
