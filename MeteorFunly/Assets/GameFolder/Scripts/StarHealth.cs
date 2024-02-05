using UnityEngine;

public class StarHealth : MonoBehaviour
{
    public int maxStars = 5;
    private int _currentStars;
    public GameObject[] starImageSprites;
    public GameObject wallObject;
    public GameObject sliderHandler;

    public AudioSource audioSource;
    public AudioClip explosionSound;

    private WinControl _winControl;
    
    private void Awake()
    {
        _winControl = FindObjectOfType<WinControl>();
    }

    void Start()
    {
        _currentStars = maxStars;
        UpdateStars();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("METEOR"))
        {
            audioSource.PlayOneShot(explosionSound);

            if (_currentStars >= 0)
            {
                _currentStars--;
                UpdateStars();
                
                
                if (_currentStars == 0)
                {
                    _winControl.DecreasePlayerCount(gameObject);
                    wallObject.SetActive(true);
                    CloseSliderHandler();
                }
            }
        }
    }
    
    void UpdateStars()
    {
        for (int i = 0; i < starImageSprites.Length; i++)
        {
            if (i < _currentStars)
            {
                starImageSprites[i].SetActive(true);
            }
            else
            {
                starImageSprites[i].SetActive(false);
            }
        }
    }
    
    void CloseSliderHandler()
    {
        sliderHandler.SetActive(false);
    }
}
