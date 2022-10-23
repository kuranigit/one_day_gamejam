using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    public int chargeHave = 0;
    public int life = 10;
    public float time = 30;
    public bool disappearFlag = false;
    public float disppearTime = 5;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    
}
