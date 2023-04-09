using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class ApiCallExample : MonoBehaviour
{
    [SerializeField] int _stringItemIndex = 0;
    [SerializeField] string _newItemString = "Value Item";

    string _url = "https://localhost:44375/api/values/";

    [ContextMenu(nameof(GetStringAllItems))]
    public async void GetStringAllItems()
    {
        string url = _url + "GetAllStringInventoryListItems";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            var asyncOperation = webRequest.SendWebRequest();
            while (!asyncOperation.isDone)
            {
                await Task.Delay(10);
            }

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                List<string> stringValues =
                    JsonConvert.DeserializeObject<List<string>>(webRequest.downloadHandler.text);

                foreach (string stringValue in stringValues)
                {
                    Debug.Log(stringValue);
                }
            }
        }
    }

    [ContextMenu(nameof(GetStringItemByIndex))]
    public async void GetStringItemByIndex()
    {
        string url = _url + $"GetStringInventoryItemByItemIndex?index={_stringItemIndex}";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            var asyncOperation = webRequest.SendWebRequest();
            while (!asyncOperation.isDone)
            {
                await Task.Delay(10);
            }

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                string stringValue = JsonConvert.DeserializeObject<string>(webRequest.downloadHandler.text);

                Debug.Log(stringValue);
            }
        }
    }
    
    [ContextMenu(nameof(PostStringItem))]
    public async void PostStringItem()
    {
        string url = _url + $"PostInventoyItem?item={_newItemString}";
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url,_newItemString))
        {
            var asyncOperation = webRequest.SendWebRequest();
            while (!asyncOperation.isDone)
            {
                await Task.Delay(10);
            }

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                string stringValue = JsonConvert.DeserializeObject<string>(webRequest.downloadHandler.text);

                Debug.Log(stringValue);
            }
        }
    }
    
    [ContextMenu(nameof(GetClassItem))]
    public async void GetClassItem()
    {
        string url = _url + $"GetItem";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            var asyncOperation = webRequest.SendWebRequest();
            while (!asyncOperation.isDone)
            {
                await Task.Delay(10);
            }

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                Item item = JsonConvert.DeserializeObject<Item>(webRequest.downloadHandler.text);

                Debug.Log(item.ToString());
            }
        }
    }
    
    [ContextMenu(nameof(GetAllInventory))]
    public async void GetAllInventory()
    {
        string url = _url + $"GetAllClassInventory";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            var asyncOperation = webRequest.SendWebRequest();
            while (!asyncOperation.isDone)
            {
                await Task.Delay(10);
            }

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                var inventory = JsonConvert.DeserializeObject<Inventory>(webRequest.downloadHandler.text);

                Debug.Log(inventory.ToString());

                foreach (var item in inventory.Items)
                {
                    Debug.Log(item.ToString());
                }
            }
        }
    }
    
    [ContextMenu(nameof(PostClassItemToInventory))]
    public async void PostClassItemToInventory()
    {
        string url = _url + $"PostItemToInventory";

        Item item = new Item
        {
            ID = 6,
            Name = "New Item",
            ItemValue = 1000f,
            MagicValue = 500f,
            ItemExtraValue = 10f
        };

        string jsonValue = JsonConvert.SerializeObject(item);
        
        StringContent content = new StringContent(jsonValue, Encoding.UTF8, "application/json");
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            Debug.Log($"Error: {response.StatusCode}");
        }
    }
}