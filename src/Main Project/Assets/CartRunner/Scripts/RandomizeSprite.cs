using UnityEngine;

public class RandomizeSprite : MonoBehaviour
{
	public Sprite[] sprites;
	public bool rotate = true;
	public bool randomZ = true;
	
	void Start()
	{
		GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
		
		if (rotate)
			transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
		
		// transform.position.z += Random.Range(-0.5f, 0.5f);
		transform.position = new Vector3(
			transform.position.x,
			transform.position.y,
			transform.position.z + (randomZ ? Random.Range(0f, 0.5f) : (transform.position.y / -10f))
		);
	}
}