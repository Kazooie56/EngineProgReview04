using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HUDCanvas.Instance.AddCoin();
            Destroy(gameObject);
        }
    }
}