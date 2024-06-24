using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel :PanelBase<QuitPanel>
{
    public CustomButton closeBtn;
    public CustomButton quitBtn;
    public CustomButton cancelBtn;

    // Start is called before the first frame update
    void Start()
    {
        closeBtn.clickEvent += () =>
        {
            HideSelf();
        };
        quitBtn.clickEvent += () =>
        {
            SceneManager.LoadScene("BeginScene");
        };
        cancelBtn.clickEvent += () =>
        {
            HideSelf();
        };
        HideSelf();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HideSelf()
    {
        base.HideSelf();
        Time.timeScale = 1.0f;
    }
}
