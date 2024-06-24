using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackImageSizeFix : MonoBehaviour
{
    private CustomTexture customTexture;
    // Start is called before the first frame update
    void Start()
    {
        customTexture = GetComponent<CustomTexture>();
        customTexture.pos.width = Screen.width;
        customTexture.pos.height = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
