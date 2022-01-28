public class Program
{
    public static void Main(string[] args)
    {
        var game = new QuizGame(new List<QuestionData>()
        {
            new QuestionData("y = sin(x) の最小値はいくつ?",new string[]{"-1","0","-π","1"},0),
            new QuestionData("この中で野菜として分類されるのはどれでしょう?" ,new string[]{"パイナップル","梨","桃","いちご"},3)
        });
        game.AskQuestion();
    }
}
public class QuestionData
{
    public string question;
    public string[] choices;
    public int answerIndex;
    public QuestionData(string question, string[] choices, int answerIndex)
    {
        this.question = question;
        this.choices = choices;
        this.answerIndex = answerIndex;
    }

}
public class QuizGame
{
    public List<QuestionData> questionDataList;
    public QuizGame(List<QuestionData> questionDataList) {
        this.questionDataList = questionDataList;
    }
    public void AskQuestion()
    {
        int correctCount = 0;
        string br = Environment.NewLine;
        Console.WriteLine($"問題を出題します!{br}問題数は全部で{questionDataList.Count}個あります!");
        for (int i = 0; i < questionDataList.Count; i++)
        {
            Console.WriteLine($"第{i + 1}問目！");
            Console.WriteLine(questionDataList[i].question);
            for (int j = 0; j < questionDataList[i].choices.Length; j++)
            {
                Console.WriteLine($"Q.{j} {questionDataList[i].choices[j]}");
            }
            Console.WriteLine("問題番号を入力してEnterキーを押してください!");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int answer))
            {
                if (answer == questionDataList[i].answerIndex)
                {
                    Console.WriteLine("正解です!!!");
                    correctCount++;
                }
                else
                {
                    Console.WriteLine("不正解です...");
                }
            }
            else
            {
                Console.WriteLine($"入力された値が不正です。{br}不正解となります...");
            }
        }
        Console.WriteLine($"以上で問題は終わりです!{br}正解数は{correctCount}個でした!");
    }
}
