using UnityEngine;
using DG.Tweening;
using System;
using Cysharp.Threading.Tasks;

[Serializable]
public class UIMovement 
{
	public Transform target;
	public Vector3 endPosition;
	public float moveTime;
	public Ease ease;
	private Vector3 startPos;

	/// <summary>
	/// endPositionまでtarget移動させる
	/// </summary>
	public async UniTask Perform()
	{
		target.gameObject.SetActive(true);
		startPos = target.position;
		await target.DOLocalMove(endPosition, moveTime).SetEase(ease).ToUniTask();
	}

	public void HidePerform()
	{
		target.position = startPos;
		target.gameObject.SetActive(false);
	}
}