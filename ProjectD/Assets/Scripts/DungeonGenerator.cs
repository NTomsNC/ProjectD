using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
	[SerializeField] private Vector2 dungeonSize;
	[SerializeField] private Vector2 tileSize;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	// OnDrawGizmos is called once per frame
	private void OnDrawGizmos()
	{
		for (int y = 0; y < dungeonSize.y; y++) {
			for (int x = 0; x < dungeonSize.x; x++)
			{
				DrawTile(x, y);
			}
		}
	}

	// Draw a tile based on the coordinates of the map
	private void DrawTile(int x, int y)
	{
		Vector3 size = new Vector3(tileSize.x, 0, tileSize.y);

		float xPos = transform.position.x + (tileSize.x * x) + tileSize.x / 2;
		float yPos = transform.position.y + (tileSize.y * y) + tileSize.y / 2;

		xPos -= (tileSize.x * dungeonSize.x) / 2;
		yPos -= (tileSize.y * dungeonSize.y) / 2;

		Gizmos.DrawWireCube(new Vector3(xPos, 0, yPos), size);
	}
}
