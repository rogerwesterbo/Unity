using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance { get; private set; }
    public TMP_Text CoinCountText;

    private int coinCount { get; set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
        CoinCountText.text = "Coins: 0";
    }

    public void AddCoin()
    {
        coinCount++;
        CoinCountText.text = "Coins: " + coinCount.ToString();
    }
}
