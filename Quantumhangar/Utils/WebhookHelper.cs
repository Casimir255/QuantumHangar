using System;
using System.Net;
using System.Text;
using NLog;

namespace QuantumHangar.Utils;

public static class WebhookHelper
{
    private static readonly Logger Log = LogManager.GetCurrentClassLogger();
    private static string WebhookUrl => Hangar.Config.DiscordWebhookUrl;


    public static void SendMessage(string payloadJson)
    {
        if (string.IsNullOrWhiteSpace(WebhookUrl))
            return;

        Log.Info("Sending message to webhook...");
        Log.Info(payloadJson);
        
        try
        {
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            client.UploadData(WebhookUrl, Encoding.UTF8.GetBytes(payloadJson));
        }
        catch (Exception e)
        {
            Log.Error($"Hangar Market Discord webhook error, {e}");
        }
    }
}