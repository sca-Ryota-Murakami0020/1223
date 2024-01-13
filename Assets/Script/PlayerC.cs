using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerC : MonoBehaviour
{
    private GameManager GM;
    private Rigidbody rb;
    private Rizaluto rz;
    [SerializeField] private Animator an;
    GameObject gm; 
    //public Text MutekiText;
    private float jumpPower=336.0f;
    private bool jumpK; 
    private static float Mcount=10.0f;/**/
    public static float countTime;
    public static bool Muteki=false;
    public static float count;
    public static int Meter;
    public static int KMeter;
    public static int coin;
    
    void Start()
    {
        gm = GameObject.Find("GameManager");
        rb = GetComponent<Rigidbody>();
        GM = gm.GetComponent<GameManager>();
        Meter = 0;
        count = 0.0f;
        coin = 0;
        countTime = Mcount;
        an.SetTrigger("WaitGame");
    }

    void Update()
    {
        count += 1.0f;
        
        if (count >= 85.0f && Muteki==false)
        {
            count = 0.0f;
            Meter += 1;
            if (Meter < 1000)
            {
                GM.CountMeter();
            }
            if (Meter >= 1000)
            {
                KMeter = Meter / 1000;
                GM.CountKMeter();
            }
        }

        if (count >= 50.0f && Muteki == true)
        {
            count = 0.0f;
            Meter += 1;
            if (Meter < 1000)
            {
                GM.CountMeter();
            }
            if (Meter >= 1000)
            {
                KMeter = Meter / 1000;
                GM.CountKMeter();
            }
        }

        if (jumpK==true)
        {
                if (Input.GetMouseButtonDown(0))
                { 
                    rb.AddForce(new Vector3(0, jumpPower, 0));
                    jumpK =false;
                }
         }

        if (Muteki == true)
        {
            MutekiCount();
        }

    }

    private void OnTriggerEnter(Collider other)//すり抜け限定
    {

        if(Muteki==false&&other.gameObject.CompareTag("D"))
        {
            SceneManager.LoadScene("GameOver");
        }
        if(other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            coin++;
        }

        if (other.gameObject.CompareTag("SuperItem"))
        {

            other.gameObject.SetActive(false);
            Muteki=true;
            GM.GetMuteki();
        }
        if (Muteki == true && other.gameObject.CompareTag("D"))
        {
            other.gameObject.SetActive(false);
        } 
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if((collision.gameObject.CompareTag("Grand")&&jumpK==false) || (collision.gameObject.CompareTag("Asiba") && jumpK == false))
        {
            jumpK=true;
        }
        if (Muteki==false&&collision.gameObject.CompareTag("D"))
        {
            SceneManager.LoadScene("GameOver");
        }
        if (Muteki == true && collision.gameObject.CompareTag("D"))
        {
            collision.gameObject.SetActive(false);
        }
    }
    public void MutekiCount()
    {  
        countTime -= Time.deltaTime;
        if(countTime<=Mcount/3.0f)
        {
            GM.GetMutekikire();
        }
        if (countTime <= 0.0f)
        {
            Muteki = false;
            countTime = Mcount;
            GM.GetNoMuteki();
        }
    }/**/
    
    public static int GetMeter()
    {
        return Meter;
    }
    public static int GetKMeter()
    {
        return KMeter;
    }
    public static int GetCoin()
    {
        return coin;
    }

}
