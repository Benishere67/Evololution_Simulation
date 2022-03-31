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

        DATALOOP();

        
    }


    void Update() {
        if (Input.GetKeyDown("space")) {

            DATA.PUBLIC_START = true;
            //Debug.Log("space");
            DATA.FOODDELETES = false;            
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
            DATA.SpeedTraitCounter.Clear();
            DATA.SightTraitCounter.Clear();
            DATA.SizeTraitCounter.Clear();

            DATA.EVOLUTTIONCOUNTER_Length = 0;
            
        }

        Text.text = "E-Stage: " + DATA.E_Stage;
        Speed.text = "Average_Speed= " + AverageSpeedList;
        Sight.text = "Average_Sight= " + AverageSightList;
        Size.text = "Average_Size= " + AverageSizeList;
    }


    void DATALOOP() { 
        StartCoroutine(DATALOOPTIMED());
    }

    public IEnumerator DATALOOPTIMED() {
        yield return new WaitForSeconds(1f);

        AverageSpeedList = 0;
        for (var i = 0; i < DATA.EVOLUTTIONCOUNTER_Length; i++) {
            AverageSpeedList += DATA.SpeedTraitCounter[i];
        }
        AverageSpeedList = AverageSpeedList / DATA.EVOLUTTIONCOUNTER_Length;


        AverageSightList = 0;
        for (var f = 0; f < DATA.EVOLUTTIONCOUNTER_Length; f++) {
            AverageSightList += DATA.SightTraitCounter[f];
        }
        AverageSightList = AverageSightList / DATA.EVOLUTTIONCOUNTER_Length;


        AverageSizeList = 0;
        for (var u = 0; u < DATA.EVOLUTTIONCOUNTER_Length; u++) {
            AverageSizeList += DATA.SizeTraitCounter[u];
        }
        AverageSizeList = AverageSizeList / DATA.EVOLUTTIONCOUNTER_Length;
        
        DATALOOP();
    }
}
    
