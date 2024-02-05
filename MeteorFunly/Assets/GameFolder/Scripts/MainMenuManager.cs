using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFolder.Scripts
{
    public class MainMenuManager : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        }

        public void Quit()
        {
            Application.Quit();
            Debug.Log("Exit is Completed");
        }

        public void Again()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void Menu()
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }
}
