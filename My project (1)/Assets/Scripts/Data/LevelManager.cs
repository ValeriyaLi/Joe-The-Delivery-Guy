using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private CoinData coinData; // Reference to the ScriptableObject

    private void Start()
    {
        // Reset the coin data
        coinData.ResetCoinCount();
    }
}