using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;


public class VISUAL : MonoBehaviour {

    public TextMeshProUGUI Text;

    public TextMeshProUGUI Speed;
    public TextMeshProUGUI Sight;
    public TextMeshProUGUI Size;

    float AverageSpeedList;




    void Start() {
        
        Text.text = "E-Stage: 0";

        Speed.text = "E-Stage: 0";
        Sight.text = "E-Stage: 0";
        Size.text = "E-Stage: 0";

        
    }


    void Update() {
        if (Input.GetKeyDown("space")) {

            DATA.PUBLIC_START = true;
            //Debug.Log("space");
            DATA.FOODDELETES = false;


            DATA.SpeedTraitCounter.Clear();
            DATA.SightTraitCounter.Clear();
            DATA.SizeTraitCounter.Clear();

            SpeedTraitCounter_Length = 0;

            
        }

        if (Input.GetKeyDown("e") && DATA.Stage_Start == false) {

            


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

        for (var i = 0; i < SpeedTraitCounter_Length; i++) {

            

        }
        AverageSpeedList = DATA.SpeedTraitCounter.Av

        Text.text = "E-Stage: " + DATA.E_Stage;

        Speed.text = "Average_Speed= " + AverageList;
        Sight.text = "E-Stage: " + DATA.E_Stage;
        Size.text = "E-Stage: " + DATA.E_Stage;

        
    }
}
    
