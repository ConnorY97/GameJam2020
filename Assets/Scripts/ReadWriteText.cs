using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadWriteText : MonoBehaviour
{
    void CreateText()
    {
        // Path of the file
        string path = Application.dataPath + "/Log.txt";

        // Create File if it doesn't exist
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Testing");
        }

        // Content of the file

        // Add some text to it
    }


    // Start is called before the first frame update
    void Start()
    {
        CreateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
