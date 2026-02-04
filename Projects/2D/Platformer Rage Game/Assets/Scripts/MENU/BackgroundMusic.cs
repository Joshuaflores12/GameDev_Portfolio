using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static BackgroundMusic Instance { get; private set; }

    [SerializeField] AudioSource SFXSource;

    public AudioClip jump;
    public AudioClip coin;
    public AudioClip gameOver;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            // If a duplicate is created, destroy it
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
            SFXSource.PlayOneShot(clip); 
    }
}
