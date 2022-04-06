using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10;

    private Transform target;
    private int wayPointIndex = 0;

    public EnemyScript enemyScript;
    private void Start()
    {
        target = WayPoints.points[0];

        if (enemyScript == null)
            enemyScript = GetComponent<EnemyScript>();
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);

        if(Vector3.Distance(transform.position,target.position) <= .3f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if(wayPointIndex >= WayPoints.points.Length - 1)
        {
            Player.UpdateLives(enemyScript.livesTaken);
            Destroy(gameObject);
            return;
        }

        wayPointIndex++;

        target = WayPoints.points[wayPointIndex];
    }
}
