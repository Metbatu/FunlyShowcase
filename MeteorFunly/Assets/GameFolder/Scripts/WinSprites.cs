using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSprites : MonoBehaviour
{
    public Sprite redSprite;
    public Sprite yellowSprite;
    public Sprite blueSprite;
    public Sprite greenSprite;

    public WinControl winControl;

    void Start()
    {
        // Example usage when setting up player sprites
        winControl.AddPlayerSprite("Kırmızı", redSprite);
        winControl.AddPlayerSprite("Sarı", yellowSprite);
        winControl.AddPlayerSprite("Mavi", blueSprite);
        winControl.AddPlayerSprite("Yeşil", greenSprite);
    }
}