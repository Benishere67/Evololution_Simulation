using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VISUAL : MonoBehaviour {

    public TextMeshProUGUI Text;




    void Start() {
        
        Text.text = "E-Stage: 0";

        
    }


    void Update() {
        if (Input.GetKeyDown("space")) {

            DATA.PUBLIC_START = true;
            Debug.Log("space");
            

            
        }

        if (Input.GetKeyDown("e") && DATA.Stage_Start == false) {

            DATA.Stage_Start = true;
            DATA.Stage_End = false;
            DATA.E_Stage++;
            Debug.Log("e");
            
        }

        if (Input.GetKeyDown("q") && DATA.Stage_End == false) {

            DATA.Stage_End = true;
            DATA.Stage_Start = false;
            Debug.Log("q");
            
            
        }

        

        Text.text = "E-Stage: " + DATA.E_Stage;
    }
}
