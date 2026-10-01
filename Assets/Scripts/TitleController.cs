using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// スペースキーで開始
		if (Keyboard.current.spaceKey.isPressed)
		{
			SceneManager.LoadScene("GameScene");
		}
	}
}
