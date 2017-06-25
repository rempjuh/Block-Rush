using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {
	private int _score;
	[SerializeField]
	private Text _scoreText;

	private void Start()
	{

	}

	private void Update()
	{
		
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && hit.collider.GetComponent<Interactible>())
			{
				Interactible b = hit.collider.GetComponent<Interactible>();
				if (b.IsInBound() && b.GetValue() <= _score && b.IsUseble())
				{
					DegreesScore(b.GetValue());
					b.Interact();
				}
			}
		}
	}

	public void IncreaseScore(int value)
	{
		_score += value;
		SetText();
	}
	public void DegreesScore(int value)
	{
		_score -= value;
		SetText();
	}
	public void SetScore(int value)
	{
		_score = value;
		SetText();
	}
	public int GetScore(int value)
	{
		return _score;
	}
	private void SetText()
	{
		_scoreText.text = _score.ToString();
	}
}
