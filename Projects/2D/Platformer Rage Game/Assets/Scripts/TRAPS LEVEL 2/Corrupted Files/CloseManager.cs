using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CloseManager : MonoBehaviour
{
    [SerializeField] private GameObject corruptedFileUI, errorBox;
    [SerializeField] private float additionalSpeed;
    public void Close()
    {
        PlayerMovement player = FindAnyObjectByType<PlayerMovement>();
        if (player != null)
        {
            StartCoroutine(BoostSpeedTemporarily(player));
        }
        corruptedFileUI.SetActive(false);
        errorBox.SetActive(false);

    }

    private IEnumerator BoostSpeedTemporarily(PlayerMovement player)
    {
        float originalSpeed = player.speed;
        player.speed += additionalSpeed;

        yield return new WaitForSeconds(2f);
        player.speed = originalSpeed;
    }
}
