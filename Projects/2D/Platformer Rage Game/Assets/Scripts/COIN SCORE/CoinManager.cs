using UnityEngine;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    [SerializeField] private TextMeshProUGUI coinCounter;
    [SerializeField] private int totalCoins = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddCoin(int Amount) 
    {
        totalCoins += Amount;
        coinCounter.text = totalCoins.ToString();
    }
}
