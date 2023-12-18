using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System;
using System.Collections;
using System.IO;
using System.Net.Http;
using System.Text;

public class NewwpScript : MonoBehaviour
{
    private const string BASE_URL = "https://graph.facebook.com/{Version}/{PhoneNumberID}/messages";

    private string _version = "v13.0";
    private string _phoneNumberID = "133215546547331";
    private string _accessToken = "EAADLCqpL3ocBO5VrtkDqbBfZCoBqK1UhunJf7YSHNVJMZCnwAsa8fz6wzx2cCwhmazshsh3m2hoZCqiZA8Jhuv6X8TEhmZBbWLz1K66H03SRZBYZBN6J3H5Xmm8ZA0YcYYjV9wdPmmocCzWutW4ZACHNsgmSAqR8NaUSyUjDG2PAE1Ux07W9FKgCZALj1IIZAMQBu8U";
    private string toNumber = "919373076931";
    public GameObject dialogBoxControllerGameObject;
    DialogBoxController dialogBoxController;
    private void Start()
    {
        dialogBoxController = dialogBoxControllerGameObject.GetComponent<DialogBoxController>();

    }
    public async void SendMessageToWp()
    {
        // Create a new HTTP client.
        HttpClient client = new HttpClient();

        // Create a new HTTP request.
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, BASE_URL.Replace("{Version}", _version).Replace("{PhoneNumberID}", _phoneNumberID));

        // Add the access token to the request header.
        request.Headers.Add("Authorization", $"Bearer {_accessToken}");

        // Create the request body in WhatsApp JSON format.
        string body = $"{{\"messaging_product\": \"whatsapp\",\"to\": \"{toNumber}\", \"type\": \"template\", \"template\": {{\n" +
     $"  \"name\": \"send_image\",\n" +
     $"  \"language\": {{\n" +
     $"    \"code\": \"en\"\n" +
     $"  }},\n" +
     $"  \"components\": [{{\n" +
     $"    \"type\": \"header\",\n" +
     $"    \"parameters\": [{{\n" +
     $"      \"type\": \"image\",\n" +
     $"      \"image\": {{\n" +
     $"        \"link\": \"https://cdn.akamai.steamstatic.com/steam/apps/2511130/capsule_616x353.jpg\"\n" +
     $"      }}\n" +
     $"    }}]\n" +
     $"  }}]\n" +
     $"}}\n}}";


        // Add the request body to the request.
        request.Content = new StringContent(body, Encoding.UTF8, "application/json");

        // Send the request and wait for the response.
        HttpResponseMessage response = await client.SendAsync(request);

        // Check the response status code and handle the response accordingly.
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            // The message was sent successfully.
            Debug.Log("Message sent successfully!");
            dialogBoxController.EnableSuccessText();
            dialogBoxController.EnableDialogBox();
        }
        else
        {
            // An error occurred while sending the message.
            Debug.Log($"Error sending message: {response.StatusCode}");
            Debug.Log("Error Message Not Sent");
            dialogBoxController.DisableSuccessText();
        }
    }
}

