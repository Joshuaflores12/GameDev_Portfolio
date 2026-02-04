using UnityEngine;
using UnityEngine.SceneManagement;
public class BlueScreen : MonoBehaviour
{
    [SerializeField] private GameObject blueScreenUI;
    [SerializeField] private float blueScreenTimer = 3f;
    [SerializeField] private bool blueScreenEnabled = false;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private string Level3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                blueScreenUI.SetActive(true);
                blueScreenEnabled = true;
                player.speed = 0f;
                player.jumpforce = 0f;
            }
        }
    }

    private void Update()
    {
        if (blueScreenEnabled)
        {
            blueScreenTimer -= Time.deltaTime;
            Debug.Log("Seconds Left: " + blueScreenTimer);
            float originalSpeed = player.speed;
            float originalJumpForce = player.jumpforce;
            if (blueScreenTimer <= 0f)
            {
                blueScreenUI.SetActive(false);
                blueScreenEnabled = false;
                Debug.Log("BlueScreenFixed!");

                player.speed = originalSpeed;
                player.jumpforce = originalJumpForce;
                SceneManager.LoadScene(Level3);
            }
        }
    }
}
