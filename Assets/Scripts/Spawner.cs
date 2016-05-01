using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] lanePrefabs;
    public float spawnHorizon = 500f;
    public float laneWidth = 2f;
    public GameObject player;
    public Transform spawnerParent;

    private float nextLaneOffset = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float playerForwardPos = player.transform.position.z;
        while (playerForwardPos + spawnHorizon > nextLaneOffset)
        {
            int randomLaneIndex = Random.Range(0, lanePrefabs.Length);
            GameObject laneItem = lanePrefabs[randomLaneIndex];
            Vector3 nextLanePos = nextLaneOffset * Vector3.forward;
            GameObject laneHolder = Instantiate(laneItem, nextLanePos, Quaternion.identity) as GameObject;
            laneHolder.transform.parent = spawnerParent;
            nextLaneOffset += laneWidth;
        }
    }
}
