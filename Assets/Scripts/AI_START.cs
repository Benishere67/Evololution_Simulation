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


    float xBase1 = 39;
    float yBase1 = 2;
    float zBase1 = 39;
    
    float xBase2 = -39;
    float yBase2 = 2;
    float zBase2 = 39;

    float xBase3 = 39;
    float yBase3 = 2;
    float zBase3 = 39;

    float xBase4 = 39;
    float yBase4 = 2;
    float zBase4 = -39;


    

    void Start() {
        
    }
    
    void Update() {
        if (DATA.PUBLIC_START == true) {
            if (DATA.Ai_START_Status == false) {
            
                for(int i = 1; i <= 10; i++) {
                    Transform Creature = Instantiate(Creature_Prefab);
                    Creature.localScale = new Vector3(1, 1, 1);
                    Creature.SetParent(transform, false);
                    Creature.position = new Vector3(xBase1, yBase1, zBase1);

                    zBase1-= 8;
                    Counter++;
                }

                for(int i = 1; i <= 10; i++) {
                    Transform Creature = Instantiate(Creature_Prefab);
                    Creature.localScale = new Vector3(1, 1, 1);
                    Creature.SetParent(transform, false);
                    Creature.position = new Vector3(xBase2, yBase2, zBase2);

                    zBase2-= 8;
                    Counter++;
                }

                for(int i = 1; i <= 10; i++) {
                    Transform Creature = Instantiate(Creature_Prefab);
                    Creature.localScale = new Vector3(1, 1, 1);
                    Creature.SetParent(transform, false);
                    Creature.position = new Vector3(xBase3, yBase3, zBase3);

                    xBase3-= 8;
                    Counter++;
                }

                for(int i = 1; i <= 11; i++) {
                    Transform Creature = Instantiate(Creature_Prefab);
                    Creature.localScale = new Vector3(1, 1, 1);
                    Creature.SetParent(transform, false);
                    Creature.position = new Vector3(xBase4, yBase4, zBase4);

                    xBase4-= 8;
                    Counter++;
                }

                DATA.Ai_START_Status = true;
            }       



        } else {}
    }
}
