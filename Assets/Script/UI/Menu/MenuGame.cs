using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void OpenMainMenu(GameObject menu)
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void CloseMainMenu(GameObject menu)
    { 
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void ExitGame()
    {
        
    }
}
