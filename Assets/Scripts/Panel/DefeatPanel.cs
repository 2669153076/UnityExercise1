using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatPanel : PanelBase<DefeatPanel>
{
    public CustomButton backBtn;
    public CustomButton restartBtn;
    // Start is called before the first frame update
    void Start()
    {
        backBtn.clickEvent += () =>
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("BeginScene");
        };
        restartBtn.clickEvent += () =>
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("GameScene");
        };
        HideSelf();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
