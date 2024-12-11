using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private CoinData coinData; 
    [SerializeField] private TextMeshProUGUI coinText; 

    private void Update()
    {
        
        coinText.text = " " + coinData.CoinCount;

       
        coinText.ForceMeshUpdate();
    }
}