using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinControl : MonoBehaviour
{
    public int remainingPlayers = 4;

    public List<GameObject> players = new List<GameObject>();
    private GameObject[] tempPlayers = new GameObject[4];
    
    public GameObject winnerPanel;
    public Image winnerImage;
    
    // Dictionary to map player tags to sprite images
    private Dictionary<string, Sprite> playerTagToSprite = new Dictionary<string, Sprite>();

    private void Start()
    {
        winnerPanel.SetActive(false);
    }

    // Method to add player sprites
    public void AddPlayerSprite(string playerName, Sprite playerSprite)
    {
        if (!playerTagToSprite.ContainsKey(playerName))
        {
            playerTagToSprite.Add(playerName, playerSprite);
        }
    }

    public void DecreasePlayerCount(GameObject GO)
    {
        remainingPlayers--;
        players.Remove(GO);
        
        if (remainingPlayers == 1)
        {
            tempPlayers = players.ToArray();
            
            string winnerName = tempPlayers[0].tag;

            // Check if the winner's tag exists in the dictionary
            if (playerTagToSprite.ContainsKey(winnerName))
            {
                // Set the winner sprite based on the player's tag
                winnerImage.sprite = playerTagToSprite[winnerName];
            }

            winnerPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}