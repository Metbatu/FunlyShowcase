using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameFolder.Scripts
{
    public class ButtonComponentActivationHandler : MonoBehaviour
    {
        [System.Serializable] // Ai activator (if button non-interactable)
        public class ButtonComponentPair
        {
            public Button controlButton; // game buttons for controlling player
            public GameObject targetGameObject; // players
            public MonoBehaviour targetComponent; // ai script
        }

        public List<ButtonComponentPair> buttonComponentPairs = new List<ButtonComponentPair>();

        public GameObject playerSelectionPanel;
    
        private void Update()
        {
            if (!playerSelectionPanel.activeSelf) return;
            foreach (var pair in buttonComponentPairs)
            {
                CheckAndSetActive(pair.controlButton, pair.targetGameObject, pair.targetComponent);
            }
        }

        private void CheckAndSetActive(Button button, GameObject targetGameObject, MonoBehaviour component)
        {
            component.enabled = !button.interactable;
        }
    }
}