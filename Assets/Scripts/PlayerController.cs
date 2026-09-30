using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created

	Rigidbody2D rigid2D;
	float jumpForce = 400.0f;
	float runForce = 15.0f;
	float maxSpeed = 5f;
	[SerializeField] Sprite[] runSprites;
	[SerializeField] Sprite standSprite;
	[SerializeField] Sprite jumpSprite;
	float time = 0;
	int idx = 0;
	SpriteRenderer spriteRenderer;

    void Start()
    {
		rigid2D = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "mikaku")
		{
			Debug.Log("うめえ");
			Destroy(collision.gameObject);
		}
		if (collision.gameObject.tag == "imo")
		{
			Debug.Log("うめえ");
			Destroy(collision.gameObject);
		}
		if (collision.gameObject.tag == "akebi")
		{
			Debug.Log("うめえ");
			runForce += 5f;
			Destroy(collision.gameObject);
		}
		if (collision.gameObject.tag == "sanma")
		{
			Debug.Log("うめえ");
			jumpForce += 50f;
			Destroy(collision.gameObject);
		}
	}

	// Update is called once per frame
	void Update()
	{
		time += Time.deltaTime;

		//ジャンプ
		if (Keyboard.current.upArrowKey.wasPressedThisFrame && rigid2D.linearVelocityY == 0 || Keyboard.current.spaceKey.wasPressedThisFrame && rigid2D.linearVelocityY == 0)
		{
			rigid2D.AddForce(transform.up * jumpForce);
			spriteRenderer.sprite = jumpSprite; // アニメーション
		}

		//右に移動
		if (Keyboard.current.rightArrowKey.isPressed)
		{
			rigid2D.AddForce(transform.right * runForce);
			// アニメーション
			if (rigid2D.linearVelocityY == 0)
			{
				if (time > 0.1f)
				{
					GetComponent<SpriteRenderer>().flipX = false;
					time = 0;
					spriteRenderer.sprite = runSprites[idx];
					idx = 1 - idx;
				}
			}
		}
		//左に移動
		if (Keyboard.current.leftArrowKey.isPressed)
		{
			rigid2D.AddForce(Vector2.left * runForce);
			// アニメーション
			if (rigid2D.linearVelocityY == 0)
			{
				if (time > 0.1f)
				{
					GetComponent<SpriteRenderer>().flipX = true;
					time = 0;
					spriteRenderer.sprite = runSprites[idx];
					idx = 1 - idx;
				}
			}
		}
		// 最高速度を制限

		if (Mathf.Abs(rigid2D.linearVelocity.x) > maxSpeed)
		{
			rigid2D.linearVelocity = new Vector2(
				Mathf.Sign(rigid2D.linearVelocity.x) * maxSpeed,
				rigid2D.linearVelocity.y
			);
		}
		// 立ち
		if(rigid2D.linearVelocityX == 0)
		{
			spriteRenderer.sprite = standSprite;
		}
	}
}
