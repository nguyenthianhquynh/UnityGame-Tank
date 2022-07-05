using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    public float m_Speed = 12f;
    public Vector3 m_EulerAngleVelocity;

    ////dust
    public ParticleSystem dustLeft;
    public ParticleSystem dustRight;



    public int m_PlayerNumber = 1;
    private Rigidbody m_Rigidbody;

    private string m_MovementAxisName;          // The name of the input axis for moving forward and back.
    private string m_TurnAxisName;              // The name of the input axis for turning.

    private float m_MovementInputValue;         // The current value of the movement input.
    private float m_TurnInputValue;             // The current value of the turn input.


    private void Awake()
    {

        m_Rigidbody = GetComponent<Rigidbody>();
        m_EulerAngleVelocity =new Vector3(0, 100, 0);
    }

    //===========
    private void OnEnable()
    {
        Debug.Log("OnEnable");
        m_Rigidbody.isKinematic = false;

        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;

        dustLeft.Play();
        dustRight.Play();
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
        m_Rigidbody.isKinematic = true;

        dustLeft.Stop();
        dustRight.Stop();
    }

    //===========

    // Start is called before the first frame update
    void Start()
    {
        // The axes names are based on player number.
        m_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";
    }

    // Update is called once per frame
    void Update()
    {
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");
    }

    //This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        Vector3 vec3Move = m_Speed * Time.deltaTime * (m_MovementInputValue * transform.forward);
        m_Rigidbody.MovePosition(m_Rigidbody.position + vec3Move);

        Quaternion deltaRotate = Quaternion.Euler(m_EulerAngleVelocity * m_TurnInputValue * Time.fixedDeltaTime);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotate);


    }


}
