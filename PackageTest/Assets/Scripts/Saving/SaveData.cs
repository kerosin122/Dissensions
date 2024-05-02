using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace ScriptsSaving
{
    public class SaveData : MonoBehaviour
    {
        public static SaveData Instance { get; private set; }
        public int CurrentCharacterID => _currentCharacterID;

        [SerializeField] private int _currentCharacterID;

        private void Awake()
        {
            if (Instance != null&& Instance != this)
                Destroy(gameObject);

            else
                Instance = this;

            DontDestroyOnLoad(gameObject);
            Load();
        }

        public void Save()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");

            PlayerDataStorage data = new PlayerDataStorage();
            data.CurrentCarID = _currentCharacterID;

            binaryFormatter.Serialize(file, data);
            file.Close();
        }

        public void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
                PlayerDataStorage data = (PlayerDataStorage)binaryFormatter.Deserialize(file);

                _currentCharacterID = data.CurrentCarID;
                file.Close();
            }
        }
    }
}