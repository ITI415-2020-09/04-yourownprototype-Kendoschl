using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basketball : MonoBehaviour {
    static private Basketball S;
    
    [Header("Set in Inspector")]
    public Text uitShots;
    public Text uitGoals;
    [Header("Set Dynamically")]
    public int shotsTaken;
    public int goalsLeft = 5;
    // Start is called before the first frame update
    void Start()
    {
        S = this;
    }

    void UpdateGUI()
    {
        uitShots.text = "Shots Taken: " + shotsTaken;
        uitGoals.text = "Goals left: " + goalsLeft;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateGUI();
    }
    public static void ShotFired()
    {
        S.shotsTaken++;
    }

    public static void GoalHit()
    {
        S.goalsLeft--;
    }
}
