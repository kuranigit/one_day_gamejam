using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoroller : MonoBehaviour
{
    private Transform enemyTramsfprm;
    private Vector3 enemyPos;
    private float enemySpeed;

    void Start()
    {
        enemyTramsfprm = this.transform;
        enemyPos = enemyTramsfprm.position;
        enemySpeed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        EnemyDestroy();
    }

    void EnemyMove()
    {
        enemyPos += Vector3.back * Time.deltaTime * enemySpeed;
        enemyTramsfprm.position = enemyPos;
    }

    void EnemyDestroy()
    {
        if(enemyTramsfprm.position.z < -20)
        {
            Destroy(gameObject);
        }
    }
}
