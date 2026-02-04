using UnityEngine;

public class Coin : MonoBehaviour
{
    BackgroundMusic backgroundMusic;

    private void Awake()
    {
        backgroundMusic = GameObject.FindGameObjectWithTag("Audio").GetComponent<BackgroundMusic>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            backgroundMusic.PlaySFX(backgroundMusic.coin);
            CoinManager.instance.AddCoin(1);
            Destroy(gameObject);
        }
    }
}
