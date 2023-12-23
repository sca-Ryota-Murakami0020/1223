using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighCoin : MonoBehaviour
{
    private Rizaluto RZ;
    public Text coinText;
    public int oldcoin;
    public static int Newcoin;
    public static int Mcoin;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text="";
        oldcoin = Mcoin;
        Newcoin = Rizaluto.GetRcoin();
    }

    // Update is called once per frame
    void Update()
    {
        Highcoin();
    }

    public void getNewcoin()
    {
        if (oldcoin < Newcoin)
        {
            oldcoin = Newcoin;
            Mcoin=oldcoin;
        }
    }

    public void Highcoin()
    {
        getNewcoin();
        if(Mcoin>=0)
        {        
            coinText.text="　コイン:"+Mcoin+"枚";
        }
    }
}
