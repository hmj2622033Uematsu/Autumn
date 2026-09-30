using UnityEngine;

public class CameraController : MonoBehaviour
{
	Vector3 prePlayerPos;
	[SerializeField] GameObject player;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (player.transform.position != prePlayerPos)
		{
			transform.position = new Vector3(player.transform.position.x + 2,  0, -10);
			prePlayerPos = player.transform.position;
		}
		// player.transform.position.y + 4, -10
	}
}
