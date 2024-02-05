using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonWithChildren : MonoBehaviour
{
    public Sprite newImage;
    public Sprite oldImage;
    public GameObject[] childrenToClose;

    private Button button;
    private Image buttonImage;
    private bool isToggled = false;
    
    public Button startGameButton;

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        
        button.onClick.AddListener(ToggleImageOnClick);
        
        startGameButton.interactable = false;
    }

    void ToggleImageOnClick()
    {
        isToggled = !isToggled;
        
        buttonImage.sprite = isToggled ? newImage : oldImage;
        
        ToggleChildrenVisibility(isToggled);
        
        startGameButton.interactable = isToggled;
    }

    void ToggleChildrenVisibility(bool toggleState)
    {
        foreach (GameObject child in childrenToClose)
        {
            child.SetActive(!toggleState);
            
        }
    }
}