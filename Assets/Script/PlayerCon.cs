using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpPower;
    //加速時の倍率
    [SerializeField] private float addSpeedMag;
    //重力
    [SerializeField] private float gravityPower;
    //落下の初速
    [SerializeField] private float initFallSpeed;
    //落下速度制限
    [SerializeField] private float limitSpeed;

    [SerializeField] private GameManager gameManagwer;
    [SerializeField] private Animator anim;

    //空中にいる判定（二段ジャンプ用）
    private bool onAri = false;
    //二段ジャンプをした判定
    private bool alreadyAgainJump = false;
    //無敵判定
    private bool _invincibility = false;
    //接地判定
    private bool onGround;

    public bool Invincibility
    {
        get { return this._invincibility;}
        set { this._invincibility = value;}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Debug.Log($"OnAri:{onAri},Al:{alreadyAgainJump},G:{onGround}");
    }

    //プレイヤーの移動
    private void MovePlayer()
    {
        //D-＞全身
        if(Input.GetKey(KeyCode.D))
            this.transform.position += this.transform.forward * playerSpeed * Time.deltaTime;
        //Aー＞後退
        if(Input.GetKey(KeyCode.A))
            this.transform.position -= this.transform.forward * playerSpeed * Time.deltaTime;
        //ジャンプ処理
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //通常ジャンプ
            if (onGround && !onAri) anim.SetTrigger("Jump");
            //二段ジャンプ
            if (onAri && !alreadyAgainJump)
            {
                anim.SetTrigger("AgainJump");
                //Debug.Log("呼び出し");
                alreadyAgainJump = true;
            }
        }
    }

    //ジャンプ処理
    public void PlayerJump()
    {
        this.transform.position += new Vector3(0, jumpPower, 0);
        if(alreadyAgainJump) Debug.Log("kasanmnm");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //着地判定
        if(collision.gameObject.tag == "Grand")
        {
            onGround = true;
            onAri = false;
            alreadyAgainJump = false;
            anim.SetBool("OnAri",false);
            Debug.Log("着地");
            anim.SetTrigger("Landing");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Grand")
        {
            onAri = true;
            anim.SetBool("OnAri",true);
            onGround = false;
        }
    }
}
