using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float vertSpeed = 1f;
    public float topEdge = 10f;
    public float bottomEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    // Start is called before the first frame update
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
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            vertSpeed *= -1;
        }
    }
}
