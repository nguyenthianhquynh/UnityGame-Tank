using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    private void OnCollisionEnter(Collision collision)
    {
        int nextRound = SceneManager.GetActiveScene().buildIndex + 1;
        if(collision.gameObject.tag == "tank1")
        {
            if (nextRound == SceneManager.sceneCountInBuildSettings)
            {
                nextRound = 0;
            }

            //Invoke("reloadRound", 1f);

            reloadRound(nextRound);
        }
    }

    private void reloadRound(int idxRound)
    {
        SceneManager.LoadScene(idxRound);
    }
}
