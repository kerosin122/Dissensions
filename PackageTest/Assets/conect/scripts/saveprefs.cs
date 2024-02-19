using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class SliderData
{
    public float slider1Value;
    public float slider2Value;
}

public class saveprefs: MonoBehaviour
{ 
    public UnityEngine.UI.Slider slider1;
    public UnityEngine.UI.Slider slider2;

    private string filePath;

  private void Awake()
  {
      filePath = Path.Combine(Application.persistentDataPath, "sliderData.xml");
  
      if (!File.Exists(filePath))
      {
          using (FileStream stream = File.Create(filePath))
          {
              stream.Close();
          }
      }
  }
public void SaveAndLoad()
{
    SaveSliders();
    LoadSliders();
}
    private void OnEnable()
    {
        LoadSliders();

    }

    private void OnDisable()
    {
        SaveSliders();
    }

    public void SaveSliders()
    {
        SliderData data = new SliderData();
        data.slider1Value = slider1.value;
        data.slider2Value = slider2.value;

        XmlSerializer serializer = new XmlSerializer(typeof(SliderData));
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(stream, data);
        }

        Debug.Log("Sliders saved to XML.");
    }

    public void LoadSliders()
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SliderData));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                SliderData data = (SliderData)serializer.Deserialize(stream);
                slider1.value = data.slider1Value;
                slider2.value = data.slider2Value;
            }

            Debug.Log("Sliders loaded from XML.");
        }
        else
        {
            Debug.LogError("XML file not found.");
        }
    }
}
