using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scz.ConsoleApp
{
    using System.IO;

    using Newtonsoft.Json;

    public class MyJsonReader
    {
        public static void Read(string filePath)
        {
            string json = File.ReadAllText(filePath, Encoding.Default);

            //容错处理
            json = json.Replace("，", ",")
                .Replace("“", "\"")
                .Replace("”", "\"")
                .Replace("：", ":")
                .Replace("｛", "{")
                .Replace("｝", "}")
                .Replace("【", "[")
                .Replace("】", "]");

            try
            {
                JsonObjectVersion jsonObjectVersion = JsonConvert.DeserializeObject<JsonObjectVersion>(json);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }

    public class JsonObjectVersion
    {
        public List<ObjectVersion> 版本记录 { get; set; }
    }
    /// <summary>
    /// 版本记录实体类
    /// </summary>
    public class ObjectVersion
    {
        public string Jira { get; set; }
        public string 系统 { get; set; }
        public Int32 版本 { get; set; }
        public string 地区 { get; set; }
        public string 类型 { get; set; }
        public string 描述 { get; set; }

    }
}
