using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreC : MonoBehaviour
{    
    private Rizaluto RZ;
    public Text  HText;
    public int oldMeter;
    public int oldKMeter;
    public static int MMeter;
    public static int MKMeter;
    public static int NewMeter;
    public static int NewKMeter;
    //public static int Newcoin;

    // Start is called before the first frame update
    void Start()
    {
        //RZ=GetComponent<Rizaluto>();
        oldMeter=MMeter;
        NewMeter = Rizaluto.GetRMeter();
        oldKMeter=MKMeter;
        NewKMeter = Rizaluto.GetRKMeter();
        HText.text = "";
        //Newcoin = Rizaluto.GetRcoin();
        //oldcoin=Newcoin;/**/
        /**/
        /*if (oldMeter<=0&&oldKMeter<=0&&oldcoin<=0)
        {
            Debug.Log("A");
            HText.text="ハイスコア:走行距離0m・コイン0枚" ;
        }
        if(oldMeter > 0 && oldMeter<1000 && oldKMeter <= 0 && oldcoin >= 0)
        {
            Debug.Log("B");
            HText.text = "ハイスコア:走行距離"+oldKMeter+"m・コイン"+oldcoin+"枚";
        }
        if (oldMeter > 0 && oldMeter >= 1000 && oldKMeter > 0 && oldcoin >= 0)
        {
            Debug.Log("C");
            HText.text = "ハイスコア:走行距離" + oldKMeter+(oldMeter/10-oldKMeter*100) + "km・コイン" + oldcoin+"枚";
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        /*NewMeter = Rizaluto.GetRMeter();NewKMeter = Rizaluto.GetRKMeter();Newcoin = Rizaluto.GetRcoin();getNewcoin();getNewKMeter();getNewMeter();*/
        High();
    }
    //新しい関数を作って処理する

    public void getNewMeter()
    {
        //oldMeter = NewMeter;
        if (oldMeter<NewMeter)
        {
            oldMeter=NewMeter;
            MMeter=oldMeter;
            //NewMeter=0;
        }
    }

    public void getNewKMeter()
    {
        //oldKMeter = NewKMeter;
        if (oldKMeter<NewKMeter)
        {
            oldKMeter=NewKMeter;
            MKMeter=oldKMeter;
            //NewKMeter=0;
        }
    }

    public void High()
    {
        //getNewcoin();
        getNewMeter();
        getNewKMeter();
        if (MMeter >= 0 && MMeter < 1000 && MKMeter <= 0)
        {
            HText.text = "走行距離:" + MMeter + "m";
        }
        if (MMeter >= 0 && MMeter >= 1000 && MKMeter > 0)
        {
            HText.text = "走行距離:" + MKMeter +"."+ (MMeter / 10 - MKMeter * 100) + "km" ;
        }
        if (oldMeter <= 0 && oldKMeter <= 0)
        {
            HText.text = "走行距離:0m";
        }
    }
}
