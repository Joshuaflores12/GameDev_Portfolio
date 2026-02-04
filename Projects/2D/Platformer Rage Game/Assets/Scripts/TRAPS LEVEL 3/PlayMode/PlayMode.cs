using UnityEngine;
using System.Collections;
using TMPro;
public class PlayMode : MonoBehaviour
{
    [SerializeField] private GameObject hiddenBlock;
    [SerializeField] private GameObject deathTrigger;
    [SerializeField] private float deathTriggerTimerActivation;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private bool timerStarted = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            hiddenBlock.SetActive(true);
            StartCoroutine(CountdownToActivateDeathTrigger());
        }
    }

    private IEnumerator CountdownToActivateDeathTrigger() 
    {
        timerStarted = true;
        float remainingTime = deathTriggerTimerActivation;

        while (remainingTime > 0f) 
        {
            timer.text = remainingTime.ToString("F1");
            remainingTime -= Time.deltaTime;
            yield return null;  
        }

        timer.text = "0.0";
        deathTrigger.SetActive(true);
    }

}
