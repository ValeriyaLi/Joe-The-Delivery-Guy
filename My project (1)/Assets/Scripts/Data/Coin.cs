using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1; 
    [SerializeField] private CoinData coinData; 
    private bool hasTriggered;
    [SerializeField] private AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            SoundManager.instance.PlaySound(coinSound);
            hasTriggered = true;

            // Add the coin value to the ScriptableObject
            coinData.CoinCount += value;

            Debug.Log("Total Coins: " + coinData.CoinCount);

            // Destroy the coin object
            Destroy(gameObject);
        }
    }
}