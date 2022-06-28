using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start here");
        StartCoroutine(FollowPath()); // async.
        Debug.Log("Finishing start"); // executes before coroutine finishes.
    }

    IEnumerator FollowPath(){
        foreach(Waypoint waypoint in path){
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}
