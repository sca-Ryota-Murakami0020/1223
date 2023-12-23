using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeC : MonoBehaviour
{
    public GameObject[] CubePrefabs;
    private float time;
    private int number;
    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(2.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            time = Random.Range(5.0f, 8.0f);
            number = Random.Range(0, CubePrefabs.Length);
            Instantiate(CubePrefabs[number], new Vector3(1.0f, 1.5f, 7.5f), Quaternion.identity);
        }
    }
}
