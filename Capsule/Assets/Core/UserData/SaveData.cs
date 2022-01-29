using UnityEngine;

namespace Core.UserData
{
    public class SaveDataSystem
    {
        public int GetStageProgress(string stageName)
        {
            return PlayerPrefs.GetInt(stageName);
        }

        public void SetStageProgress(string stageName, int progress)
        {
            PlayerPrefs.SetInt(stageName, progress);
        }

    }
}
