using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFolder.Scripts
{
    public class PanelManager : MonoBehaviour
    {
        public GameObject gamePanel;
        public GameObject pauseMenuPanel;
        public GameObject playerSelectionPanel;
        public GameObject settingsPanel;
        public GameObject botsPlay2Player;
        public GameObject botsPlay3Player;

        public BallSpawner ballSpawner;
        
        

        void Start()
        {
            botsPlay3Player.SetActive(false);
            botsPlay2Player.SetActive(false);
            gamePanel.SetActive(false);
            pauseMenuPanel.SetActive(false);
            settingsPanel.SetActive(false);
            
            playerSelectionPanel.SetActive(true);
        }
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
        
        public void StartAfterSelect()
        {
            playerSelectionPanel.SetActive(false);
            gamePanel.SetActive(true);
            
            ballSpawner.enabled = true;
        }
        public void Pause()
        {
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        public void Continue()
        {
            pauseMenuPanel.SetActive(false);
            Time.timeScale = 1f;
        }
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    
        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1f;
        }
        public void Settings()
        {
            pauseMenuPanel.SetActive(false);
            settingsPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        public void BackToPauseMenu()
        {
            settingsPanel.SetActive(false);
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        public void BackToSelectionFromBots()
        {
            botsPlay3Player.SetActive(false);
            botsPlay2Player.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
