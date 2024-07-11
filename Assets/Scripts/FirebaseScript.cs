using Firebase.Extensions;
using Firebase.Storage;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using Application = UnityEngine.Application;

public class FirebaseScript : MonoBehaviour
{
    [SerializeField]
    private GameData gameData;

    public void Start()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
        GetEachFishImage();       
    }

    public void GetEachFishImage()
    {
        // Get a reference to the storage service, using the default Firebase App
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;      

        // Points to the root reference
        StorageReference storageRef =
            storage.GetReferenceFromUrl("gs://catch-the-fish-test.appspot.com");

        // Points to "FIshImages"
        StorageReference imagesRef = storageRef.Child("FIshImages");

        //since there is no listall function for firebase for Unity editor and only for IOS / Android
        foreach (Sprite Images in gameData.FallingObjectsImages)
        {
            string filename = Images.name + ".png";
            StorageReference fishRef = imagesRef.Child(filename);

            GetImage(fishRef, filename);
        }      
    }

    public void GetImage(StorageReference fishRef, string filename)
    {
        // Create local filesystem URL
        string localFish = Application.dataPath + "/Art/" + filename;

        // Download to the local filesystem
        fishRef.GetFileAsync(localFish).ContinueWithOnMainThread(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                Debug.Log("File downloaded.");
            }
            else

            {
                Debug.Log("downloaded failed.");
            }
        });
    }
}
