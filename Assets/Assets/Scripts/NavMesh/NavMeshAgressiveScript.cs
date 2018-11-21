using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgressiveScript : MonoBehaviour {

    NavMeshAgent agent;
    public int currentWP = 0;
    public bool playerInSight = false;
    Vector3 destination;
    List<Transform> newList = new List<Transform>();

    void Start()
    {
        foreach (Transform t in transform.root.GetComponentsInChildren<Transform>())
        {
            if (t.name.Contains("PatrolPoint"))
            {
                newList.Add(t);
            }
        }
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (playerInSight)
        {
            destination = GameObject.FindWithTag("Player").transform.position;
        }
        if (Vector3.Distance(newList[currentWP].transform.position, this.transform.position) < 1)
        {
            currentWP++;
            if (currentWP >= newList.Count)
            {
                currentWP = 0;
            }
            destination = newList[currentWP].transform.position;
        }

        if (!playerInSight)
        {
            destination = newList[currentWP].transform.position;
        }

        agent.SetDestination(destination);
    }
}
