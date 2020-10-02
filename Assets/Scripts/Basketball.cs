using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basketball : MonoBehaviour {
    static private Basketball S;
    
    [Header("Set in Inspector")]
    public Text uitShots;
    [Header("Set Dynamically")]
    public int shotsTaken;
    // Start is called before the first frame update
    void Start()
    {
        S = this;
    }

    void UpdateGUI()
    {
        uitShots.text = "Shots Taken: " + shotsTaken;
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
}
