using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine.UI;

public class PerformanceView : MonoBehaviour
{
	/// <summary>
	/// PerformanceViewのインスタンス
	/// </summary>
	public static PerformanceView instance = null;

	public UIMovement correctMovement;
	public UIMovement incorrectMovement;

	public GameObject descriptionObject;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		descriptionObject.SetActive(false);
	}

	private async UniTask OpenDescription()
	{
		descriptionObject.SetActive(true);
		await UniTask.Delay(TimeSpan.FromSeconds(1));
		descriptionObject.SetActive(false);
	}

	/// <summary>
	/// 正解時の演出
	/// </summary>
	public async UniTask CorrectPerformance()
	{
		await correctMovement.Perform();
		await OpenDescription();
		correctMovement.HidePerform();
	}

	/// <summary>
	/// 不正解時の演出
	/// </summary>
	public async UniTask IncorrectPerformance()
	{
		await incorrectMovement.Perform();
		await OpenDescription();
		incorrectMovement.HidePerform();
	}
}