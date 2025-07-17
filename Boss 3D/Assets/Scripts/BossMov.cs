using UnityEngine;
using UnityEngine.AI;

public class BossMov : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform[] movePoints;
    [SerializeField][Min(1f)] float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(movePoints[Random.Range(0, movePoints.Length)].position * moveSpeed);
    }
}
