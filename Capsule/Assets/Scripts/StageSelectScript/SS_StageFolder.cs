using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_StageFolder : MonoBehaviour
{
    public int StageNumNow = 1;
    public int StageNumLimit = 3;

    public GameObject StageList;
    private RectTransform SLRT;
    public GameObject SSS;
    private RectTransform SSSRT;
    public GameObject AS;
    private RectTransform ASRT;

    void Start()
    {
        SLRT = StageList.GetComponent<RectTransform>();
        SSSRT = SSS.GetComponent<RectTransform>();
        ASRT = AS.GetComponent<RectTransform>();
    }

    void Update()
    {

    }

    public void StageNumInc()
    {
        if (StageNumNow < StageNumLimit)
            StageNumNow++;
        else
            StageNumNow = StageNumLimit;

        StageListMove();
    }
    public void StageNumDec()
    {
        if (StageNumNow > 1)
            StageNumNow--;
        else
            StageNumNow = 1;

        StageListMove();
    }

    public void StageListMove()
    {
        SLRT.anchoredPosition = new Vector3((StageNumNow - 1) * -530, SLRT.anchoredPosition.y, 0);
        SSSRT.anchoredPosition = new Vector3((StageNumNow - 1) * -1170, SLRT.anchoredPosition.y, 0);
        ASRT.anchoredPosition = new Vector3((StageNumNow - 1) * -700, SLRT.anchoredPosition.y, 0);
    }
}
