using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Basketball : MonoBehaviour {
    static private Basketball S;

    [Header("Set in Inspector")]
    public Text uitShots;
    public Text uitGoals;
    public Text uitButton;
    public GameObject UIT_Text_Win;
    [Header("Set Dynamically")]
    public int shotsTaken;
    public int goalsLeft = 5;
    public string showing = "Show Slingshot";
    // Start is called before the first frame update
    void Start()
    {
        S = this;
        UIT_Text_Win.SetActive(false);
        SwitchView("Show Both");
    }

    void UpdateGUI()
    {
        uitShots.text = "Shots Taken: " + shotsTaken;
        uitGoals.text = "Goals left: " + goalsLeft;
        if(goalsLeft <= 0)
        {
            UIT_Text_Win.SetActive(true);
        }
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

    public void SwitchView(string eView = "")
    {
        if (eView == "")
        {
            eView = uitButton.text;
        }
        showing = eView;
        switch (showing)
        {
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButton.text = "Show Both";
                break;

            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;
        }
    }
}
