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

            //�e�L�X�g�̍X�V
            //1km�����̑��s
            if(resultMeter < 1000)
                resultText.text = $"���s�����F{resultMeter}m,�R�C���F{resultCoin}��";
            //1km�ȏ�̑��s
            if(resultMeter > 1000)
            {
                var k = resultMeter / 1000;
                var m = resultMeter - k * 1000;
                resultText.text = $"���s�����F{k}.{m}km,�R�C���F{resultCoin}��";
            }

            var change = false;
            //�n�C�X�R�A�X�V�i�����j
            if(highMeter < resultMeter)
            {
                highMeter = resultMeter;
                change = true;
            }
            //�n�C�X�R�A�X�V�i�R�C���j
            if(highCoin < resultCoin) highCoin = resultCoin;

            //1km�����̑��s
            if (highMeter < 1000)
                highScoreText.text = $"���s�����F{highMeter}m,�R�C���F{highCoin}��";
            //1km�ȏ�̑��s
            if (highMeter > 1000)
            {
                var k = highMeter / 1000;
                var m = highMeter - k * 1000;
                highScoreText.text = $"���s�����F{k}.{m}km,�R�C���F{highCoin}��";
            }
            //���S�̕\��
            if(change)
                highImage.enabled = true;
        }
    }
}
