using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class QuizGame : MonoBehaviour
{
    public Text questionText;
    public List<Button> buttonList;
    public List<QuestionData> questionDataList;
    private Text[] buttonTexts;
    private readonly string br = System.Environment.NewLine;

    void Start()
    {
        buttonTexts = new Text[buttonList.Count];
        for (int i = 0; i < buttonTexts.Length; i++)
        {
            buttonTexts[i] = buttonList[i].GetComponentInChildren<Text>();
        }

        GameStart();
    }

    public void GameStart()
    {
        AskQuestion().Forget();
    }

    private async UniTask AskQuestion()
    {
        int correctCount = 0;
        Debug.Log($"問題を出題します!{br}問題数は全部で{questionDataList.Count}個あります!");
        for (int i = 0; i < questionDataList.Count; i++)
        {
            questionText.text = $"第{i + 1}問目！{br}{questionDataList[i].question}";
            int answer = await GetButtonInput(questionDataList[i].choices);
            if (answer == questionDataList[i].answerIndex)
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
            buttonTexts[i].text = choices[i];
            int index = i;
            buttonList[i].onClick.AddListener(() =>
            {
                clicked = true;
                answer = index;
            });
        }

        await UniTask.WaitWhile(() => clicked == false);
        buttonList.ForEach(button => button.onClick.RemoveAllListeners());
        return answer;
    }

    private async UniTask CorrectPerformance()
    {
        Debug.Log("正解です!");
    }

    private async UniTask IncorrectPerformance()
    {
        Debug.Log("不正解です...");
    }
}
