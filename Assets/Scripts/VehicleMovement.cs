using UnityEngine;
using System.Collections;

public class VehicleMovement : MonoBehaviour {

    private float vehicleSpeed = 5.0f;
    private float VehicleMoveDistance = 10.0f;

	// Use this for initialization
	void Start () {
        float lifeTime = VehicleMoveDistance / vehicleSpeed;
        Invoke("Remove", lifeTime);
	
	}

    void Remove()
    {
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * vehicleSpeed * Time.deltaTime;
	
	}

    public void SetPath(float someSpeed, float someMoveDistance)
    {
        vehicleSpeed = someSpeed;
        VehicleMoveDistance = someMoveDistance;
    }
}
