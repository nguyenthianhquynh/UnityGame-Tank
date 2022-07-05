using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public Rigidbody m_Shell;

    public AudioClip m_shootSound;
    public AudioSource audioSource;

    //de xac dinh huong ban khi rotation
    public Transform m_FireTransform;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            // ... launch the shell.
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
        shellInstance.velocity = 12f * m_FireTransform.forward;

    }
}
