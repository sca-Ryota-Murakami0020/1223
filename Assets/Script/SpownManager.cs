using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownManager : MonoBehaviour
{
    public GameObject[] TrapPrefabs;
    private float time;
    private int number;
    private PlayerC PL;

    // Start is called before the first frame update
    void Start()
    {
        time=Random.Range(2.0f,4.0f);
        PL=GetComponent<PlayerC>();
    }

    // Update is called once per frame
    void Update()
    {            
        time -=Time.deltaTime;
        if(time<=0.0f)
        {
            if(PlayerC.Muteki == false)
            {
                time= Random.Range(2.0f, 4.0f);
                number=Random.Range(0,TrapPrefabs.Length);
                Instantiate(TrapPrefabs[number], new Vector3(1.0f, 0.3f, 7.5f), Quaternion.identity);
            }
            if(PlayerC.Muteki==true)
            {
                time = Random.Range(1.0f, 2.0f);
                number = Random.Range(0, TrapPrefabs.Length-1);
                Instantiate(TrapPrefabs[number], new Vector3(1.0f, 0.3f, 7.5f), Quaternion.identity);
            }

        }
    }
}
