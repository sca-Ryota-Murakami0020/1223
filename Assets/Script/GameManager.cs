using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerC PL;
    public Text GText;
    public Text MText;
    public Text MutekiText;
    GameObject Player;
    public static int Gcoin;
    public static int GMeter;
    public static int GKMeter;

    void Start()
    {
        Player=GameObject.Find("Player");
        GMeter=0;
        Gcoin=0;
        GKMeter=0;
        PL = GetComponent<PlayerC>();
        MText.text = "走行距離:" + GMeter + "m";
        GText.text = "コインx"+ Gcoin;/**/
        MutekiText.text = "";
    }

    void Update()
    {
        CountMeter();
        CountKMeter();
        CountCoin();
    }
    public void CountMeter()
    {
        GMeter = PlayerC.GetMeter();
        MText.text = "走行距離:" + GMeter + "m";
    }
    public void CountKMeter()
    {
        GMeter = PlayerC.GetMeter();
        if(GMeter>=1000)
        {
            GKMeter = PlayerC.GetKMeter();
            MText.text = "走行距離:" + GKMeter + "." + (GMeter / 10 - GKMeter * 100) + "km";    
        }       
    }
    public void CountCoin()
    {
        Gcoin = PlayerC.GetCoin();
        GText.text = "コインx" + Gcoin;
    }
    public void GetMuteki()
    {
        MutekiText.text = "加速！";
    }
    public void GetNoMuteki()
    {
        MutekiText.text = "";
    }
    public void GetMutekikire()
    {

        MutekiText.text = "加速！(残り"+PlayerC.countTime.ToString("N1")+"秒)";
    }
    public static int GetGMeter()
    {
        return GMeter;
    }
    public static int GetGKMeter()
    {
        return GKMeter;
    }
    public static int GetGCoin()
    {
        return Gcoin;
    }

}
