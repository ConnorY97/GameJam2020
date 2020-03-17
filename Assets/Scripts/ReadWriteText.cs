using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ReadWriteText : MonoBehaviour
{

    public float volume;
    [HideInInspector]
    public float highScore;
    //public GameData mData;

    void CreateFile()
    {
        //// Path of the file
        //string path = Application.dataPath + "/Log.txt";

        //// Create File if it doesn't exist
        //if (!File.Exists(path))
        //{
        //    File.WriteAllText(path, "Testing \n\n");
        //}

        //// Content of the file
        //string content = "Testing content: " + System.DateTime.Now + "\n";

        //// Add some text to it
        //File.AppendAllText(path, content);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/gameData.dat");

        GameData data = new GameData
        {
            mVolume = volume,
            mHighScore = highScore
        };

        bf.Serialize(file, data);
        Debug.Log("File Created");
        file.Close();
    }

    void ReadFile()
    {
        //string path = "/Log.txt";

        //// Read the text directly from the .txt file
        //File.ReadAllText(path);
        if (new FileInfo(Application.dataPath + "/gameData.dat").Length == 0)
        {
            Debug.Log("File is empty @ " + Application.dataPath + "/gameData.dat");
            CreateFile();
        }
        else if (File.Exists(Application.dataPath + "/gameData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/gameData.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);

            volume = data.mVolume;
            highScore = data.mHighScore;
            Debug.Log("File Read");
            file.Close();
        }
    }

    public void OverwriteData()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.dataPath + "/gameData.dat");
        GameData data = new GameData
        {
            mVolume = volume,
            mHighScore = highScore
        };

        bf.Serialize(file, data);
        Debug.Log("File Overwrite with volume = " + volume + " & highscore = " + highScore);
        file.Close();
    }

    // Start is called before the first frame update
    void Awake()
    {

        if (!File.Exists(Application.dataPath + "/gameData.dat"))
        {
            volume = 100;
            highScore = 0;
            CreateFile();
        }
        else
            ReadFile();
    }

    [System.Serializable]
    public class GameData
    {
        public float mVolume = 100;
        public float mHighScore;
    }
}
