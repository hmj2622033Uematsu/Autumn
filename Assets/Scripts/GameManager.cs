using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	int time = 1000;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		Application.targetFrameRate = 60;
	}

    // Update is called once per frame
    void Update()
    {
		time--;
	}
}
