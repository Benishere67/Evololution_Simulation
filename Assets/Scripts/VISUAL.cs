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
            

            
        }

        if (Input.GetKeyDown("e") && DATA.Stage_Start == false) {

            DATA.Stage_Start = true;
            DATA.E_Stage++;
            
        }

        

        Text.text = "E-Stage: " + DATA.E_Stage;
    }
}
