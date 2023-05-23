using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.Models
{
    /// <summary>
    /// メッセージのデータクラス
    /// </summary>
    public class MessageItem
    {
        /// <summary>
        /// メッセージ内容
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime Date { get; init; } = DateTime.Now;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="content"></param>
        public MessageItem(string content)
        {
            Content = content;
        }
    }
}
