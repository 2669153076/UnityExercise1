using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CustomGUIRoot : MonoBehaviour
{
    private CustomGUIBase[] customControls;

    void Start()
    {
        customControls = GetComponentsInChildren<CustomGUIBase>();
    }

    private void OnGUI()
    {
        customControls = GetComponentsInChildren<CustomGUIBase>();

        for(int i = 0; i < customControls.Length; i++)
        {
            customControls[i].DrawGUI();
        }
    }
    
}
