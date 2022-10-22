using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGerator : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private int[] posArray = { -3, 0, 3 };
    private float generateSpan, currentTime;
    PlayerController playerController;
    private Transform playerTransform;

    void Start()
    {
        generateSpan = 0.5f;
        currentTime = 0;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > generateSpan)
        {
            EnemyGenerate();
            currentTime = 0;
        }
    }

    private void EnemyGenerate()
    {
        Instantiate(enemyPrefab, new Vector3(posArray[Random.Range(0, 3)], 1.06f, 20f), Quaternion.identity);
    }
}
