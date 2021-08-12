 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?", "�̰��� ó���Ա���?" });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "�ۿ� ���� �־��?",
                                               "���� �����ּ���!",
                                               "��� ���� ���� �ϴ� ����?",
                                               "�غ��� ������� �����Ϸ� �Դٰ� ���ڱ� ���ƿ� �̰Ϳ� �������Ⱦ��.",
                                               "�̰� ���÷��� ���� �����ּ���.",
                                               "����, ���� �����ٰԿ�."});

        talkData.Add(11 + 1000, new string[] {"��, ���п� ��Ҿ��. ���� �����մϴ�.",
                                              "��, ����� ����̱���!",
                                              "��, �ٴٸ� �����Ϸ� �Ծ��.",
                                              " ����� �ٴٿ��� ���� ���Ŀ�.",
                                              " ���� �ִ� ���ʵ��� ������ ���� ���� �� �ſ���.",
                                              "���� �ٸ� ������� �̰� �̿��ؼ� ���ʸ� ĳ�� �� �ôµ�,",
                                              "���� �Ƴ��� ����ǰ������ ������ �帱�Կ� "});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                //����Ʈ �� ó�� ��縶�� ���� ��,
                //�⺻ ��縦 ������.
                if (talkIndex == talkData[id - id % 100].Length)
                    return null;
                else
                    return talkData[id - id % 100][talkIndex];
            }
            else
            {
                //�ش� ����Ʈ ���� ���� ��簡 ���� ��,
                //����Ʈ �� ó�� ��縦 ������ ��.
                if (talkIndex == talkData[id - id % 10].Length)
                    return null;
                else
                    return talkData[id - id % 10][talkIndex];
            }
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
