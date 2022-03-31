using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DATA : MonoBehaviour {

    public static bool PUBLIC_START = false;
    public static bool FoodDeployStatus = false;
    public static bool Ai_START_Status = false;
    public static bool Stage_Start = false;
    public static bool Stage_End = false;
    public static bool AllFoodEaten = false;
    public static bool FOODDELETES = false;


    public static int E_Stage = 0;

    public static int FOODEATEN = 0;



    public static GameObject FOVPlayer;


    public static Transform[] FOODCELLS;
    public static Transform[] CreatureArray;


    public static List<float> SpeedTraitCounter = new List<float>();
    public static List<float> SightTraitCounter = new List<float>();
    public static List<float> SizeTraitCounter = new List<float>();

    public static int EVOLUTTIONCOUNTER_Length = 0;



    
}