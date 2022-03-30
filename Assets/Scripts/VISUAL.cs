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
    float AverageSightList;
    float AverageSizeList;





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

            DATA.SpeedTraitCounter_Length = 0;

            
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
        

        AverageSpeedList = 0;

        for (var i = 0; i < DATA.SpeedTraitCounter_Length; i++) {

            AverageSpeedList += DATA.SpeedTraitCounter[i];
            Debug.Log(DATA.SpeedTraitCounter[i]);

        }

        AverageSpeedList = AverageSpeedList / DATA.SpeedTraitCounter_Length;

        Text.text = "E-Stage: " + DATA.E_Stage;

        Speed.text = "Average_Speed= " + AverageSpeedList;
        Sight.text = "Average_Sight= " + AverageSightList;
        Size.text = "Average_Size= " + AverageSizeList;

        
    }
}
    
