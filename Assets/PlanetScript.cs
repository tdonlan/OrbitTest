using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetScript : MonoBehaviour {

    List<Rigidbody2D> rigidBodyList;
    Rigidbody2D planetRigidBody;

    //private double G = 6.67 * (Mathf.Pow(10,-11));
    private double G = .05;
    

	// Use this for initialization
	void Start () {
        init();
	}

    private void init()
    {
        this.planetRigidBody = gameObject.GetComponent<Rigidbody2D>();
        var rbArray = GameObject.FindObjectsOfType<Rigidbody2D>();
        rigidBodyList = new List<Rigidbody2D>(rbArray);
        rigidBodyList.Remove(planetRigidBody);

    }

	
	// Update is called once per frame
	void Update () {
        UpdateGravity();
	}



    //send out gravity force to everything in vicinity
    private void UpdateGravity()
    {
        foreach (var body in rigidBodyList)
        {
            Vector2 direction = this.planetRigidBody.position - body.position;
            direction.Normalize();
            float gravityForce = getGravityForce(planetRigidBody, body);
            direction = new Vector2(direction.x * gravityForce, direction.y * gravityForce);

            body.AddForce(direction);
            Debug.Log(string.Format("{0}, {1}", direction.x, direction.y));
        }

    }

    private float getGravityForce(Rigidbody2D body1, Rigidbody2D body2)
    {
        var dist = Vector2.Distance(body1.position, body2.position);
        double force = G * ((body1.mass * body2.mass) / (dist * dist));
        return (float)force;
    }
}
