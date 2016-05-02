using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

    public GameObject[] vehiclePrefab;
    public float heightOffset = 1f;
    public float positionOffset = -10f;
    public float speed = 5.0f;
    public float moveDistance = 50.0f;
    public float maxRandomTime = 10.0f;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("Spawn");

    }

    IEnumerator Spawn()
    {
        while(true)
        {
            WaitForSeconds randomWaitTime = new WaitForSeconds(Random.Range(0.5f, maxRandomTime));
            yield return randomWaitTime;

            int vehicleRandomIndex = Random.Range(0, vehiclePrefab.Length);
            InstantiateVehicle(vehicleRandomIndex);
        }
    }

    private void InstantiateVehicle(int vehicleIndex)
    {
        Vector3 vehiclePos = GetVehiclePosOffset();
        GameObject vehicleObject = Instantiate(vehiclePrefab[vehicleIndex]);
        vehicleObject.transform.position = vehiclePos;
        vehicleObject.transform.parent = transform;

        VehicleMovement vehicleComp = vehicleObject.GetComponent<VehicleMovement>();
        vehicleComp.SetPath(speed, moveDistance);
    }

    private Vector3 GetVehiclePosOffset()
    {
        Vector3 vehiclePos = transform.position;
        vehiclePos += heightOffset * Vector3.up;
        vehiclePos += positionOffset * Vector3.right;
        return vehiclePos;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
