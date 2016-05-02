using UnityEngine;
using System.Collections;

public class GameOverMessage : MonoBehaviour {
    public float UIDistance = 25.0f;
    public float UIHeight = 10.0f;

    private Player toadPlayer;
    private Canvas canvas;
    private GameState state;

	// Use this for initialization
	void Start () {
        toadPlayer = GameObject.FindObjectOfType<Player>();
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        state = GameObject.FindObjectOfType<GameState>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (state.isGameOver)
        {
            TrackPlayerhead();
            canvas.enabled = true;
        }
    }

    private void TrackPlayerhead()
    {
        transform.rotation = Quaternion.LookRotation(toadPlayer.LookDirection());
        transform.position = toadPlayer.transform.position;
        transform.position += toadPlayer.LookDirection() * UIDistance;
        transform.position += Vector3.up * UIHeight;
    }
}
