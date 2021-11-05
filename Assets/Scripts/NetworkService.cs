using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkService
{
    private const string city = "Guangzhou,cn";
    private const string appid = "2d4afe2fb3ec685b7437e2ec9b6e95be";

    private readonly string xmlApi;
    private readonly string jsonApi;
    private readonly string imageUrl;
    public NetworkService()
    {
        xmlApi = $"https://api.openweathermap.org/data/2.5/weather?q={city}&APPID={appid}&mode=xml";
        jsonApi = $"https://api.openweathermap.org/data/2.5/weather?q={city}&APPID={appid}";
        imageUrl = $"https://www.textures.com/static/testimonials/gallery2.jpg";
    }

    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {

            }
            else if (request.responseCode != (long)System.Net.HttpStatusCode.OK)
            {

            }
            else
            {
                callback(request.downloadHandler.text);
            }
        }
    }

    public IEnumerator DownloadImage(Action<Texture2D> callback)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);

        yield return request.SendWebRequest();

        Texture2D d2 = DownloadHandlerTexture.GetContent(request);

        Debug.Log(d2);

        callback(d2);
    }

    public IEnumerator GetWeatherXML(Action<string> callback)
    {
        return CallAPI(xmlApi, callback);
    }

    public IEnumerator GetWeatherJson(Action<string> callback)
    {
        return CallAPI(jsonApi, callback);
    }
}
