using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollC : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerC PL;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0, 0, -0.4f));
        if(PlayerC.Muteki==true)
        {
            rb.AddForce(new Vector3(0, 0, -0.4f*1.2f));
        }
    }
}
