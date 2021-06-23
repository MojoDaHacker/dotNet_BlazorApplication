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
        public List<float> getListOfClose()
        {
            var list = new List<float>();
            foreach (var tick in TimeSeries.Values)
            {
                list.Add(tick.Close);
            }
            list.Reverse();
            return list;
        }
    }
    public class Ticks
    {
        [JsonPropertyName("1. open")]
        public float Open { get; set; }

        [JsonPropertyName("2. high")]
        public float High{ get; set; }

        [JsonPropertyName("3. low")]
        public float Low { get; set; }

        [JsonPropertyName("4. close")]
        public float Close { get; set; }

        [JsonPropertyName("5. volume")]
        public float Volume { get; set; }



    }
}
