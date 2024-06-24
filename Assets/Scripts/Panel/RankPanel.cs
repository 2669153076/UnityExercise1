using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : PanelBase<RankPanel>
{
    public CustomButton closeButton;

    private List<CustomLabel> nameLabel = new List<CustomLabel>();
    private List<CustomLabel> scoreLabel = new List<CustomLabel>();
    private List<CustomLabel> timeLabel = new List<CustomLabel>();

    private void Start()
    {
        for (int i = 1; i <= 7; i++)
        {
            nameLabel.Add(transform.Find("Name/nameLabel" + i).GetComponent<CustomLabel>());
            scoreLabel.Add(transform.Find("Score/scoreLabel" + i).GetComponent<CustomLabel>());
            timeLabel.Add(transform.Find("Time/timeLabel" + i).GetComponent<CustomLabel>());
        }

        closeButton.clickEvent += () =>
        {
            BeginPanel.Instance.ShowSelf();
            HideSelf();
        };

        //GameDataMgr.Instance.AddRankData("≤‚ ‘ ˝æ›", 100, 8432);
        HideSelf();
    }

    private void UpdatePanelInfo()
    {
        List<RankData> list = GameDataMgr.Instance.rankDataList.list;

        for (int i = 0; i < list.Count; i++)
        {
            nameLabel[i].content.text = list[i].name;
            scoreLabel[i].content.text = list[i].score.ToString();
            int time = (int)list[i].time;
            int hour = time / 3600;
            int minute = (time % 3600) / 60;
            int second = time % 60;
            timeLabel[i].content.text = string.Format("{0:D2}:{1:D2}:{2:D2}",hour,minute,second);
            
        }

    }

    public override void ShowSelf()
    {
        base.ShowSelf();
        UpdatePanelInfo();
    }

}
