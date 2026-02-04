using UnityEngine;
using System.Collections;
public class PrefabFade : MonoBehaviour
{
    [SerializeField] private GameObject[] fadingPlatforms;
    [SerializeField] private SpriteRenderer[] fadingPlatformRenderer;
    [SerializeField] private float fadeDuration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            StartCoroutine(FadeAndDisable());
        }
    }

    private IEnumerator FadeAndDisable() 
    {
        float elapsed = 0f;
        Color[] originalColors = new Color[fadingPlatformRenderer.Length];
        for (int i = 0; i < fadingPlatformRenderer.Length; i++) 
        {
            originalColors[i] = fadingPlatformRenderer[i].color;
        }

        while (elapsed < fadeDuration) 
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);

            for (int i = 0;i < fadingPlatformRenderer.Length;i++) 
            {
                Color newColor = originalColors[i];
                newColor.a = alpha;
                fadingPlatformRenderer[i].color = newColor;
            }
            yield return null;
        }

        foreach (GameObject platform in fadingPlatforms) 
        {
            Collider2D col = platform.GetComponent<Collider2D>();
            if (col != null) 
            {
                col.isTrigger = true;
                Destroy(gameObject);
            }
        }
    }
}
