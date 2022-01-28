using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData",menuName = "Quiz/QuestionData")]
public class QuestionData : ScriptableObject
{
    [Multiline] public string question;
    public string[] choices;
    public int answerIndex;
}
