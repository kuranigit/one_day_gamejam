using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject chargePrefab;
    private int[] posArray = { -3, 0, 3 };
    private float generateSpan,currentTime;

    void Start()
    {
        generateSpan = 6;
        currentTime = 0;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > generateSpan)
        {
            ChargeGenerate();
            currentTime = 0;
        }
    }

    private void ChargeGenerate()
    {
        Instantiate(chargePrefab, new Vector3(posArray[Random.Range(0,3)], 1.06f, 20f), Quaternion.identity);
    }

    
}
