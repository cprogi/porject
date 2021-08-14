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
        talkData.Add(1000, new string[] { "안녕?", "이곳에 처음왔구나?" });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "밖에 누구 있어요?",
                                               "저를 구해주세요!",
                                               "어떻게 컵이 말을 하는 거지?",
                                               "해변의 사람들을 구경하러 왔다가 갑자기 날아온 이것에 갇혀버렸어요.",
                                               "이걸 들어올려서 저를 꺼내주세요.",
                                               "저런, 내가 구해줄게요."});

        talkData.Add(11 + 1000, new string[] {"휴, 덕분에 살았어요. 정말 감사합니다.",
                                              "엇, 당신은 사람이군요!",
                                              "네, 바다를 구경하러 왔어요.",
                                              " 사람은 바다에서 쉽게 지쳐요.",
                                              " 여기 있는 해초들을 먹으면 조금 힘이 날 거에요.",
                                              "종종 다른 사람들이 이걸 이용해서 해초를 캐는 걸 봤는데,",
                                              "제가 아끼는 수집품이지만 선물로 드릴게요 "});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                //퀘스트 맨 처음 대사마저 없을 때,
                //기본 대사를 가져옴.
                if (talkIndex == talkData[id - id % 100].Length)
                    return null;
                else
                    return talkData[id - id % 100][talkIndex];
            }
            else
            {
                //해당 퀘스트 진행 순서 대사가 없을 때,
                //퀘스트 맨 처음 대사를 가지고 옴.
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
