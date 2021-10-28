using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController
{
    private const string _Mission1 = "Mission1";
    private const string _Mission2 = "Mission2";

    /// <summary>
    /// �~�b�V�����t���O������������
    /// </summary>
    public void InitMissionFlug()
    {
        PlayerPrefs.SetInt(Constants.MISSION1, 0);
        PlayerPrefs.SetInt(Constants.MISSION2, 0);
        Save();
    }

    /// <summary>
    /// �~�b�V�����̃N���A�󋵂��Z�[�u����
    /// </summary>
    public void ClearMisson(int missionNo)
    {
        switch (missionNo)
        {
            case 1:
                break;
            case 2:
                break;
            default:
                Debug.LogError("�������s���ł�");
                break;
        }
        PlayerPrefs.SetInt(missionNo.ToString(), 1);
    }

    private void Save()
    {
        PlayerPrefs.Save();
    }

}
