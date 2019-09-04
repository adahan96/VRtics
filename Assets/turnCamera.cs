using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnCamera : MonoBehaviour
{
    int times;
    // Start is called before the first frame update
    void Start()
    {
        times = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
       if(times != 0)
        {
            times--;
            this.transform.Rotate(0, -1, 0);
            Debug.Log(this.transform.rotation);
        }
    }
}
