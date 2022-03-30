using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class AI_DupScript : MonoBehaviour {
    
    public LayerMask targetMask;

    NavMeshAgent agent;

    public GameObject myPrefab;

    bool foodTarget = false;
    bool firstWander = true;
    bool HIP = false;
    bool GoHomeTriggered = false;

    float radius = 3;
    float ENERGY = 70;

    int FOODSTATUS = 0;
    int FOODSTATUS_LCHECK = 0;
    int E_Stage_LOCAL = 1;


    //traits
    float SPEED_TRAIT;
    float SIGHT_TRAIT;
    float SIZE_TRAIT;




    Vector3 myVector;
    Vector3 theVector;
    Vector3 targetVector;
    Vector3 GoHomeVector;



    void Start() {
        agent = this.GetComponent<NavMeshAgent>();

        var AgentRenderer = this.GetComponent<Renderer>();

        this.GetComponent<Renderer>().material.color = (Color.black);
        agent.speed = 15 * SPEED_TRAIT;

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
                //Debug.Log(ENERGY);

                if(ENERGY <= 0) {
                    DEATH();
                }
            }
        }

        
        if (DATA.Stage_Start == false && DATA.Stage_End == true && GoHomeTriggered == false) {
            DEATH();
        }

        if(DATA.Stage_Start == true && GoHomeTriggered == true && DATA.E_Stage == E_Stage_LOCAL + 1) {
            RESET();
            
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
            for(var i = 0; i < 5000;i++ ) {
                if(theVector.x >= 37 || theVector.x >= -37 || theVector.z >= 37 || theVector.z >= -37 ) {
                    theVector = new Vector3(myVector.x + Random.Range(-7,7), myVector.y, myVector.z + Random.Range(-7,7));
                } else {
                    break;
                }
            }
            float dist = Vector3.Distance(myVector, theVector);
            ENERGY -= Mathf.Abs(dist);
            agent.SetDestination(theVector);
            //ENERGY--;
        }
    }

    void F1Wander() {

        if(firstWander == true) {
            //Debug.Log("shit happening");
            myVector = this.gameObject.transform.position;
            theVector = new Vector3(myVector.x + Random.Range(-7,7), myVector.y, myVector.z + Random.Range(-7,7));
            for(var i = 0; i < 5000; i++ ) {
                if(theVector.x >= 37 || theVector.x >= -37 || theVector.z >= 37 || theVector.z >= -37 ) {
                   theVector = new Vector3(myVector.x + Random.Range(-7,7), myVector.y, myVector.z + Random.Range(-7,7));
                } else {
                    break;
                }
            }

            float dist = Vector3.Distance(myVector, theVector);
            ENERGY -= dist;
            agent.SetDestination(theVector);
            firstWander = false;
            
            //ENERGY--;
        }
    }

    void Predator() {
        
        Collider[] FoodCheck = Physics.OverlapSphere(this.gameObject.transform.position, radius, targetMask);

        foreach (Collider item in FoodCheck) {
            if(item.gameObject.CompareTag("FOOD")) {
                //Debug.Log("food is sensed");
                
                agent.SetDestination(item.gameObject.transform.position);
                HIP = true;
                

                KILLCHECK();

                
            }
        }
    }

    void DEATH() {
        
        agent.ResetPath();
        agent.isStopped = true;
        this.GetComponent<Renderer>().material.color = (Color.red);
        
        StartCoroutine(KILLSCRIPT());
    }

    public IEnumerator KILLSCRIPT() {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }

    void KILLCHECK() { 
        StartCoroutine(CHECKSCRIPT());
    }

    public IEnumerator CHECKSCRIPT() {
        yield return new WaitForSeconds(4f);
        if(FOODSTATUS_LCHECK == FOODSTATUS) {
            HIP = false;
            Wander();
            F1Wander();
        }

    }

    void RESET() {




        GoHomeTriggered = false;
        ENERGY = 70;
        FOODSTATUS = 0;
        firstWander = true;
        E_Stage_LOCAL++;
        HIP = false;
        foodTarget = false;

        this.GetComponent<Renderer>().material.color = (Color.blue);

        GameObject child = GameObject.Instantiate(this.gameObject, transform.position, Quaternion.identity);
        child.GetComponent<AI_Script>().SPEED_TRAIT = this.GetComponent<AI_Script>().SPEED_TRAIT + Random.Range(-1, 1);
        child.GetComponent<AI_Script>().E_Stage_LOCAL = E_Stage_LOCAL;


        DATA.SpeedTraitCounter.Add(SPEED_TRAIT);
        DATA.SpeedTraitCounter.Add(SIGHT_TRAIT);
        DATA.SpeedTraitCounter.Add(SIZE_TRAIT);

        DATA.SpeedTraitCounter_Length++;

    }

    void Gohome() {

        if(Mathf.Abs(this.gameObject.transform.position.x) > Mathf.Abs(this.gameObject.transform.position.z)) {
            if(this.gameObject.transform.position.x > 0 ) {
                GoHomeVector = new Vector3(39, 2, this.gameObject.transform.position.z);

                agent.SetDestination(GoHomeVector);
            }

            if(this.gameObject.transform.position.x < 0 ) {
                GoHomeVector = new Vector3(-39, 2, this.gameObject.transform.position.z);

                agent.SetDestination(GoHomeVector); 
            }
        }

        if(Mathf.Abs(this.gameObject.transform.position.x) < Mathf.Abs(this.gameObject.transform.position.z)) {
            if(this.gameObject.transform.position.z > 0 ) {
                GoHomeVector = new Vector3(this.gameObject.transform.position.x, 2, 39);

                agent.SetDestination(GoHomeVector);
            }

            if(this.gameObject.transform.position.z < 0 ) {
                GoHomeVector = new Vector3(this.gameObject.transform.position.x, 2, -39);

                agent.SetDestination(GoHomeVector);
            }
        }

        GoHomeTriggered = true;
        //Debug.Log("going home");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("FOOD") && GoHomeTriggered == false) {
            Destroy(other.gameObject);
            FOODSTATUS++;
            HIP = false;
            
        }

        if(FOODSTATUS == 1) {
            
            this.GetComponent<Renderer>().material.color = (Color.yellow);
        }

        if(FOODSTATUS >= 2) {
            
            this.GetComponent<Renderer>().material.color = (Color.green);

            Gohome();
        }
    }
}