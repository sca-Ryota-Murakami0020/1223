using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveC : MonoBehaviour
{

    private float speed=0.01f;
    private PlayerC PL;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,-speed);
        if(PlayerC.Muteki==true)
        {
            transform.Translate(0, 0, -speed * 1.2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("D"))
        {
            Destroy(this.gameObject);
        }
    }
}
