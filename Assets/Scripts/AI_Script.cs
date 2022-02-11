using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class AI_Script : MonoBehaviour {
    
    public static bool PLAYER_DETECTED = false;
    public LayerMask targetMask;

    NavMeshAgent agent;

    bool foodTarget = false;
    bool firstWander = true;
    bool HIP = false;
    bool GoHomeTriggered = false;

    float radius = 3;
    int MTar = 0;

    int FOODSTATUS = 0;
 

    Vector3 myVector;
    Vector3 theVector;
    Vector3 targetVector;
    Vector3 GoHomeVector;



    void Start() {
        agent = this.GetComponent<NavMeshAgent>();

        var AgentRenderer = this.GetComponent<Renderer>();

    }

    void Update() {
        
        if(DATA.Stage_Start == true && HIP == false && GoHomeTriggered == false) {
            FindNearestFood();
            
            if(foodTarget == true) {
                //Debug.Log("PLAYER_DETECTED");
                Predator();
                foodTarget = false;
                

            } else {
                Wander();
                F1Wander();
                
            }
        }
    }

    void FindNearestFood() {
        Collider[] FoodCheck = Physics.OverlapSphere(this.gameObject.transform.position, radius, targetMask);

        if (FoodCheck.Length != 0) {
            foodTarget = true;

        }
    }

  
 
    void Wander() {
        
        if (agent.pathStatus==NavMeshPathStatus.PathComplete && agent.remainingDistance <= 0.1){
            //Debug.Log("more shit happening");
            myVector = this.gameObject.transform.position;
            theVector = new Vector3(myVector.x + Random.Range(-7,7), myVector.y, myVector.z + Random.Range(-7,7));
            for(var i = 0; i < 10;i++ ) {
                if(theVector.x >= 40 || theVector.x >= -40 || theVector.z >= 40 || theVector.z >= -40 ) {
                    theVector = new Vector3(myVector.x + Random.Range(-7,7), myVector.y, myVector.z + Random.Range(-7,7));
                } else {
                    break;
                }
            }
            agent.SetDestination(theVector);
        }
    }

    void F1Wander() {

        if(firstWander == true) {
            //Debug.Log("shit happening");
            myVector = this.gameObject.transform.position;
            theVector = new Vector3(myVector.x + Random.Range(-7,7), myVector.y, myVector.z + Random.Range(-7,7));
            for(var i = 0; i < 10; i++ ) {
                if(theVector.x >= 40 || theVector.x >= -40 || theVector.z >= 40 || theVector.z >= -40 ) {
                   theVector = new Vector3(myVector.x + Random.Range(-7,7), myVector.y, myVector.z + Random.Range(-7,7));
                } else {
                    break;
                }
            }
            agent.SetDestination(theVector);
            firstWander = false;
        }
    }

    void Predator() {
        
        Collider[] FoodCheck = Physics.OverlapSphere(this.gameObject.transform.position, radius, targetMask);

        foreach (Collider item in FoodCheck) {
            if(item.gameObject.CompareTag("FOOD")) {
                //Debug.Log("food is sensed");
                
                agent.SetDestination(item.gameObject.transform.position);
                HIP = true;

                
            }
        }
    }

    void Gohome() {

        if(Mathf.Abs(this.gameObject.transform.position.x) > Mathf.Abs(this.gameObject.transform.position.z)) {
            if(Mathf.Abs(this.gameObject.transform.position.x) > 0 ) {
                GoHomeVector = new Vector3(39, 2, Random.Range(-39,39));

                agent.SetDestination(GoHomeVector);
            }

            if(Mathf.Abs(this.gameObject.transform.position.x) < 0 ) {
                GoHomeVector = new Vector3(-39, 2, Random.Range(-39,39));

                agent.SetDestination(GoHomeVector); 
            }
        }

        if(Mathf.Abs(this.gameObject.transform.position.x) < Mathf.Abs(this.gameObject.transform.position.z)) {
            if(Mathf.Abs(this.gameObject.transform.position.z) > 0 ) {
                GoHomeVector = new Vector3(Random.Range(-39,39), 2, 39);

                agent.SetDestination(GoHomeVector);
            }

            if(Mathf.Abs(this.gameObject.transform.position.z) < 0 ) {
                GoHomeVector = new Vector3(Random.Range(-39,39), 2, -39);

                agent.SetDestination(GoHomeVector);
            }
        }

        GoHomeTriggered = true;
        Debug.Log("going home");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("FOOD")) {
            Destroy(other.gameObject);
            FOODSTATUS++;
            HIP = false;
            
        }

        if(FOODSTATUS == 1) {
            
            //this.GetComponent<Renderer>().material.color = (Color.yellow);
        }

        if(FOODSTATUS >= 2) {
            
            this.GetComponent<Renderer>().material.color = (Color.green);
            Gohome();
        }
    }
}