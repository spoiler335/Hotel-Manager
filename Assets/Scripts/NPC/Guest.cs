using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Guest : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    private Vector3 initialPos;
    private NPCState state;
    private bool isMoving = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 20f;
        initialPos = transform.position;
    }


    private void Start()
    {
        state = NPCState.Outside;
        StartCoroutine(WaitAndJoinQueue());
    }

    private IEnumerator WaitAndJoinQueue()
    {
        var delay = Random.Range(5, 15);
        Debug.Log($"{gameObject.name} is waiting for {delay} seconds");
        yield return new WaitForSeconds(delay);
        target = DI.di.queueManager.GetNextPoint();
        if (target != null)
        {
            Debug.Log($"{gameObject.name} got a target {target.transform.position}");
            agent.SetDestination(new Vector3(target.position.x, 0, target.position.z));
            isMoving = true;
            StartCoroutine(WaitUntilReachedQueue());
            yield break;
        }
        else
        {
            StartCoroutine(WaitAndJoinQueue());
            yield break;
        }
    }

    private IEnumerator WaitUntilReachedQueue()
    {
        while (agent.remainingDistance >= agent.stoppingDistance) yield return null;
        transform.rotation = Quaternion.Euler(transform.forward);
        isMoving = false;
    }
}

public enum NPCState
{
    Outside,
    INQueue,
    InRoom,
    Vacated
}