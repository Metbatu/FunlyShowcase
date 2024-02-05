using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameFolder.Scripts
{
    [System.Serializable]
    public class PlayerSliderPair
    {
        public Button controlButton;
        public Slider slider;
        public MonoBehaviour scriptComponent;
        public bool isMoving = false;
        public float targetValue;
    }

    public class CombinedController : MonoBehaviour
    {
        public List<PlayerSliderPair> playerSliderPairs = new List<PlayerSliderPair>();
        
        public Button[] numberButtons;
        
        public GameObject botsPlay2PlayersPanel;
        public Button yesButton2Players;
        public Button noButton2Players;

        public GameObject botsPlay3PlayersPanel;
        public Button yesButton3Players;
        public Button noButton3Players;
        
        public int maxPlayers = 4;
        public float moveSpeed = 1f;

        private int selectedPlayers = 1;

        private void Start()
        {
            InitializePlayerSelection();
        }

        private void InitializePlayerSelection()
        {
            for (int i = 0; i < numberButtons.Length; i++)
            {
                int index = i + 1; // Player count starts from 1
                numberButtons[i].onClick.AddListener(() => SelectNumberOfPlayers(index));
            }
            
            yesButton2Players.onClick.AddListener(SelectYesOptionFor2Players);
            noButton2Players.onClick.AddListener(SelectNoOptionFor2Players);
            
            yesButton3Players.onClick.AddListener(SelectYesOptionFor3Players);
            noButton3Players.onClick.AddListener(SelectNoOptionFor3Players);
        }

        private void Update()
        {
            MoveSliders();
        }

        private void SelectNumberOfPlayers(int numPlayers)
        {
            selectedPlayers = numPlayers;
            
            for (int i = 0; i < playerSliderPairs.Count; i++)
            {
                if (i < selectedPlayers)
                {
                    playerSliderPairs[i].controlButton.interactable = true;
                    int index = i; // Capture the current index value
                    playerSliderPairs[i].controlButton.onClick.AddListener(() => ControlSlider(index));
                }
                else
                {
                    playerSliderPairs[i].controlButton.interactable = false;
                }
            }

            // Open the corresponding panel when a number button is clicked
            if (numPlayers == 2)
            {
                OpenBotsPlay2PlayersPanel();
            }
            else if (numPlayers == 3)
            {
                OpenBotsPlay3PlayersPanel();
            }
        }

        private void ControlSlider(int index)
        {
            // Adjust the slider value based on the control button clicked
            PlayerSliderPair pair = playerSliderPairs[index];
            pair.targetValue = (pair.slider.value < 0.5f) ? 1f : 0f; // Set the target value opposite to current value
            pair.isMoving = true;
        }

        public void OpenBotsPlay2PlayersPanel()
        {
            botsPlay2PlayersPanel.SetActive(true);
            botsPlay3PlayersPanel.SetActive(false);
        }

        public void OpenBotsPlay3PlayersPanel()
        {
            botsPlay3PlayersPanel.SetActive(true);
            botsPlay2PlayersPanel.SetActive(false);
        }

        public void CloseBotsPlay2PlayersPanel()
        {
            botsPlay2PlayersPanel.SetActive(false);
        }

        public void CloseBotsPlay3PlayersPanel()
        {
            botsPlay3PlayersPanel.SetActive(false);
        }

        public void SetScriptComponent(bool enable)
        {
            foreach (var pair in playerSliderPairs)
            {
                pair.scriptComponent.enabled = enable;
            }
        }

        public void SelectYesOptionFor2Players()
        {
            CloseBotsPlay2PlayersPanel();
        }

        public void SelectNoOptionFor2Players()
        {
            CloseBotsPlay2PlayersPanel();
            foreach (var pair in playerSliderPairs)
            {
                if (!pair.controlButton.interactable)
                {
                    pair.scriptComponent.enabled = true;
                }
            }
        }


        public void SelectYesOptionFor3Players()
        {
            CloseBotsPlay3PlayersPanel();
        }

        public void SelectNoOptionFor3Players()
        {
            CloseBotsPlay3PlayersPanel();
            foreach (var pair in playerSliderPairs)
            {
                if (!pair.controlButton.interactable)
                {
                    pair.scriptComponent.enabled = true;
                }
            }
        }

        void MoveSliders()
        {
            foreach (var pair in playerSliderPairs)
           
            {
                if (pair.isMoving)
                {
                    var currentSlider = pair.slider;
                    currentSlider.value = Mathf.MoveTowards(currentSlider.value, pair.targetValue, moveSpeed * Time.deltaTime);

                    // Check if the slider has reached the target value
                    if (Mathf.Approximately(currentSlider.value, pair.targetValue))
                    {
                        pair.isMoving = false;
                    }
                }
            }
        }
    }
}
