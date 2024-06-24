using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;

public class GamePanel : PanelBase<GamePanel>
{
    public CustomButton settingBtn;
    public CustomButton quitBtn;

    public CustomLabel scoreLabel;
    public CustomLabel timeLabel;

    public CustomTexture hpImage;
    public CustomTexture maxHpImage;

    public float hpWidth = 3.5f;
    [HideInInspector]
    public int score = 0;
    [HideInInspector]
    public float nowTime = 0;

    private int hour;
    private int minute;
    private int second;

    private void Start()
    {
        settingBtn.clickEvent += () =>{
            SettingPanel.Instance.ShowSelf();
            Time.timeScale = 0;
        };

        quitBtn.clickEvent += () =>
        {
            QuitPanel.Instance.ShowSelf();
            Time.timeScale = 0;
        };

        AddScore(10);
        //UpdateHpBar(100, 30);

    }

    private void Update()
    {
        nowTime += Time.deltaTime;

        hour = (int)nowTime / 3600;
        minute = (int)(nowTime % 3600) / 60;
        second = (int)nowTime % 60;
        timeLabel.content.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);

    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreLabel.content.text = this.score.ToString();
    }

    public void UpdateHpBar(int maxHp,int hp)
    {
        maxHpImage.pos.width = maxHp * hpWidth;
        hpImage.pos.width = hp* hpWidth;
    }
}
