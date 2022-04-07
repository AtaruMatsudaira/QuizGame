using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// カスタムされたボタン
/// </summary>
public class CustomButton : Button
{
    public Vector3 clickedPunchSize = Vector3.one * 0.1f;
    public float clickedPunchTime = 0.5f;
    public Vector3 pointerPunchSize = Vector3.one * 0.05f;
    public float pointerPunchTime = 0.1f;
    private Text buttonText;
    private Tweener punchTween = null;
    
    protected override void Start()
    {
        base.Start();
        buttonText = this.GetComponentInChildren<Text>();
    }
    
    /// <summary>
    /// ボタン内のテキストを設定するメソッド
    /// </summary>
    /// <param name="text">ボタンのテキストとなる文字列</param>
    public void SetText(string text)
    {
        buttonText.text = text;
    }
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        punchTween?.Complete();
        punchTween = transform.DOPunchScale(Vector3.one * 0.1f, 0.5f);
    }
    
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        punchTween?.Complete();
        punchTween = transform.DOPunchScale(Vector3.one * 0.05f, 0.1f);
    }

}