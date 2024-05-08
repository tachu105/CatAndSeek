using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightComScr : MonoBehaviour
{
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){
            if(light.intensity == 0){
                light.intensity =1;
            }
            else{
                light.intensity =0;
            }
        }
    }
}
