using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOOD_SCRIPT : MonoBehaviour {


    [SerializeField]
	Transform FOODPrefab;

    private int foodCounter = 0;

    float xRandom = 0;
    float yRandom = 0;

    void Start() {
        
        DATA.FOODCELLS = new Transform[100];
        
    }


    void Update() {
        if (DATA.PUBLIC_START == true) {
            if (DATA.FoodDeployStatus == false) {
                
                    
                for(int i = 1; i <= 100; i++) {
                    xRandom = Random.Range(-34,34);
                    yRandom = Random.Range(-34,34);


                    Transform FOOD = Instantiate(FOODPrefab);
                    FOOD.localScale = new Vector3(1, 1, 1);
                    FOOD.SetParent(transform, false);
                    FOOD.position = new Vector3(xRandom, 1, yRandom);
                    FOOD.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                    DATA.FOODCELLS[foodCounter] = FOOD;

                    foodCounter++;
                    //Debug.Log(i);

                }

                DATA.FoodDeployStatus = true;
                
                



            }
        } else {

        }
    }
}