using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField]
    private GameObject candleFlame;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Flame"))
        {
            candleFlame.SetActive(true);
        }
    }
}
