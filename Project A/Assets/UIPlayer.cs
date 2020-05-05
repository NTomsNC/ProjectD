using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
	[SerializeField] private Slider life;

	public void SetLife(float percent)
	{
		life.value = percent;
	}
}
