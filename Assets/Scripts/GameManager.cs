using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject scoreText;
	[SerializeField] GameObject AGIText;
	[SerializeField] GameObject JMPText;
	[SerializeField] GameObject timeText;
	[SerializeField] GameObject alive;
	[SerializeField] GameObject death;


	float time = 100;
	float resulutTimer = 4;
	float toTitle = 10;

	static int score = 0;
	int AGI = 1;
	int JMP = 1;
	static bool goalFlag = false;
	public void Score()
	{
		score += 100;

	}
	public void addAGI()
	{
		AGI++;
	}
	public void addJMP()
	{
		JMP++;
	}
	public void addTime()
	{
		time+=10;
	}
	public void goal()
	{
		goalFlag = true;
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		Application.targetFrameRate = 60;
	}

    // Update is called once per frame
    void Update()
    {
		time -= Time.deltaTime;


		timeText.GetComponent<TextMeshProUGUI>().text = "time "+ time.ToString();
		scoreText.GetComponent<TextMeshProUGUI>().text = "score "+ score.ToString();
		AGIText.GetComponent<TextMeshProUGUI>().text = "AGI "+ AGI.ToString();
		JMPText.GetComponent<TextMeshProUGUI>().text = "JMP "+ JMP.ToString();
		if(goalFlag == true)
		{
			Debug.Log("a");
			toTitle -= Time.deltaTime;
			resulutTimer -= Time.deltaTime;
			if (score < 1900)
			{ 
				if (resulutTimer < 0)
				{
					
					GameObject over = Instantiate(death);
					over.transform.position = Vector3.zero;
				}
			}
			else
			{
				if(resulutTimer < 0)
				{
					GameObject clear = Instantiate(alive);
					alive.transform.position = Vector3.zero;
				}
			}

			if(toTitle <= 0)
			{
				SceneManager.LoadScene("TitleScene");
			}
		}
	}
}
