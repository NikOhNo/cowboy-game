using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typewriter : MonoBehaviour
{
    public bool IsTyping { get; private set; } = false;
    public string TypingMessage { get; private set; } = string.Empty;

    TypewriterConfig config;
    Coroutine typingCoroutine = null;

    public void SetConfig(TypewriterConfig config)
    { 
        this.config = config;
    }

    public void BeginTypewriter(string message)
    {
        TypingMessage = message;
        typingCoroutine = StartCoroutine(TypewriteMessage(message));
    }

    IEnumerator TypewriteMessage(string message)
    {
        IsTyping = true;

        char[] characters = message.ToCharArray();
        string typedMessage = string.Empty;

        for (int i = 0; i < characters.Length; i++)
        {
            typedMessage += characters[i];
            config.display.SetText(typedMessage);

            if (char.IsLetterOrDigit(characters[i]))
            {
                config.display.PlayAudio(config.speaker.Voice);
            }
            
            if (characters[i] == ',')
            {
                yield return new WaitForSeconds(config.commaTime);
            }
            else if (char.IsPunctuation(characters[i]) && characters[i] != '\'' && characters[i] != '\"')
            {
                yield return new WaitForSeconds(config.punctuationTime);
            }
            else
            {
                yield return new WaitForSeconds(config.typeTime);
            }

        }

        IsTyping = false;
    }

    public void SkipTypewriter()
    {
        if (IsTyping && typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            config.display.SetText(TypingMessage);
            IsTyping = false;
        }
    }
}
