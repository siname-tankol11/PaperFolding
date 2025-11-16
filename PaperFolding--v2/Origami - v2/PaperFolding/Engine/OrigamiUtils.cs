using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Origami
{

    // 根对象
    public class WorkflowRoot
    {
        [JsonProperty("start")]
        public StartObject Start { get; set; }

        [JsonProperty("folds")]
        public List<FoldObject> Folds { get; set; }
    }

    // Start对象（多态：id或points）
    public class StartObject
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }          // 整数ID（可选，与Points互斥）

        [JsonProperty("points")]
        public List<PointF> Points { get; set; } // 点列表（可选，与Id互斥）

        [JsonProperty("otherParam")]
        public string OtherParam { get; set; }
    }

    // Fold对象
    public class FoldObject
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("foldingParams")]
        public List<FoldingParam2> FoldingParams { get; set; }

        [JsonProperty("foldParam")]
        public string FoldParam { get; set; }
    }

    // 折叠参数（多态：点模式或角度模式）
    public abstract class FoldingParam2
    {
        [JsonProperty("lastId")]
        public int LastId { get; set; }        // 公共参数：lastId
    }

    // 点模式参数
    public class PointFoldingParam : FoldingParam2
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("p1")]
        public PointF P1 { get; set; }

        [JsonProperty("p2")]
        public PointF P2 { get; set; }
    }

    // 角度模式参数
    public class AngleFoldingParam : FoldingParam2
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("p1")]
        public PointF P1 { get; set; }

        [JsonProperty("alpha")]
        public double Alpha { get; set; }      // 角度（弧度或度数，需根据业务定义）
    }

    public class FoldingParamConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(FoldingParam).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            string mode = jObject["mode"].Value<string>();

            switch (mode)
            {
                case "point":
                    return jObject.ToObject<PointFoldingParam>();
                case "angle":
                    return jObject.ToObject<AngleFoldingParam>();
                default:
                    throw new JsonException("未知的折叠参数模式：{mode}");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }

    public static class WorkflowParser
    {
        // 解析JSON
        public static WorkflowRoot ParseJson(string json)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new FoldingParamConverter() }
            };
            return JsonConvert.DeserializeObject<WorkflowRoot>(json, settings);
        }

        // 序列化为JSON
        public static string SerializeJson(WorkflowRoot root)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new FoldingParamConverter() },
                Formatting = Formatting.Indented
            };
            return JsonConvert.SerializeObject(root, settings);
        }

        // 示例用法
        public static void Example()
        {
            string json = @"{ /* 如上文的JSON示例 */ }";
            WorkflowRoot root = ParseJson(json);

            // 访问Start对象
            Console.WriteLine("Start类型：{root.Start.Type}");
            if (root.Start.Id.HasValue)
            {
                Console.WriteLine("Start ID：{root.Start.Id}");
            }
            else if (root.Start.Points != null)
            {
                Console.WriteLine("Start点数量：{root.Start.Points.Count}");
            }

            // 访问Fold对象
            foreach (var fold in root.Folds)
            {
                Console.WriteLine("Fold参数数量：{fold.FoldingParams.Count}");
                foreach (var param in fold.FoldingParams)
                {
                    if (param is PointFoldingParam)
                    {
                        Console.WriteLine("点模式：P1({pointParam.P1.X},{pointParam.P1.Y})");
                    }
                    else if (param is AngleFoldingParam)
                    {
                        Console.WriteLine("角度模式：Alpha={angleParam.Alpha}");
                    }
                }
            }
        }
    }
}
