using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 positionDistance;
    private Transform cameraTransform;
    private Transform playerTransform;

    void Start()
    {
        cameraTransform = this.transform;
        playerTransform = player.transform;
        //�v���C��[�ƃJ�����̃|�W�V�����̍��������߂�
        positionDistance = cameraTransform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //x����z���̍��������Ǐ]����
        cameraTransform.position = new Vector3(playerTransform.position.x + positionDistance.x,cameraTransform.position.y, playerTransform.position.z + positionDistance.z);
    }
}
