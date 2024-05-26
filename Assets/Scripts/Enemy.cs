using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private NavMeshAgent pathfinder;
    [SerializeField] private Transform target;
    [SerializeField] private float refreshRate = .25f;

    private void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
