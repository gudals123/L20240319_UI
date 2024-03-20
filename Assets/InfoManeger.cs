using System.Collections;
using System.Collections.Generic;
using System;
using System.IO; //File , Directory ����� ���� using
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    [SerializeField] Info player_info;

    public Text ID_Text;
    public Text Point_Text;
    public Text Gold_Text;



    private void Awake()
    {
        player_info = new Info();

        var loadedJson = Resources.Load<TextAsset>("info");
        //���ҽ� ������ �ִ� info(Text Asset)�� �ε� �ϰڽ��ϴ�.
        //Text Asset�� �ؽ�Ʈ ������ ������ �ǹ��մϴ�.

        player_info = JsonUtility.FromJson<Info>(loadedJson.text);
        //JsonUtility.FromJson<T>(string json);
        //json ���Ϸκ��� �о�� ������ �������� �����͸� �����ϴ� �ڵ�
        printText();
    }


    public string PLAYER_ID => ID_Text.text = player_info.name.ToString();

    public string PLAYER_POINT => Point_Text.text = $"{player_info.point:n0}";

    public string PLAYER_GOLD => Gold_Text.text = $"{player_info.gold:n0}";

    void printText()
    {

        ID_Text.text = PLAYER_ID;
        Point_Text.text = PLAYER_POINT;
        Gold_Text.text = PLAYER_GOLD;
    }


    /// <summary>
    /// ����Ʈ�� ����ؼ� ���� �����ϴ� �ڵ� (100 ����Ʈ -> 10000 ���)
    /// </summary>
    public void GoldPlus()
    {
        if (player_info.point >= 100)
        {
            player_info.point -= 100;
            player_info.gold += 10000;

            //JsonUtility.ToJson(object obj);
            //��ü�� ������ Json ���Ϸ� ������ ��� 
            //�÷��̾� ������ json ���Ͽ� ����
            SaveData(player_info);
            printText();
        }
        else
        {
            Debug.Log("��ȯ�� ����Ʈ�� �����մϴ�!");
        }
    }
    private string ResourcePath => Application.dataPath + "/Resources/";
    //[����Ƽ ������ ���]
    private string SavePath => Application.persistentDataPath;
    //���� ������ ������ ��ġ , Ư�� �ü������ ���� ����� �� �ֵ��� ����ϴ� ���
    //C:\Users\[user name]\AppData\LocalLow\[company name]\[product name]
    private string DataPath => Application.dataPath;
    //�������� ���� ���(�б� ����)���� ������Ʈ ���� ����(Asset)�� �ǹ��մϴ�.
    private string StreamingPath => Application.streamingAssetsPath;
    //Application.dathPath + StreamingAssets = Application.streamingAssetsPath

    public void SaveData(Info info)
    {
        //������ ���� ��쿡�� ������ �����մϴ�.
        if (!Directory.Exists(ResourcePath))
        {
            Directory.CreateDirectory(ResourcePath);
        }
        var sJson = JsonUtility.ToJson(info); //1. json ������ ������ string ���·� �����մϴ�.
        var FilePath = ResourcePath + "info.json";
        File.WriteAllText(FilePath, sJson);
    }

    public void SaveData2()
    {
        if (!Directory.Exists(ResourcePath))
        {
            Directory.CreateDirectory(ResourcePath);
        }
        var sJson = JsonUtility.ToJson(player_info); //1. json ������ ������ string ���·� �����մϴ�.
        var FilePath = Path.Combine(DataPath, "info.json");
        //DataPath/info.json
        //���� ���ڿ��� �� ��η� �����ϴ� ��� (System.IO)
        File.WriteAllText(FilePath, sJson);
        printText();
    }


    public Info LoadData()
    {
        player_info = null; //Ŭ���� ��ü ����(���ص� ����� ����)

        if (File.Exists(ResourcePath + "info.json"))//������ ������ �н��� ������ ���
        {
            var json = File.ReadAllText(ResourcePath + "info.json"); //�ش� ��ηκ��� ������ �о�ɴϴ�.
            player_info = JsonUtility.FromJson<Info>(json);//�о�� ������ ���� Info�� ���� �����մϴ�.
        }

        return player_info;//�ϼ��� ��ü�� return�մϴ�.
    }

    public void LoadData2()
    {
        var data = File.ReadAllText(ResourcePath + "info.json");
        player_info = JsonUtility.FromJson<Info>(data);
    }


    public void LosePointGold()
    {
        player_info.gold -= 100;
        player_info.point -= 100;

    }

    public void AcquiredPointGold()
    {
        player_info.gold += 500;
        player_info.point += 500;

    }




}