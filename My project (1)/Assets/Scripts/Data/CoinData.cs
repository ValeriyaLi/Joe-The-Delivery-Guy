using UnityEngine;

[CreateAssetMenu(fileName = "CoinData", menuName = "ScriptableObjects/CoinData")]
public class CoinData : ScriptableObject
{
    public int CoinCount;

    public void ResetCoinCount()
    {
        CoinCount = 0;
    }
}