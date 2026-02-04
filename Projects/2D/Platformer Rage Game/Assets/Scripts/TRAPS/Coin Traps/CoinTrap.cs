using UnityEngine;

public class CoinTrap : MonoBehaviour
{
    [SerializeField] private GameObject spikeDrop;
    [SerializeField] private SpriteRenderer coinTrap;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && spikeDrop != null || coinTrap != null)
        {
            spikeDrop.SetActive(true);
            SetAlpha(0f);
        }

    }

    private void SetAlpha(float alpha) 
    {
        Color color = coinTrap.color;
        color.a = alpha;
        coinTrap.color = color;
    }

}
