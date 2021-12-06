using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    private StateMachine brain;
    private Animator animator;
    [SerializeField]
    private Text stateNote;
    private NavMeshAgent agent;
    private Player player;
    private bool playerIsNear;
    private bool withinAttackRange;
    private float changeMind;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        agent = GetComponent<NavMeshAgent>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        brain = GetComponent<StateMachine>();
        playerIsNear = false;
        withinAttackRange = false;
        brain.PushState(Idle, OnIdleEnter, OnIdleEnter);
    }

    // Update is called once per frame
    void Update()
    {
        playerIsNear = Vector3.Distance(transform.position, player.transform.position) < 5;
        withinAttackRange = Vector3.Distance(transform.position, player.transform.position) < 1;
    }

    void OnIdleEnter()
    {
        agent.ResetPath();
    }
    void Idle()
    {
        stateNote.text = "Idle";
        if(changeMind <= 0)
        {
            brain.PushState(Wander, OnWanderEnter, OnWanderExit);
            changeMind = Random.Range(4, 10);
        }
        changeMind -= Time.deltaTime;
    }
    void OnIdleExit()
    {

    }

    void OnWanderEnter()
    {
        stateNote.text = "Wander";
        animator.SetBool("Chase", true);
        Vector3 wanderDirection = (Random.insideUnitSphere * 4f) + transform.position;
        NavMeshHit navMeshHit;
        NavMesh.SamplePosition(wanderDirection, out navMeshHit, 3f, NavMesh.AllAreas);
        Vector3 destination = navMeshHit.position;
        agent.SetDestination(destination);
    }
    void Wander()
    {
        stateNote.text = "Wander";
        if (agent.remainingDistance <= .25f)
        {
            agent.ResetPath();
            brain.PushState(Idle, OnIdleEnter, OnIdleExit);
        }
    }
    void OnWanderExit()
    {
        animator.SetBool("Chase", false);
    }
}
