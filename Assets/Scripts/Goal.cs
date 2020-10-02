using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float sideSpeed = 1f;
    public float vertSpeed = 1f;
    public float leftEdge = 10f;
    public float rightEdge = 10f;
    public float topEdge = 10f;
    public float bottomEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public bool scored = false;

    static public bool goalMet = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile" && scored == false)
        {
            Goal.goalMet = true;
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
            scored = true;
            Basketball.GoalHit();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += vertSpeed * Time.deltaTime;
        transform.position = pos;

        pos.y += vertSpeed * Time.deltaTime;

        if (pos.y < bottomEdge)
        {
            vertSpeed = Mathf.Abs(vertSpeed);
        }
        else if (pos.y > topEdge)
        {
            vertSpeed = -Mathf.Abs(vertSpeed);
        }

        pos.x += sideSpeed * Time.deltaTime;
        transform.position = pos;

        pos.x += sideSpeed * Time.deltaTime;

        if (pos.x < leftEdge)
        {
            sideSpeed = Mathf.Abs(sideSpeed);
        }
        else if (pos.x > rightEdge)
        {
            sideSpeed = -Mathf.Abs(sideSpeed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            sideSpeed *= -1;
            vertSpeed *= -1;
        }
    }

   
    /*void OnCollisionEnter(Collision coll)
    {
        GameObject collodedWith = coll.gameObject;
        if (collodedWith.tag == "Apple")
        {
            Destroy(collodedWith);
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
    */
}
