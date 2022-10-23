using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    [SerializeField]private GameObject clear;
    [SerializeField]private GameObject life;
    [SerializeField] private GameObject stageTime;
    [SerializeField] private GameObject count;
    [SerializeField] private GameObject charge;
    private Text clearText;
    private Text lifeText;
    private Text timeText;
    private Text countText;
    private Text chargeText;
    [SerializeField] PlayerController playerController;
    private bool clearFlag;
    private bool overFlag;

    void Start()
    {
        clearText = clear.GetComponent<Text>();
        lifeText = life.GetComponent<Text>();
        timeText = stageTime.GetComponent<Text>();
        countText = count.GetComponent<Text>();
        chargeText = charge.GetComponent<Text>();
        clearFlag = false;
        overFlag = false;
    }

    
    void Update()
    {   
        ClearText();
        LifeText();
        TimeText();
        CountText();
        ChargeText();
    }

    public void ClearText()
    {
        if (GManager.instance.life > 0 && GManager.instance.time < 0 && !overFlag)
        {
            clearFlag = true;
            clearText.text = "CREARE！";
        }
        if (GManager.instance.life <= 0 && !clearFlag)
        {
            overFlag = true;
            clearText.text = "GAME OVER...";
        }
    }

    public void LifeText()
    {
        if (GManager.instance.life >= 0)
        {
            lifeText.text = "LIFE:" + GManager.instance.life.ToString();
        }
    }

    public void TimeText()
    {
        if (GManager.instance.time > 0)
        {
            timeText.text = "のこり:" + GManager.instance.time.ToString("n1");
        }
    }

    public void CountText()
    {
        if (GManager.instance.disappearFlag)
        {
            countText.text = "とうめいタイム:" +( GManager.instance.disppearTime - playerController.currentTime).ToString("n1");
        }
        else
        {
            countText.text = " ";
        }
    }

    public void ChargeText()
    {
        chargeText.text = "アイテム:" + GManager.instance.chargeHave.ToString();
    }
}
