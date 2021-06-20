using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StockChart
{
    public class Stock
    {
        Dictionary<string, string> _metaData;

        [JsonPropertyName("Meta Data")]
        public Dictionary<string, string> MetaData {
            get { return _metaData; }
            set
            {
                var newDict = new Dictionary<string, string>();
                foreach (var kvp in value.Keys)
                {
                    var newKeys = kvp.Remove(0, 3);
                    newDict.Add(String.Concat(newKeys.Where(c => !Char.IsWhiteSpace(c))), value[kvp].ToString());
                }
                _metaData = newDict;
            }
        }

        [JsonPropertyName("Time Series (Daily)")]
        public Dictionary<DateTime, Ticks> TimeSeries { get; set; }

        public int getMetaDataCount()
        {
            foreach(var kvp in MetaData)
            {
                Console.WriteLine(kvp.Key, kvp.Value);
            }
            return MetaData.Count;
        }
        public void getTickCount()
        {
            Console.WriteLine(TimeSeries);
            Console.WriteLine(TimeSeries.Count);
            foreach(var x in TimeSeries)
            {
                Console.WriteLine(x.Key);
            }
        }
    }
    public class Ticks
    {
        //[JsonPropertyName("2021-06-17")]
        public Dictionary<string, float> Data { get; set; }
            = new Dictionary<string, float>();
    }
}
