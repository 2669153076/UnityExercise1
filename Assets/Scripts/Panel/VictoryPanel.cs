using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPanel : PanelBase<VictoryPanel>
{
    public CustomTextField inputInfo;
    public CustomButton enterBtn;

    // Start is called before the first frame update
    void Start()
    {
        enterBtn.clickEvent += () =>
        {
            Time.timeScale = 1;
            GameDataMgr.Instance.AddRankData(inputInfo.content.text, GamePanel.Instance.score, GamePanel.Instance.nowTime);
            SceneManager.LoadScene("BeginScene");
        };

        HideSelf();
    }

}
