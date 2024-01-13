using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReResult : MonoBehaviour
{
    private int resultCoin = 0;
    private int resultMeter = 0;
    private int highCoin = 0;
    private int highMeter = 0;
    
    private Text resultText = null;
    private Text highScoreText = null;
    private Image highImage = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StageLoaded(Scene nextStage, LoadSceneMode mode)
    {
        if(nextStage.name == "SampleScene")
        {
            resultText = null;
            highScoreText = null;
            highImage = null;
        }
            
        if(nextStage.name == "GameOver")
        {
            resultText = GameObject.Find("Score").GetComponent<Text>();
            highScoreText = GameObject.Find("HScore").GetComponent<Text>();
            highImage = GameObject.Find("NewHigh").GetComponent<Image>();
            highImage.enabled = false;

            //テキストの更新
            //1km未満の走行
            if(resultMeter < 1000)
                resultText.text = $"走行距離：{resultMeter}m,コイン：{resultCoin}枚";
            //1km以上の走行
            if(resultMeter > 1000)
            {
                var k = resultMeter / 1000;
                var m = resultMeter - k * 1000;
                resultText.text = $"走行距離：{k}.{m}km,コイン：{resultCoin}枚";
            }

            var change = false;
            //ハイスコア更新（距離）
            if(highMeter < resultMeter)
            {
                highMeter = resultMeter;
                change = true;
            }
            //ハイスコア更新（コイン）
            if(highCoin < resultCoin) highCoin = resultCoin;

            //1km未満の走行
            if (highMeter < 1000)
                highScoreText.text = $"走行距離：{highMeter}m,コイン：{highCoin}枚";
            //1km以上の走行
            if (highMeter > 1000)
            {
                var k = highMeter / 1000;
                var m = highMeter - k * 1000;
                highScoreText.text = $"走行距離：{k}.{m}km,コイン：{highCoin}枚";
            }
            //ロゴの表示
            if(change)
                highImage.enabled = true;
        }
    }
}
