using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;

public class SavePrefabs : MonoBehaviour
{
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;

    private string _filePath;

    private void Awake()
    {
        _filePath = Path.Combine(Application.persistentDataPath, "sliderData.xml");

        if (!File.Exists(_filePath))
        {
            using (FileStream stream = File.Create(_filePath))
                stream.Close();
        }
    }

    private void OnEnable() => LoadSliders();
    private void OnDisable() => SaveSliders();

    private void SaveSliders()
    {
        SliderData data = new SliderData();

        data.SliderSounds = _soundSlider.value;
        data.SliderMusic = _musicSlider.value;

        XmlSerializer serializer = new XmlSerializer(typeof(SliderData));

        using (FileStream stream = new FileStream(_filePath, FileMode.Create))
            serializer.Serialize(stream, data);
    }

    private void LoadSliders()
    {
        if (File.Exists(_filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SliderData));

            using (FileStream stream = new FileStream(_filePath, FileMode.Open))
            {
                SliderData data = (SliderData)serializer.Deserialize(stream);
                _soundSlider.value = data.SliderSounds;
                _musicSlider.value = data.SliderMusic;
            }
        }
    }
}