using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpPower;
    //�������̔{��
    [SerializeField] private float addSpeedMag;
    //�d��
    [SerializeField] private float gravityPower;
    //�����̏���
    [SerializeField] private float initFallSpeed;
    //�������x����
    [SerializeField] private float limitSpeed;

    [SerializeField] private GameManager gameManagwer;
    [SerializeField] private Animator anim;

    //�󒆂ɂ��锻��i��i�W�����v�p�j
    private bool onAri = false;
    //��i�W�����v����������
    private bool alreadyAgainJump = false;
    //���G����
    private bool _invincibility = false;
    //�ڒn����
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

    //�v���C���[�̈ړ�
    private void MovePlayer()
    {
        //D-���S�g
        if(Input.GetKey(KeyCode.D))
            this.transform.position += this.transform.forward * playerSpeed * Time.deltaTime;
        //A�[�����
        if(Input.GetKey(KeyCode.A))
            this.transform.position -= this.transform.forward * playerSpeed * Time.deltaTime;
        //�W�����v����
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //�ʏ�W�����v
            if (onGround && !onAri) anim.SetTrigger("Jump");
            //��i�W�����v
            if (onAri && !alreadyAgainJump)
            {
                anim.SetTrigger("AgainJump");
                //Debug.Log("�Ăяo��");
                alreadyAgainJump = true;
            }
        }
    }

    //�W�����v����
    public void PlayerJump()
    {
        this.transform.position += new Vector3(0, jumpPower, 0);
        if(alreadyAgainJump) Debug.Log("kasanmnm");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //���n����
        if(collision.gameObject.tag == "Grand")
        {
            onGround = true;
            onAri = false;
            alreadyAgainJump = false;
            anim.SetBool("OnAri",false);
            Debug.Log("���n");
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
