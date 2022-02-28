using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOOD_DELETE : MonoBehaviour {
    
    void Start() {
        EVOCHECK();
    }

    
    void FixedUpdate()
    {
        // if(DATA.Stage_End == true) {
        //     Destroy(gameObject);
        // }
    }

    void EVOCHECK() { 
        StartCoroutine(FOODTIMER());
    }

    public IEnumerator FOODTIMER() {
        yield return new WaitForSeconds(1f);

        if(DATA.Stage_End == true && DATA.FOODDELETES == true) {
            Destroy(gameObject);
        } else {
            EVOCHECK();
        }

    }




}
