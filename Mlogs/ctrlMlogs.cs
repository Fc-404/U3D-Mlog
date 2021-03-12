using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MlogsG;

public class ctrlMlogs : MonoBehaviour
{
    [SerializeField]
    private Text infoObj;
    // 消息框对象
    [SerializeField]
    private GameObject panelObj;
    //消息面板对象
    [SerializeField]
    private float panelLife = 3.0f;
    // 面板生命周期
    [SerializeField]
    private float updateTime = 0;
    //[SerializeField]
    //private int messageMaxRow = 3;
    // 消息最大行数
    string infoStr = "";
    //消息字段

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        updateMessage();
        //print(Mlogs.getMessagesLength());
    }
    void updateMessage() {
        if (Mlogs.getUnread() <= 0) {
            if (Time.time - updateTime > panelLife) {
                panelObj.SetActive(false);
            }
            return;
        }

        //暂时阉割消息
        List<string> messages = Mlogs.getNewMessages();

        for (int i = 0; i < messages.Count; ++i) {
            infoStr = messages[messages.Count - i - 1] + "\n" + infoStr;
        }

        // 剔除字符串
        infoStr = infoStr.Substring(0, infoStr.Length > 256 ? 256 : infoStr.Length);
        //print(infoStr.Length);

        infoObj.text = infoStr;

        panelObj.SetActive(true);

        updateTime = Time.time;
    }
}
