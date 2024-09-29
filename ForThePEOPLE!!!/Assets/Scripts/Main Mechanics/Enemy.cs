using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////////////////
    // Agent
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundLayer, playerLayer;
    ////////////////////////////////////////////////////////////////////////////////////////
    // Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public bool Debuger;
    public bool InsideCam = false;
    public bool easterCam = false;
    ////////////////////////////////////////////////////////////////////////////////////////
    // State
    public float theSightRange;
    private float sightRange;
    public bool playerInSight;
    ////////////////////////////////////////////////////////////////////////////////////////
    // Animation
    public Animator animator;
    private bool IsOnChase = false;

    public PickItUp scoreManager;
    public PickItUpKeys keyManager;

    // Failsafe system
    private Vector3 lastPosition;
    private float stuckTimer = 0f;
    public float stuckTimeLimit = 2f; // Time limit before considering the enemy stuck

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        NormalSightRange();    
        lastPosition = transform.position;
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    void Update()
    {
        // Check if player is within sight range
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        if(Debuger == true)TestSubjest();//////////////////////////
        // Enemy behavior
        if (!playerInSight)Patrolling();
        
        if (playerInSight && InLineOfSight()) Chasing();

        ////////////////////////////////////////////////////////////////////////////////////////
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(InsideCam == true)
            {
                NormalSightRange();
            }
            else if(InsideCam == false)
            {
                IncreasedSightRange();
            }
        }

        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            if(easterCam == false)
            {
                IncreasedSightRange();
                easterCam = true;
                Debug.Log("EASTER ON");
            }
            else
            {
                NormalSightRange();
                easterCam = false;
                Debug.Log("EASTER CAM OFF");
            }
        }

        // Check if the enemy is stuck
        CheckIfStuck();
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint(); // Search if no walk point is set

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);

            IsOnChase = false;
            animator.SetBool("IsOnChase",IsOnChase);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            // If the enemy has reached the walk point
            if (distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
                stuckTimer = 0f;  // Reset stuck timer when reaching the walk point
            }
        }
    }

    private void SearchWalkPoint()
    {
        // Generate a random point within the walk point range
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Ensure that the walk point is on the ground
        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer))
        {
            walkPointSet = true;
            IsOnChase = false;
            animator.SetBool("IsOnChase",IsOnChase);
        }
    }

    private void Chasing()
    {
        // Set destination to player's position
        agent.SetDestination(player.position);
        transform.LookAt(player);
        IsOnChase = true;
        animator.SetBool("IsOnChase", IsOnChase);
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    private bool InLineOfSight()
    {
        RaycastHit hit;
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        if(Physics.Raycast(transform.position, directionToPlayer, out hit, sightRange))
        {
            if(hit.transform.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    void NormalSightRange()
    {
        InsideCam = false;
        sightRange = theSightRange;
    }

    void IncreasedSightRange()
    {
        InsideCam = true;
        sightRange = theSightRange * 2;
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.LogWarning("Skill Isuee");
            if(Debuger == false)
            {
                SceneManager.LoadScene("Gameplay");
            }
            scoreManager.Refresher();
            keyManager.Refresher();
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    void TestSubjest()
    {
        if (scoreManager == null)
        {
            scoreManager = GameObject.FindObjectOfType<PickItUp>(); // Find score manager dynamically
        }
    
        if (keyManager == null)
        {
            keyManager = GameObject.FindObjectOfType<PickItUpKeys>(); // Find key manager dynamically
        }

        if (scoreManager == null)
        {
            Debug.LogError("scoreManager is not assigned!");
        }

        if (keyManager == null)
        {
            Debug.LogError("keyManager is not assigned!");
        }   
    }

    // Failsafe to check if the enemy is stuck
    private void CheckIfStuck()
    {
        // Measure distance between the last position and current position
        if (Vector3.Distance(transform.position, lastPosition) < 0.1f)
        {
            // If the enemy hasn't moved for the duration of stuckTimeLimit, reset the walk point
            stuckTimer += Time.deltaTime;
            if (stuckTimer >= stuckTimeLimit)
            {
                walkPointSet = false; // Force a new walk point search
                stuckTimer = 0f;      // Reset stuck timer
                Debug.LogWarning("Enemy got stuck, changing walk point.");
            }
        }
        else
        {
            stuckTimer = 0f; // Reset the stuck timer if enemy is moving
        }

        lastPosition = transform.position;
    }
    ////////////////////////////////////////////////////////////////////////////////////////
}