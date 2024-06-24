using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : PanelBase<SettingPanel>
{
    public CustomButton closeBtn;

    public CustomToggle musicToggle;
    public CustomToggle soundToggle;

    public CustomSlider musicSlider;
    public CustomSlider soundSlider;

    private void Start()
    {
        closeBtn.clickEvent += () =>
        {
            HideSelf();
            if (SceneManager.GetActiveScene().name == "BeginScene")
                BeginPanel.Instance.ShowSelf();
        };

        musicSlider.onValueChanged += (value) => GameDataMgr.Instance.ChangeMusicValue(value);
        soundSlider.onValueChanged += (value) => GameDataMgr.Instance.ChangeSoundValue(value);

        musicToggle.selectEvent += (value) => GameDataMgr.Instance.OpenOrCloseMusic(value);
        soundToggle.selectEvent += (value) => GameDataMgr.Instance.OpenOrCloseSound(value);

        HideSelf();
    }

    private void UpdatePanelInfo()
    {
        MusicData data = GameDataMgr.Instance.musicData;

        musicToggle.isSel = data.isPlayingMusic;
        soundToggle.isSel = data.isPlayingSound;

        musicSlider.nowValue = data.musicValue;
        soundSlider.nowValue = data.soundValue;
    }

    public override void ShowSelf()
    {
        base.ShowSelf();
        UpdatePanelInfo();
    }

    public override void HideSelf()
    {
        base.HideSelf();
        Time.timeScale = 1.0f;
    }
}
