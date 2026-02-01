using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;

public class MaskBehaviour : MonoBehaviour
{
	private MaskState state;
	private bool isDragging;

	[SerializeField] private Image _image;
	[SerializeField] private Sprite _defaultSprite;
	[SerializeField] private Dictionary<MaskState, Sprite> _sprites;

	private void Start()
	{
		_image.sprite = _defaultSprite;
	}

	public void SetSpriteToEmotion(MaskState state)
	{
		_image.sprite = _sprites[state];
	}

	public void ResetSprite()
	{
		_image.sprite = _defaultSprite;
	}
}