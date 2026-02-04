using UnityEngine;
using TMPro;
using System.Collections;
public class FreezeFrame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI freezeNotif;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();

        if (player != null) 
        {
            StartCoroutine(FreezeDelay(player));
        }
    }

    private IEnumerator FreezeDelay(PlayerMovement player) 
    {
        yield return new WaitForSeconds(2);
        float originalSpeed = player.speed;
        float originalJumpForce = player.jumpforce;

        player.speed = 0f;
        player.jumpforce = 0f;
        freezeNotif.text = "FROZEN!";

        yield return new WaitForSeconds(2f);
        player.speed = originalSpeed;
        player.jumpforce = originalJumpForce;
        freezeNotif.text = "";
    }

}
