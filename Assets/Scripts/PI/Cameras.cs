using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{

    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;
    public Camera camera5;
    public Camera camera6;
    public Camera camera7;
 
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0.3F;
    }

    // Update is called once per frame
    void Update(){
        if(counter> 0){
            counter = counter - Time.deltaTime;
        }
        else{

    if (Input.GetKeyDown("1")){ 
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;
        camera4.enabled = false;
        camera5.enabled = false;
        camera6.enabled = false;
        camera7.enabled = false;
        counter = 0.3F;
    } else {
    if (Input.GetKeyDown("2")){
        camera1.enabled = false;
        camera2.enabled = true;
        camera3.enabled = false;
        camera4.enabled = false;
        camera5.enabled = false;
        camera6.enabled = false;
        camera7.enabled = false;
        counter = 0.3F;
     
    }
    else {
    if(Input.GetKeyDown("3")){
        camera1.enabled = false;
        camera2.enabled = false;
        camera3.enabled = true;
        camera4.enabled = false;
        camera5.enabled = false;
        camera6.enabled = false;
        camera7.enabled = false;
        counter = 0.3F;
    }
    else{
    if (Input.GetKeyDown("4")){
        camera1.enabled = false;
        camera2.enabled = false;
        camera3.enabled = false;
        camera4.enabled = true;
        camera5.enabled = false;
        camera6.enabled = false;
        camera7.enabled = false;
        counter = 0.3F;
    }
    else{
        if (Input.GetKeyDown("5")){
        camera1.enabled = false;
        camera2.enabled = false;
        camera3.enabled = false;
        camera4.enabled = false;
        camera5.enabled = true;
        camera6.enabled = false;
        camera7.enabled = false;
        counter = 0.3F;
    }
    else{
    if (Input.GetKeyDown("6")){
        camera1.enabled = false;
        camera2.enabled = false;
        camera3.enabled = false;
        camera4.enabled = false;
        camera5.enabled = false;
        camera6.enabled = true;
        camera7.enabled = false;
        counter = 0.3F;
    }
    else{
    if (Input.GetKeyDown("7")){
        camera1.enabled = false;
        camera2.enabled = false;
        camera3.enabled = false;
        camera4.enabled = false;
        camera5.enabled = false;
        camera6.enabled = false;
        camera7.enabled = true;
        counter = 0.3F;
    }
    }
    }
    }
    }
    }
    }
        }
}
}