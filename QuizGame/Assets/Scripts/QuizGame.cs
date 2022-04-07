using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class QuizGame : MonoBehaviour
{
	public Text questionText;
	public List<CustomButton> buttonList;
	public List<QuizData> quizDataList;
	private readonly string br = System.Environment.NewLine;

	void Start()
	{
		GameStart();
	}

	public void GameStart()
	{
		AskQuestion().Forget();
	}

	private async UniTask AskQuestion()
	{
		int correctCount = 0;
		Debug.Log($"問題を出題します!{br}問題数は全部で{quizDataList.Count}個あります!");
		for (int i = 0; i < quizDataList.Count; i++)
		{
			questionText.text = $"第{i + 1}問目！{br}{quizDataList[i].question}";
			int answer = await GetButtonInput(quizDataList[i].choices);
			if (answer == quizDataList[i].answerIndex)
			{
				await CorrectPerformance();
				correctCount++;
			}
			else
			{
				await IncorrectPerformance();
			}
		}

		Debug.Log($"以上で問題は終わりです!{br}正解数は{correctCount}個でした!");
	}

	private async UniTask<int> GetButtonInput(string[] choices)
	{
		int answer = 0;
		bool clicked = false;
		for (int i = 0; i < choices.Length; i++)
		{
			buttonList[i].SetText(choices[i]);
			int index = i; //そのタイミングでの i の値を保持しておく変数を定義する
			buttonList[i].onClick.AddListener(() =>
			{
				clicked = true;
				answer = index; // index 自体は for ごとに定義されるため、問題ない
			});
		}

		await UniTask.WaitWhile(() => clicked == false);
		buttonList.ForEach(button => button.onClick.RemoveAllListeners());
		return answer;
	}

	private async UniTask CorrectPerformance()
	{
		await PerformanceView.instance.CorrectPerformance();
	}

	private async UniTask IncorrectPerformance()
	{
		await PerformanceView.instance.IncorrectPerformance();
	}
}