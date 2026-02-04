using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerColl : MonoBehaviour
{
    public static Vector3 savedRespawnPoint;

    [SerializeField] private float deathDelay = 0.5f;
    [SerializeField] private Rigidbody2D rb;
    BackgroundMusic backgroundMusic;

    private void Awake()
    {
        // Find the designated spawn point in the current scene
        GameObject spawnPointObj = GameObject.FindGameObjectWithTag("SpawnPoint");
        backgroundMusic = GameObject.FindGameObjectWithTag("Audio").GetComponent<BackgroundMusic>();

        if (spawnPointObj != null)
        {
            Vector3 sceneDefaultSpawn = spawnPointObj.transform.position;

            // Reset respawn point if it's the first time in this scene (e.g., not from death reload)
            if (SceneManager.GetActiveScene().buildIndex != PlayerPrefs.GetInt("LastScene", -1))
            {
                savedRespawnPoint = sceneDefaultSpawn;
                PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
            }

            transform.position = savedRespawnPoint;
        }
        else
        {
            Debug.LogWarning("No spawn point tagged 'SpawnPoint' found in the scene!");
        }
    }

    private void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    private IEnumerator DelayedDeath()
    {
        backgroundMusic.PlaySFX(backgroundMusic.gameOver);
        Debug.Log("Player Died!");
        rb.linearVelocity = Vector2.zero;

        FadeManager.Instance.FadeOut();

        yield return new WaitForSeconds(deathDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            StartCoroutine(DelayedDeath());
        }
    }

    public void Death()
    {
                StartCoroutine(DelayedDeath());
    }

    public static void SetCheckpoint(Vector3 newCheckpoint)
    {
        savedRespawnPoint = newCheckpoint;
    }
}
