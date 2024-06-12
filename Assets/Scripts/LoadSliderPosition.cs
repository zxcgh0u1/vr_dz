using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class LoadSliderPosition : MonoBehaviour
{
    public Slider slider;
    public string jsonURL;
    public Jsonclass jsnData;
    void Start()
    {
        StartCoroutine(getData());
    }

    IEnumerator getData()
    {
        Debug.Log("Download...");
        var uwr = new UnityWebRequest(jsonURL);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "result.json");
        var dh = new DownloadHandlerFile(resultFile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
            Debug.Log("ERROR");
        else
        {
            Debug.Log("Download saved to: " + resultFile);
            jsnData = JsonUtility.FromJson<Jsonclass>(File.ReadAllText(Application.persistentDataPath + "/result.json"));
            slider.value = jsnData.position;
            yield return StartCoroutine(getData());
        }
    }

    [System.Serializable]
    public class Jsonclass
    {
        public float position;
    }
}
