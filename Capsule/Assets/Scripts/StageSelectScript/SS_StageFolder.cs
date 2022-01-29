using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ScriptableObject;

public class SS_StageFolder : MonoBehaviour
{
    private int StageNumNow = 0;
    private int StageNumLimit = 3;
    private int StageNumBefore = 1;
    private float MoveTimeNow = 0;
    public float MoveTimeLong = 1.0f;

    public StageData[] SD;
    private GameObject[] SLGO;
    public GameObject SLPrefab;
    private GameObject[] SSSGO;
    public GameObject SSSPrefab;

    public GameObject StageList;
    private RectTransform[] SLRT;
    public GameObject SSS;
    private RectTransform[] SSSRT;
    public GameObject AS;
    private RectTransform ASRT;

    void Start()
    {
        SLGO = new GameObject[SD.Length];
        SSSGO = new GameObject[SD.Length];
        SLRT = new RectTransform[SD.Length];
        SSSRT = new RectTransform[SD.Length];
        for (int ii = 0; ii < SD.Length; ii++)
        {
            SLGO[ii] = Instantiate(SLPrefab, StageList.transform.position, StageList.transform.rotation, StageList.transform);
            SSSGO[ii] = Instantiate(SSSPrefab, SSS.transform.position, SSS.transform.rotation, SSS.transform);

            SLGO[ii].GetComponent<Image>().sprite = Sprite.Create(SD[ii].StageThumbnail, new Rect(0, 0, SD[ii].StageThumbnail.width, SD[ii].StageThumbnail.height), Vector2.zero);
            SSSGO[ii].GetComponent<Image>().sprite = Sprite.Create(SD[ii].StageThumbnail, new Rect(0, 0, SD[ii].StageThumbnail.width, SD[ii].StageThumbnail.height), Vector2.zero);

            SLRT[ii] = SLGO[ii].GetComponent<RectTransform>();
            SSSRT[ii] = SSSGO[ii].GetComponent<RectTransform>();
            float mn = -ii + StageNumNow + -(StageNumNow - StageNumBefore) / Mathf.Abs(StageNumNow - StageNumBefore) * MoveTimeNow / MoveTimeLong;
            SLRT[ii].anchoredPosition = new Vector3(mn * -530, SLRT[ii].anchoredPosition.y, 0);
            SSSRT[ii].anchoredPosition = new Vector3(mn * -1170, SSSRT[ii].anchoredPosition.y, 0);
        }
        ASRT = AS.GetComponent<RectTransform>();

        StageNumBefore = StageNumNow;
        StageNumLimit = SD.Length;
    }

    void Update()
    {
        if (MoveTimeNow > 0)
        {
            MoveTimeNow -= Time.deltaTime;
            StageListMove();
        }
        if (MoveTimeNow < 0)
        {
            MoveTimeNow = 0;
            StageListMove();
        }
    }

    public void StageNumInc()
    {
        if (MoveTimeNow <= 0)
        {
            MoveTimeNow = MoveTimeLong;
            StageNumBefore = StageNumNow;

            if (StageNumNow < StageNumLimit - 1)
            {
                StageNumNow++;
            }
            else
            {
                StageNumNow = StageNumLimit - 1;
            }

            StageListMove();
        }
    }
    public void StageNumDec()
    {
        if (MoveTimeNow <= 0)
        {
            MoveTimeNow = MoveTimeLong;
            StageNumBefore = StageNumNow;

            if (StageNumNow > 0)
            {
                StageNumNow--;
            }
            else
            {
                StageNumNow = 0;
            }

            StageListMove();
        }
    }

    public void StageListMove()
    {
        if (StageNumNow != StageNumBefore)
        {
            for (int ii = 0; ii < SD.Length; ii++)
            {
                float mn = -ii + StageNumNow + -(StageNumNow - StageNumBefore) / Mathf.Abs(StageNumNow - StageNumBefore) * MoveTimeNow / MoveTimeLong;
                SLRT[ii].anchoredPosition = new Vector3(mn * -530, SLRT[ii].anchoredPosition.y, 0);
                SSSRT[ii].anchoredPosition = new Vector3(mn * -1170, SSSRT[ii].anchoredPosition.y, 0);
            }
            float mnAS = StageNumNow + -(StageNumNow - StageNumBefore) / Mathf.Abs(StageNumNow - StageNumBefore) * MoveTimeNow / MoveTimeLong;
            ASRT.anchoredPosition = new Vector3(mnAS * -700, ASRT.anchoredPosition.y, 0);
        }
    }

    public void StartStage()
    {
        SceneManager.LoadScene(SD[StageNumNow].StageScene);
    }
}
