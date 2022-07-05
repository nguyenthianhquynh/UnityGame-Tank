using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody m_Shell;
    public Transform Target;
    NavMeshAgent navMeshAgent;
    TankShooting tankShooting;

    public AudioClip m_shootSound;
    public AudioSource audioSource;

    //de xac dinh huong ban khi rotation
    public Transform m_FireTransform;

    private float nextActionTime = 1.0f;
    public float period = 5.0f;
    float dist = 10f;

    //
    Vector3 targetDirection;
    float singleStep;
    Vector3 newDirection;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        tankShooting = new TankShooting();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.stoppingDistance = 10f;
        dist = Vector3.Distance(transform.position, Target.position);

        if (dist <= 15f)
        {
            //di chuyen tho
            navMeshAgent.SetDestination(Target.position);

            //xoay theo 
            targetDirection = Target.position - transform.position;
            singleStep = 0.5f * Time.deltaTime;
            newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        float angle = Vector3.Dot(targetDirection.normalized, newDirection.normalized);

        if (dist <= 10f
            && Time.time > nextActionTime
            && (angle <= 1f && angle >= 0.99f))
        {

            nextActionTime += period;
            Fire(m_Shell, m_FireTransform);

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(m_shootSound);
            }
        }

    }

    public void Fire(Rigidbody m_Shell, Transform m_FireTransform)
    {
        
        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody shellInstance =
            Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shellInstance.velocity = (dist+ 1.0f) * m_FireTransform.forward;

    }
}
