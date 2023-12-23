using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rizaluto : MonoBehaviour
{
    public Text SText;
    public static int Rcoin;
    public static int RMeter;
    public static int RKMeter;
    // Start is called before the first frame update
    void Start()
    {
        Rcoin = 0;
        RMeter = 0;
        RKMeter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ri();
    }

    public void Ri()
    {
        Rcoin = GameManager.GetGCoin();
        RMeter = GameManager.GetGMeter();
        RKMeter = GameManager.GetGKMeter();
        if (RKMeter <= 0)
        {
            SText.text = "走行距離:" + RMeter + "m,コイン:" + Rcoin + "枚";
        }
        if (RKMeter > 0)
        {
            SText.text = "走行距離:" + RKMeter + "." + (RMeter / 10 - RKMeter * 100) + "km,コイン:" + Rcoin + "枚";
        }
    }
    public static int GetRMeter()
    {
        return RMeter;
    }
    public static int GetRKMeter()
    {
        return RKMeter;
    }
    public static int GetRcoin()
    {
        return Rcoin;
    }
}
