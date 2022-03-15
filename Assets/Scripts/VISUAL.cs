using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class VISUAL : MonoBehaviour {

    public TextMeshProUGUI Text;




    void Start() {
        
        Text.text = "E-Stage: 0";

        
    }


    void Update() {
        if (Input.GetKeyDown("space")) {

            DATA.PUBLIC_START = true;
            //Debug.Log("space");
            DATA.FOODDELETES = false;

            
        }

        if (Input.GetKeyDown("e") && DATA.Stage_Start == false) {

            // Array.clear(DATA.speedTraitcounter,0,DATA.speedTraitcounterN);
            // DATA.speedTraitcounterN = 0;

            DATA.Stage_Start = true;
            DATA.Stage_End = false;
            DATA.E_Stage++;
            //Debug.Log("e");
            DATA.FOODDELETES = false;
            
            
        }

        if (Input.GetKeyDown("q") && DATA.Stage_End == false) {

            DATA.Stage_End = true;
            DATA.Stage_Start = false;
            DATA.PUBLIC_START = false;
            DATA.FoodDeployStatus = false;
            DATA.FOODDELETES = true;

            //Debug.Log("q");
            
            
        }

        

        Text.text = "E-Stage: " + DATA.E_Stage;
    }
}
    
