using UnityEngine;
using System.Collections;
public class EnemyConsoleSpamSpawn : MonoBehaviour
{
    [SerializeField] private SpriteRenderer console;
    [SerializeField] private GameObject consoleObject;
    [SerializeField] private Rigidbody2D consoleRb;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int numberOfEnemies = 2;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private float delayBeforeFadeout;
    [SerializeField] private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered) 
        {
            hasTriggered = true;
            StartCoroutine(TriggeredConsoleSequence());
        }
    }

    private IEnumerator TriggeredConsoleSequence()
    {
        yield return StartCoroutine(FadeAlpha(0f, 1f));

        consoleRb.gravityScale = 4f;

        
        yield return new WaitForSeconds(delayBeforeFadeout);

        yield return StartCoroutine(FadeAlpha(1f, 0f));

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Transform spawnPoint = spawnPoints[i % spawnPoints.Length];
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }

        Destroy(gameObject);
        Destroy(consoleObject);
    }

    private IEnumerator FadeAlpha(float startAlpha, float endAlpha) 
    {
        float duration = Mathf.Abs(endAlpha - startAlpha) / fadeSpeed;
        float time = 0f;
        Color color = console.color;

        while (time < duration) 
        {
            float t = time / duration;
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            console.color = color;
            time += Time.deltaTime;
            yield return null;

        }

        color.a = endAlpha;
        console.color = color;
    }
}
