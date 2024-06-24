using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomToggleGroup : MonoBehaviour
{
    public CustomToggle[] customToggles;
    private CustomToggle frontTrueToggle;

    private void Start()
    {
        if(customToggles == null)
        {
            return;
        }
        for(int i = 0; i < customToggles.Length; i++)
        {
            CustomToggle toggle = customToggles[i];
            toggle.selectEvent += (value) =>
            {
                if (value)
                {
                    for (int j = 0; j < customToggles.Length; j++)
                    {
                        if (customToggles[j] != toggle ) {
                            customToggles[j].isSel = false;
                        }
                    }
                    frontTrueToggle = toggle;
                }
                else if(frontTrueToggle == toggle)
                {
                    toggle.isSel = true;
                }
            };
        }
    }
}
