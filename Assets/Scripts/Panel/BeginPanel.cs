using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : PanelBase<BeginPanel>
{
    //���������ĳ�Ա����
    public CustomButton startBtn;
    public CustomButton exitBtn;
    public CustomButton settingBtn;
    public CustomButton rankBtn;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        //����һ�ΰ�ť�������Ҫ��ʲô
        startBtn.clickEvent += () =>
        {
            SceneManager.LoadScene("GameScene");
        };
        exitBtn.clickEvent += () =>
        {
            Application.Quit();
        };
        settingBtn.clickEvent += () =>
        {
            SettingPanel.Instance.ShowSelf();
            HideSelf();
        };
        rankBtn.clickEvent += () =>
        {
            RankPanel.Instance.ShowSelf();
            HideSelf();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
