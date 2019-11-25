using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameCamera : MonoBehaviour {

	private Vector3 cameraTarget;
    GameObject particle;

    private Transform target;
	// Use this for initialization
	void Start () {
        FindTarget();
	}
	
	// Update is called once per frame
	void Update () {
        if(target != null)
        {
            cameraTarget = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 8);
        }
        else
        {
            if (Input.GetButtonDown("Dead Screen"))
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                if (CrossPlatformInputManager.GetButtonDown("Shoot"))
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
        
    }

    public void FindTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
