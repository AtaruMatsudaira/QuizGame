using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizData",menuName = "Quiz/QuizData")]
public class QuizData : ScriptableObject
{
    [TextArea] public string question;
    public string[] choices;
    public int answerIndex;
}
