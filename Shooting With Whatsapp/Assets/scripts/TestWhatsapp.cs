using UnityEngine;
using System.Collections;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class TestWhatsAppBusiness : MonoBehaviour
{  
    private const string BASE_URL = "https://graph.facebook.com/v13.0/133215546547331/messages";
    
    private string _phoneId = "133215546547331";
    private string _accessToken = "EAADLCqpL3ocBO5VrtkDqbBfZCoBqK1UhunJf7YSHNVJMZCnwAsa8fz6wzx2cCwhmazshsh3m2hoZCqiZA8Jhuv6X8TEhmZBbWLz1K66H03SRZBYZBN6J3H5Xmm8ZA0YcYYjV9wdPmmocCzWutW4ZACHNsgmSAqR8NaUSyUjDG2PAE1Ux07W9FKgCZALj1IIZAMQBu8U";

    public string PhoneId
    {
        get { return _phoneId; }
        set { _phoneId = value; }
    }

    public string AccessToken
    {
        get { return _accessToken; }
        set { _accessToken = value; }
    }

    public void SendMessageToWp()
    {
        //Debug.Log("In Send To Message");
        SendMessageAsync("919373076931", "hi", _phoneId, _accessToken);
       // Debug.Log("Exit");
    }

    public static async Task SendMessageAsync(string to, string message, string phoneId, string accessToken)
    {
       // Debug.Log("Started Message");
        // Check if the phone ID and access token have been set.
        if (string.IsNullOrEmpty(phoneId) || string.IsNullOrEmpty(accessToken))
        {
            throw new System.Exception("The WhatsApp Business phone ID and access token must be set before calling the SendMessage() method.");
        }

        // Create a new HTTP client.
        HttpClient client = new HttpClient();
      //  Debug.Log("Created Http");
        // The CertificateValidationMode property is not available in Unity versions before 2021.2.0,
        // so we need to use the following workaround:
        System.Net.ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
      //  Debug.Log("Service Point");
        // Create a new HTTP request.
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, BASE_URL);
      //  Debug.Log("Sending Request");
        // Add the access token to the request header.
        request.Headers.Add("Authorization", $"Bearer {accessToken}");
     //   Debug.Log("Authorization");
        // Create the request body.
        string body = $"{{\"recipient\": {{\"phone_number\": \"{to}\"}}, \"message\": {{\"text\": \"{message}\"}}}}";
       // Debug.Log("Message Body");
        // Add the request body to the request.
        request.Content = new StringContent(body, Encoding.UTF8, "application/json");

        // Send the request and get the response.
        HttpResponseMessage response = await client.SendAsync(request);

        // Check the response status code.
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            // The message was sent successfully.
            Debug.Log("Message sent successfully!");
        }
        else
        {
            // An error occurred while sending the message.
            Debug.LogError($"Error sending message: {response.StatusCode}");
            Debug.Log("Error Hi Error Hai Bhai");
        }

       
    }
}
