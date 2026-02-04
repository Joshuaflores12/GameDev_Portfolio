using UnityEngine;

public class ClosePopUp : MonoBehaviour
{
    [SerializeField] private GameObject virusPrefab;
    [SerializeField] private GameObject popUp;
    [SerializeField] private Transform virusSpawn;

    public void Close()
    {
        popUp.SetActive(false);
        Instantiate(virusPrefab, virusSpawn.position,Quaternion.identity);
    }
}

