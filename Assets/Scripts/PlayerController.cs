using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 playerPos;
    [SerializeField] private Vector3 leftForce, rightForce;
    private Vector4 clear;
    private Vector4 usuallyColor;
    private Renderer playerAlbedo;
    private Rigidbody playerRb;
    private bool jumpFlag;
    public float currentTime = 0;

    void Start()
    {
        playerTransform = this.transform;
        playerPos = playerTransform.position;
        playerAlbedo = gameObject.GetComponent<Renderer>();
        clear = new Vector4(0, 0.8830f, 1, 0.2f);
        usuallyColor = new Vector4(0, 0.8830f, 1,1);
        playerRb = this.GetComponent<Rigidbody>();
        jumpFlag = true;
    }

    void Update()
    {
        PlayerDisappear();
        PlayerMove();
        DisappearTime();
        GManager.instance.time -= Time.deltaTime;
    }

    private void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && playerTransform.position.x >= 0 && jumpFlag)
        {
            jumpFlag = false;
            playerRb.AddForce(leftForce);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && playerTransform.position.x <= 0 && jumpFlag)
        {
            jumpFlag = false;
            playerRb.AddForce(rightForce);
        }
    }

    private void PlayerDisappear()
    {
        if (Input.GetKey(KeyCode.Space) && GManager.instance.chargeHave >= 1 && !(GManager.instance.disappearFlag))
        {
            GManager.instance.disappearFlag = true;
            GManager.instance.chargeHave--;
            playerAlbedo.material.SetColor("_Color",clear);
        }
    }

    private void DisappearTime()
    {
        if (GManager.instance.disappearFlag)
        {
            currentTime += Time.deltaTime;
        }
        if(currentTime > GManager.instance.disppearTime)
        {
            GManager.instance.disappearFlag = false;
            playerAlbedo.material.SetColor("_Color", usuallyColor);
            currentTime = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            playerTransform.position = new Vector3(Mathf.Round(playerTransform.position.x), playerTransform.position.y, playerTransform.position.z);
            playerRb.velocity = Vector3.zero;
            jumpFlag = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "charge")
        {
            GManager.instance.chargeHave++;
            Destroy(other.gameObject);
        }
        if (other.tag == "enemy" && !GManager.instance.disappearFlag)
        {
            GManager.instance.life--;
            Destroy(other.gameObject);
        }
    }
}
