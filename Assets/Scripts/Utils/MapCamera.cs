using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    public Transform targerPlayer;

    public float H = 10;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (targerPlayer == null)
        {
            return;
        }

        pos.x = targerPlayer.position.x;
        pos.z = targerPlayer.position.z;
        pos.y = H;
        transform.position = pos;
    }
}
