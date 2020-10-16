using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System;
using TMPro;

public class SimpleAES : GameData
{
    // This size of the IV (in bytes) must = (keysize / 8). Default keysize is 256, so the IV must be
    // 32 bytes long. Using a 16 character string here gives us 32 bytes when converted to a byte array.
    private const string initVector = "14ruk189gfhje9r5";
    // This constant is used to determine the keysize of the encryption algorithm
    private const int keysize = 256;
    //Encrypt
    public string EncryptString(string plainText, string passPhrase)
    {
        byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
        byte[] keyBytes = password.GetBytes(keysize / 8);
        RijndaelManaged symmetricKey = new RijndaelManaged();
        symmetricKey.Mode  = CipherMode.CBC;
        ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(plainTextBytes, 0, plainText.Length);
        cryptoStream.FlushFinalBlock();
        byte[] cipherTextBytes = memoryStream.ToArray();
        memoryStream.Close();
        cryptoStream.Close();
        return Convert.ToBase64String(cipherTextBytes);    
    }
    // decrypt
    public string DecryptString(string cipherText, string passPhrase)
    {
        byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
        byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
        PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
        byte[] keyBytes = password.GetBytes(keysize / 8);
        RijndaelManaged symmetricKey = new RijndaelManaged();
        symmetricKey.Mode = CipherMode.CBC;
        ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
        MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
        CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        byte[] plainTextBytes = new byte[cipherTextBytes.Length];
        int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        memoryStream.Close();
        cryptoStream.Close();
        return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
    }
}

public class SaveSystem : MonoBehaviour
{
    public TMP_InputField importValue;
    public TMP_InputField exportValue;

    // public InputField encryptValue;
    // public InputField decryptValue;

    public static string json = "";

    protected static string encryptKey = "3xhhr44dj1sc5g6h6f0pvq4g";
    protected static string savePath = "/GameDataV1.save";
    protected static string savePathBackUP = "/GameDataV1BackUp.save";

    public static int backUpCount = 0;

    public static void SaveGame(GameData data)
    {
        var saveTo = backUpCount == 4 ? savePathBackUP : savePath;
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + saveTo))
        {
            json = JsonUtility.ToJson(data);
            // Debug.Log(json);
            ConvertStringToBase64(writer, json);
            writer.Close();
            /*
            PlayerPrefs.SetString("OfflineTime", System.DateTime.Now.ToBinary().ToString());
            data.OfflineProgressCheck = true; */
        }

        backUpCount = (backUpCount + 1) % 5;
    }

    public static string ConvertStringToBase64(StreamWriter writer, string x)
    {
        SimpleAES aes = new SimpleAES();
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(x);
        string stringTemp = Convert.ToBase64String(plainTextBytes);
        writer.WriteLine(aes.EncryptString(stringTemp, encryptKey));
        return stringTemp;
    }
    public static bool LoadSaveFile(ref GameData data, string path)
    {
        var success = false;
        //try
        //{
            using (StreamReader reader = new StreamReader(path))
            {
                json = ConvertBase64ToString(reader);
                data = JsonUtility.FromJson<GameData>(json);
                reader.Close();
                success = true;
            }
        //}
        if (!success)
        {
            Debug.Log("Load Save Failed");
            CreateFile();
            // LoadPlayer(ref data);
            // Load Failed, handle codes here
        }
        return success;
    }
    
    public static void CreateFile()
    {
        if (!File.Exists(Application.persistentDataPath + savePathBackUP))
        {
            File.CreateText(Application.persistentDataPath + savePathBackUP);
        }
        if (!File.Exists(Application.persistentDataPath + savePath))
        {
            File.CreateText(Application.persistentDataPath + savePath);
        }   
    }
    public static void LoadGame(ref GameData data)
    {
        CreateFile();
        if (!LoadSaveFile(ref data, Application.persistentDataPath + savePath))
        { // Try to load main
            LoadSaveFile(ref data, Application.persistentDataPath + savePathBackUP); // Load backup if main failed to load
        }
    }

    public static string ConvertBase64ToString(StreamReader reader)
    {
        SimpleAES aes = new SimpleAES();
        string stringConvert = reader.ReadLine();
        var base64EncodedBytes = Convert.FromBase64String(aes.DecryptString(stringConvert, encryptKey));
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }


    public void ImportGame(GameData Data)
    {
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + savePath))
        {
            Debug.Log(importValue.text);
            writer.WriteLine(importValue.text);
            writer.Close();
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + savePath))
            {
                json = ConvertBase64ToString(reader);
                Data = JsonUtility.FromJson<GameData>(json);
                reader.Close();
            }
        }
    }

    public void ExportGame()
    {
        using (StreamReader reader = new StreamReader(Application.persistentDataPath + savePath))
        {
            SimpleAES aes = new SimpleAES();
            string outputData = reader.ReadLine();
            reader.Close();
            exportValue.text = outputData;
            //decryptValue.text = aes.DecryptString(outputData, encryptKey);
            Debug.Log(outputData);
        }
    }



/*
    public void Encrypt()
    {
        SimpleAES aes = new SimpleAES();
        string temp = encryptValue.text;
        encryptValue.text = aes.EncryptString (temp, encryptKey);
    }
*/
    public void ClearFields()
    {
        exportValue.text = "";
        importValue.text = "";
    }
}
