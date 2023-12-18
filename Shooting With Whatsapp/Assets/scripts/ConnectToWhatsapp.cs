using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class WhatsAppImageSender : MonoBehaviour
{
 
    private static readonly string WhatsAppApiUrl = "https://graph.facebook.com/v13.0/136212489579772/messages";
    string orecipientPhoneNumber="919373076931";
    string imagePath= "https://cdn.britannica.com/26/84526-050-45452C37/Gateway-monument-India-entrance-Mumbai-Harbour-coast.jpg";
    string caption="Temp";
    
    public void SendImagec()
    {
        SendImage(orecipientPhoneNumber, imagePath, caption);
    }
    public void sphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(1, 1, 1);
        sphere.transform.localPosition = new Vector3(0,3, 2);
        sphere.AddComponent<Rigidbody>();

    }
    public void SendImage(string recipientPhoneNumber, string imagePath, string caption)
    {
       // sphere();
        // Read the image file as a byte array.
        byte[] imageBytes = File.ReadAllBytes(imagePath);

        // Convert the byte array to a base64 string.
        string base64Image = Convert.ToBase64String(imageBytes);

        // Create the WhatsApp message object.
        var message = new WhatsAppMessage
        {
            messaging_product = "whatsapp",
            recipient_type = "individual",
            to = recipientPhoneNumber,
            type = "image",
            image = new WhatImage
            {
                link = "https://i.imgur.com/uK4DPMy.jpg"
            }           
        };

        // Serialize the WhatsApp message object to JSON.
        string jsonMessage = JsonUtility.ToJson(message);
       
        // Create a UnityWebRequest object to send the POST request to the WhatsApp API.
        UnityWebRequest request = UnityWebRequest.PostWwwForm(WhatsAppApiUrl, jsonMessage);
        request.SetRequestHeader("Authorization", $"Bearer {"EAADLCqpL3ocBOzWAZB5qEVbDE3fxEooFiATDfB6gXzsk0mw4vkP8cYKvYJT3lfGZADawGLy6Njk6Fo3gUeGucEe9ENtZB3fVLduU7bs3pnDDsP2HalZCZCdeQHXNK9SH7a3PC3NCdudWLSyxuHjU03EGVLahJ0Haliipr69pnKnS8H69qrjVlNAbCRuqzANUFr95qZC6a1n2rEh5FzXWwZD"}");
        request.SetRequestHeader("Content-Type", "application/json");

        // Send the POST request.
        StartCoroutine(SendRequest(request));
    }

    private IEnumerator<UnityEngine.Networking.UnityWebRequestAsyncOperation> SendRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.LogError($"Error sending image: {request.error}");
           //sphere();
        }
        else
        {
            string response = request.downloadHandler.text;

            // Do something with the response.
        }
    }
}

public class WhatsAppMessage
{
    public string messaging_product { get; set; }
    public string recipient_type { get; set; }
    public string to { get; set; }
    public string type { get; set; }
    public WhatImage image { get; set; }

}

public class WhatImage
{
    public string link{ get; set; }

}
