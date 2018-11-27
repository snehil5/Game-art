using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TypeTextComponent : MonoBehaviour
{
    public delegate void OnComplete();

    [SerializeField]
    private float defaultSpeed = 0.05f;

    private Text label;
    private string currentText;
    private string finalText;
    private Coroutine typeTextCoroutine;

    private OnComplete onCompleteCallback;

    private void Init()
    {
        if (label == null)
            label = GetComponent<Text>();
    }

    public void Awake()
    {
        Init();
    }

    public void SetText(string text, float speed = -1)
    {
        Init();

        defaultSpeed = speed > 0 ? speed : defaultSpeed;
        finalText = ReplaceSpeed(text);
        label.text = "";

        if (typeTextCoroutine != null)
        {
            StopCoroutine(typeTextCoroutine);
        }

        typeTextCoroutine = StartCoroutine(TypeText(text));
    }

    public void SkipTypeText()
    {
        if (typeTextCoroutine != null)
            StopCoroutine(typeTextCoroutine);
        typeTextCoroutine = null;

        label.text = finalText;

        if (onCompleteCallback != null)
            onCompleteCallback();
    }

    public IEnumerator TypeText(string text)
    {
        currentText = "";

        var len = text.Length;
        var speed = defaultSpeed;
        var tagOpened = false;
        var tagType = "";
        for (var i = 0; i < len; i++)
        {
            if (text[i] == '[' && i + 6 < len && text.Substring(i, 7).Equals("[speed="))
            {
                var parseSpeed = "";
                for (var j = i + 7; j < len; j++)
                {
                    if (text[j] == ']')
                        break;
                    parseSpeed += text[j];
                }

                if (!float.TryParse(parseSpeed, out speed))
                    speed = 0.05f;

                i += 8 + parseSpeed.Length - 1;
                continue;
            }

            currentText += text[i];
            label.text = currentText + (tagOpened? string.Format("</{0}>", tagType) : "");
            yield return new WaitForSeconds(speed);
        }

        typeTextCoroutine = null;

        if (onCompleteCallback != null)
            onCompleteCallback();
    }

    private string ReplaceSpeed(string text)
    {
        var result = "";
        var len = text.Length;
        for (var i = 0; i < len; i++)
        {
            if (text[i] == '[' && i + 6 < len && text.Substring(i, 7).Equals("[speed="))
            {
                var speedLength = 0;
                for (var j = i + 7; j < len; j++)
                {
                    if (text[j] == ']')
                        break;
                    speedLength++;
                }

                i += 8 + speedLength - 1;
                continue;
            }

            result += text[i];
        }

        return result;
    }

    public bool IsSkippable()
    {
        return typeTextCoroutine != null;
    }

    public void SetOnComplete(OnComplete onComplete)
    {
        onCompleteCallback = onComplete;
    }

}

public static class TypeTextComponentUtility
{

    public static void TypeText(this Text label, string text, float speed = 0.05f, TypeTextComponent.OnComplete onComplete = null)
    {
        var typeText = label.GetComponent<TypeTextComponent>();
        if (typeText == null)
        {
            typeText = label.gameObject.AddComponent<TypeTextComponent>();
        }

        typeText.SetText(text, speed);
        typeText.SetOnComplete(onComplete);
    }

    public static bool IsSkippable(this Text label)
    {
        var typeText = label.GetComponent<TypeTextComponent>();
        if (typeText == null)
        {
            typeText = label.gameObject.AddComponent<TypeTextComponent>();
        }

        return typeText.IsSkippable();
    }

    public static void SkipTypeText(this Text label)
    {
        var typeText = label.GetComponent<TypeTextComponent>();
        if (typeText == null)
        {
            typeText = label.gameObject.AddComponent<TypeTextComponent>();
        }

        typeText.SkipTypeText();
    }

}