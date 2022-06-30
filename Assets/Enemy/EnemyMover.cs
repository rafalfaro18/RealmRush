using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] //auto imports Enemy component when importing EnemyHealth comp.
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    List<Node> path = new List<Node>();

    Enemy enemy;
    GridManager gridManager;
    Pathfinder pathfinder;

    void Awake(){
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void OnEnable()
    {
        ReturnToStart();
        RecalculatePath(true);
    }

    void RecalculatePath(bool resetPath){
        Vector2Int coordinates = new Vector2Int();

        if(resetPath){
            coordinates = pathfinder.StartCoordinates;
        } else {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }

        StopAllCoroutines(); // stop the enemy from following the path while gets a new one.
        path.Clear();
        path = pathfinder.GetNewPath(coordinates);
        StartCoroutine(FollowPath()); // async.
    }

    void ReturnToStart(){
        transform.position = gridManager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        for (int i = 1; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            // LERP (Linear Interpolation).
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }

}
