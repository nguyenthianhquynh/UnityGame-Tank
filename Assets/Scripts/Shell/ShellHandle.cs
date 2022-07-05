using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellHandle : MonoBehaviour
{
    public ParticleSystem m_ExplosionPartical;
    public AudioSource m_ExplosionAudio;
    // Start is called before the first frame update
    void Start()
    {
        //xoa shell da shoot trc do
        Destroy(gameObject, 2.0f);
    }


    private void OnTriggerEnter(Collider other)
    {
        ExplosionDamage(transform.position, 5.0f);

        m_ExplosionPartical.transform.parent = null;

        m_ExplosionPartical.Play();
        m_ExplosionAudio.Play();

        ParticleSystem.MainModule mainModule = m_ExplosionPartical.main;
        Destroy(m_ExplosionPartical.gameObject, mainModule.duration);

        // Destroy the shell.
        Destroy(gameObject);
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] getAllColliders = Physics.OverlapSphere(center, radius);

        foreach (var item in getAllColliders)
        {
            Debug.Log("bum bum");

        }
    }
}
