using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_START : MonoBehaviour {



     [SerializeField]
	Transform Creature_Prefab;

    NavMeshAgent agent;

    Transform[] CreatureArrayL;

    private int Counter = 0;


    float xBase = -38;
    float yBase = -36;
    float zBase = 2;

    void Start() {
        DATA.CreatureArray = new Transform[10];
    }
    
    void Update() {
        if (DATA.PUBLIC_START == true) {
            if (DATA.Ai_START_Status == false) {
            
                for(int i = 1; i <= 10; i++) {


                    Transform Creature = Instantiate(Creature_Prefab);
                    Creature.localScale = new Vector3(1, 1, 1);
                    Creature.SetParent(transform, false);
                    Creature.position = new Vector3(xBase, zBase, yBase);
                    DATA.CreatureArray[Counter] = Creature;

                    yBase+= 8;
                    Counter++;
                    //Debug.Log(i);
                }

                DATA.Ai_START_Status = true;
            }       



        } else {}
    }
}
