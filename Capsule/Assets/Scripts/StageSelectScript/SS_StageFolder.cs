using System.Collections;
using System.Collections.Generic;
using Core.Global;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using ScriptableObject;
using Sound;

public class SS_StageFolder : MonoBehaviour
{
    private int StageNumNow = 0;
    private int StageNumLimit = 3;
    private int StageNumBefore = 1;
    private float MoveTimeNow = 0;
    public float MoveTimeLong = 1.0f;

    public StageListData StageListData;
    private StageData[] SD => StageListData.Stages;
    private GameObject[] SLGO;
    public GameObject SLPrefab;
    private GameObject[] SSSGO;
    public GameObject SSSPrefab;
    private GameObject[] ASGO;
    public GameObject ASPrefab;

    public GameObject StageList;
    private RectTransform[] SLRT;
    public GameObject SSS;
    private RectTransform[] SSSRT;
    public GameObject AS;
    private RectTransform[] ASRT;

    void Start()
    {
        SLGO = new GameObject[SD.Length];
        SLRT = new RectTransform[SD.Length];
        SSSGO = new GameObject[SD.Length];
        SSSRT = new RectTransform[SD.Length];
        ASGO = new GameObject[SD.Length];
        ASRT = new RectTransform[SD.Length];
        for (int ii = 0; ii < SD.Length; ii++)
        {
            SLGO[ii] = Instantiate(SLPrefab, StageList.transform.position, StageList.transform.rotation, StageList.transform);
            SSSGO[ii] = Instantiate(SSSPrefab, SSS.transform.position, SSS.transform.rotation, SSS.transform);
            ASGO[ii] = Instantiate(ASPrefab, AS.transform.position, AS.transform.rotation, AS.transform);

            SLGO[ii].GetComponent<Image>().sprite = Sprite.Create(SD[ii].StageThumbnail, new Rect(0, 0, SD[ii].StageThumbnail.width, SD[ii].StageThumbnail.height), Vector2.zero);
            SSSGO[ii].GetComponent<Image>().sprite = Sprite.Create(SD[ii].StageThumbnail, new Rect(0, 0, SD[ii].StageThumbnail.width, SD[ii].StageThumbnail.height), Vector2.zero);
            ASGO[ii].GetComponent<TextMeshProUGUI>().text = MakeStageOverview(ii, $"<color=#{0xBBBB00FF:X}>WriteStageState</color>");
            // WriteStageState = Clear!! toka NewStage toka

            SLRT[ii] = SLGO[ii].GetComponent<RectTransform>();
            SSSRT[ii] = SSSGO[ii].GetComponent<RectTransform>();
            ASRT[ii] = ASGO[ii].GetComponent<RectTransform>();
            float mn = -ii + StageNumNow + -(StageNumNow - StageNumBefore) / Mathf.Abs(StageNumNow - StageNumBefore) * MoveTimeNow / MoveTimeLong;
            SLRT[ii].anchoredPosition = new Vector3(mn * -530, SLRT[ii].anchoredPosition.y, 0);
            SSSRT[ii].anchoredPosition = new Vector3(mn * -1170, SSSRT[ii].anchoredPosition.y, 0);
            ASRT[ii].anchoredPosition = new Vector3(mn * -700, ASRT[ii].anchoredPosition.y, 0);
        }

        StageNumBefore = StageNumNow;
        StageNumLimit = SD.Length;

        Global.SoundPlayer.PlaySE(SeType.OK);
        
        Global.SoundPlayer.PlayBGM(BgmType.StageSelect);
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            StageNumDec();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StageNumInc();
        }
    }

    public string MakeStageOverview(int folderNum, string StageStateText)
    {

        // 6GyoumeMade
        return "No. " + (folderNum + 1)
            + "\n" + ""
            + "\n" + SD[folderNum].StageName
            + "\n" + ""
            + "\n" + "Creator:" + SD[folderNum].LevelDesigner.Name
            + "\n" + "";
    }

    public void StageNumInc()
    {
        Global.SoundPlayer.PlaySE(SeType.Select);
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
        Global.SoundPlayer.PlaySE(SeType.Select);
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
                ASRT[ii].anchoredPosition = new Vector3(mn * -700, ASRT[ii].anchoredPosition.y, 0);
            }
        }
    }

    public void StartStage()
    {
        SceneTracker.ssToIG = true;
        Global.SetCurrentStageData(SD[StageNumNow]);
        SceneManager.LoadScene("PreInGame");
    }

    public void OpenSetting()
    {
        Debug.Log("KokoniSettexinnguWoIreteKudasai");
    }

    public void BackToTitle()
    {
        SceneTracker.returnTitleScene = true;
        SceneManager.LoadScene("Title");
    }
}
