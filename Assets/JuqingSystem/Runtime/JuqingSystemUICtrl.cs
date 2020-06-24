using System.Collections.Generic;
using UnityEngine;
using XNode.Examples.JuqingGraph;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Utils.CustomUtils.UI;

public class JuqingSystemUICtrl : MonoBehaviour
{
    public JuqingGraph talkGraph;
    public Text question;
    public Transform buttonRoot;
    public CommonButton buttonPrefab;

    private bool isWaitChose = false;

    private void Start()
    {
        // test
        Play();
    }

    public async void Play()
    {
        if (!talkGraph)
        {
            Debug.LogError($"ob:{gameObject.name} have not talkGraph");
            return;
        }

        talkGraph.ResetToStart();
        TalkAndChoseNode node = talkGraph.current;
        int maxNum = 50;
        int index = 0;
        while (node is TalkAndChoseNode || index > maxNum)
        {
            index += 1;
            question.text = node.question;
            InitButtonList(node.exit);
            await UniTask.WaitUntil(() => isWaitChose);
            isWaitChose = false;
            node = talkGraph.current;
        }

        // close this window?
    }

    private void OnButtonClick(JuqingData target)
    {
        talkGraph.Continue(target);
        isWaitChose = true;
    }

    private void InitButtonList(List<JuqingData> datas)
    {
        // clear
        foreach (Transform subOb in buttonRoot)
        {
            Destroy(subOb.gameObject);
        }

        // create chose
        for (int i = 0; i < datas.Count; i++)
        {
            JuqingData chose = datas[i];
            CommonButton btn = Instantiate(buttonPrefab, buttonRoot);
            btn.myText.text = chose.talkString;
            btn.myButton.onClick.AddListener(delegate ()
            {
                OnButtonClick(chose);
            });
        }
    }
}
