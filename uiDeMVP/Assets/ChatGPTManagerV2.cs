using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI; // Ensure this is the correct namespace for your OpenAI SDK
using UnityEngine.Events;

public class ChatGPTManagerV2 : MonoBehaviour
{
    public OnResponseEvent OnResponse;

    [System.Serializable]
    public class OnResponseEvent : UnityEvent<string> { }

    // Add fields for API key and organization ID
    public string apiKey = "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";
    public string organizationId = "org-VNpPDt9To2GLDK0eQihrE7yd"; // use organization ID

    private OpenAIApi openAI;
    private List<ChatMessage> messages = new List<ChatMessage>();

    void Awake()
    {
        // Initialize OpenAIApi with the API key and organization ID
        openAI = new OpenAIApi(apiKey, organizationId);
    }

    public async void AskChatGPT(string newText)
    {
        ChatMessage newMessage = new ChatMessage
        {
            Content = newText,
            Role = "user"
        };

        messages.Add(newMessage);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest
        {
            Messages = messages,
            Model = "gpt-3.5-turbo"
        };

        try
        {
            var response = await openAI.CreateChatCompletion(request);

            if (response.Choices != null && response.Choices.Count > 0)
            {
                var chatResponse = response.Choices[0].Message;
                messages.Add(chatResponse);

                Debug.Log("Chat dijo lo siguiente -> " + chatResponse.Content);

                OnResponse.Invoke(chatResponse.Content);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Exception: {e.Message}");
            // Optionally, you can log the stack trace or any additional info
            Debug.LogError(e.StackTrace);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
