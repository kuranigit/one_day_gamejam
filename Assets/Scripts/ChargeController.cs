using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeController : MonoBehaviour
{
    private Transform chargeTramsfprm;
    private Vector3 chargePos;
    private float chargeSpeed;

    void Start()
    {
        chargeTramsfprm = this.transform;
        chargePos = chargeTramsfprm.position;
        chargeSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        ChargeMove();
        ChargeDestroy();
    }

    void ChargeMove()
    {
        chargePos += Vector3.back * Time.deltaTime * chargeSpeed;
        chargeTramsfprm.position = chargePos;
    }

    void ChargeDestroy()
    {
        if (chargeTramsfprm.position.z < -20)
        {
            Destroy(gameObject);
        }
    }
}
