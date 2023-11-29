using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private int waypointindex = 0;
    private Transform target;

    private Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = WayPoint.points[0];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= 0.3f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.StartSpeed;
    }

    void GetNextWayPoint()
    {
        if (waypointindex >= WayPoint.points.Length - 1)
        {
            EndPath();
            return;
        }
        else
        {
            waypointindex++;
            target = WayPoint.points[waypointindex];
        }

    }

    void EndPath()
    {
        Destroy(gameObject);
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        return;
    }
}
