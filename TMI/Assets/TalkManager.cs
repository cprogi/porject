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
        talkData.Add(50 + 11000, new string[]
        { "상자해파리: 그거 알아?",
          "상자해파리: 우리 해파리랑 비닐봉지가 비슷하게 생겨서,",
          "상자해파리: 우리의 천적들이 비닐봉지를 우리로 착각하고 먹기도 한대!"});

        //Quest Talk
        talkData.Add(10 + 1000, new string[] 
        { "흰동가리: 밖에 누구 있어요?",
          "흰동가리: 저를 구해주세요!",
          "플레이어: 어떻게 컵이 말을 하는 거지?",
          "흰동가리: 해변의 사람들을 구경하러 왔다가 \n갑자기 날아온 이것에 갇혀버렸어요.",
          "흰동가리: 이걸 들어올려서 저를 꺼내주세요.",
          "플레이어: 저런, 내가 구해줄게요."});

        talkData.Add(20 + 2000, new string[] 
        { "흰동가리: 휴, 덕분에 살았어요. 정말 감사합니다.",
          "흰동가리: 엇, 당신은 사람이군요!",
          "플레이어: 네, 바다를 구경하러 왔어요.",
          "흰동가리: 사람은 바다에서 쉽게 지쳐요.",
          "흰동가리: 여기 있는 해초들을 먹으면 조금 힘이 날 거에요.",
          "흰동가리: 종종 다른 사람들이 이걸 이용해서 해초를 캐는 걸 봤는데,",
          "흰동가리: 제가 아끼는 수집품이지만 선물로 드릴게요."});

        talkData.Add(30 + 4000, new string[]
        {
            "깃대돔: 청색양쥐돔 이 녀석! \n또 내 물건을 훔쳐갔어.",
            "플레이어: 헉, 물건을 훔쳤다고요?",
            "깃대돔: 그래. 그 녀석은 약간 도벽이 있어.",
            "깃대돔: 보나마나 또 자기 집 바닥에 묻어 놨겠지.",
            "깃대돔: 에휴~ 알고 보면 착한 녀석이라서 미워할 수도 없고, \n버릇을 언제 고치려나."
        });

        talkData.Add(40 + 7000, new string[]
        {
            "플레이어: 안녕하세요, 제가 지나갈 수 있게 조금만 길을 비켜주시겠어요?",
            "푸른바다거북: 미안하지만 어렵겠네.",
            "푸른바다거북: 나는 지금 움직일 수가 없어.",
            "플레이어: 무슨 일이에요?",
            "푸른바다거북: 상어에게 공격당해서 다리를 다쳤네.",
            "플레이어: 너무 아프시겠어요.",
            "플레이어: 다리를 치료할 수 있는 방법이 있을까요?",
            "푸른바다거북: 글쎄...",
            "푸른바다거북: 여기 해초 중에 그런 게 있던 것 같기는 한데 기억이 안 나는군.",
            "플레이어: 그럼 제가 한 번 찾아볼게요.",
            "푸른바다거북: 고맙네."
        });

        talkData.Add(41 + 7000, new string[]
        {
            "푸른바다거북: 덕분에 상처가 빨리 나았구만. 고맙네."
        });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                return GetTalk(id - id % 10, talkIndex);
            }
        }

        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
            return talkData[id][talkIndex];
    }
}
