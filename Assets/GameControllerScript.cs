using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

    public Rigidbody2D moonRigidBody;
    private float keyForce = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateControl();
	}

    private void UpdateControl()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moonRigidBody.AddForce(new Vector2(-keyForce, 0));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moonRigidBody.AddForce(new Vector2(keyForce, 0));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moonRigidBody.AddForce(new Vector2(0, -keyForce));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moonRigidBody.AddForce(new Vector2(0, keyForce));
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            Camera.main.orthographicSize++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
        {
            Camera.main.orthographicSize--;
        }
    }
}
