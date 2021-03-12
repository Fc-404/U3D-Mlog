using System;
using System.Collections;
using System.Collections.Generic;

namespace MlogsG
{
    /// <summary>
    /// 消息接口类
    /// </summary>
    public class Mlogs
    {
        // 消息链
        static private List<string> messages = new List<string>();
        //最大消息长度
        static private int maxLength = 10;
        // 未读消息长度
        static private int unreadL = 0;

        /// <summary>
        /// 添加一条消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns>成功返回true</returns>
        static public bool add(string message) {
            chickLength();
            messages.Add(message);
            ++unreadL;
            return true;
        }


        /// <summary>
        /// 添加一条带时间的消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns>成功返回true</returns>
        static public bool addWithTime(string message) {
            chickLength();
            messages.Add(DateTime.Now.ToLongTimeString().ToString() + ": " + message);
            ++unreadL;
            return true;
        }


        /// <summary>
        /// 获取消息长度
        /// </summary>
        /// <returns>返回消息长度</returns>
        static public int getMessagesLength() {
            return messages.Count;
        }


        /// <summary>
        /// 获取某个索引的消息
        /// </summary>
        /// <param name="index">索引值</param>
        /// <returns>消息</returns>
        static public string at(int index) {
            return messages[index];
        }


        /// <summary>
        /// 设置消息最大值
        /// </summary>
        /// <param name="max">最大值</param>
        /// <returns>成功返回true</returns>
        static public bool setMax(int max) {
            maxLength = max;
            return true;
        }


        /// <summary>
        /// 检查消息是否超过最大值，如果超过则剔除最旧的消息。
        /// </summary>
        static private void chickLength() {
            // 如果消息长度大于消息最大值，则剔除第一个消息
            if (messages.Count > maxLength) {
                messages.RemoveAt(0);
            }
            //如果未读消息大于消息最大值，则赋值为最大值
            if (unreadL > maxLength) {
                unreadL = maxLength;
            }
        }


        /// <summary>
        /// 获取所有最新消息
        /// </summary>
        /// <returns>最新消息链</returns>
        static public List<string> getNewMessages() {
            if (unreadL <= 0) {
                return null;
            }
            List<string> newMessages = new List<string>();
            for (int i = messages.Count - unreadL; i < messages.Count; ++i) {
                newMessages.Add(messages[i]);
            }
            unreadL = 0;
            return newMessages;
        }


        /// <summary>
        /// 获取未读第一条消息
        /// </summary>
        /// <returns>消息</returns>
        static public string getNewMessage() {
            if (unreadL <= 0) {
                return null;
            }
            return messages[--unreadL];
        }


        /// <summary>
        /// 获取最后一条消息
        /// </summary>
        /// <returns>消息</returns>
        static public string getLastMessage() {
            return messages[messages.Count - 1];
        }


        /// <summary>
        /// 获取未读消息长度
        /// </summary>
        /// <returns>未读消息长度</returns>
        static public int getUnread() {
            return unreadL;
        }
    }
}
