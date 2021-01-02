using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using ErrorEventArgs = Newtonsoft.Json.Serialization.ErrorEventArgs;

namespace Lib.Core
{
    public static class Serializer
    {
        static JsonSerializerSettings DefaultJsonSerializerSettings;

        static Serializer()
        {
            DefaultJsonSerializerSettings = new JsonSerializerSettings()
            {
                ////CheckAdditionalContent = false,
                ////ContractResolver = new CustomDateContractResolver(),
                ////DateFormatHandling = DateFormatHandling.IsoDateFormat,
                ////MissingMemberHandling = MissingMemberHandling.Error,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.Indented,
            };
        }

        public static T JsonDeserialize<T>(
            string value, 
            JsonSerializerSettings settings = null)
        {
            if (settings == null)
            {
                settings = DefaultJsonSerializerSettings;
            }

            return JsonConvert.DeserializeObject<T>(value, settings);
        }

        public static Task<T> JsonDeserializeAsync<T>(
            string value,
            JsonSerializerSettings settings = null)
        {
            return Task.Run(() => JsonDeserialize<T>(value, settings));
        }

        public static string JsonSerialize(
            object value,
            JsonSerializerSettings settings = null)
        {
            if (settings == null)
            {
                settings = DefaultJsonSerializerSettings;
            }

            return JsonConvert.SerializeObject(value, settings);
        }

        public static Task<string> JsonSerializeAsync(
            object value,
            JsonSerializerSettings settings = null)
        {
            return Task.Run(() => JsonSerialize(value, settings));
        }

        public static T XmlDeserialize<T>(
            string value,
            XmlReaderSettings settings = default)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new StringReader(value))
            {
                using (var reader = XmlReader.Create(stream, settings))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
        }

        public static Task<T> XmlDeserializeAsync<T>(
            string value,
            XmlReaderSettings settings = default)
        {
            return Task.Run(() => XmlDeserialize<T>(value, settings));
        }

        public static string XmlSerialize(
            object value,
            XmlWriterSettings settings = default)
        {
            if (settings == null)
            {
                settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
            }

            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(value.GetType());

            using (var stream = new StringWriter())
            {
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    serializer.Serialize(writer, value, emptyNamepsaces);
                    return stream.ToString();
                }
            }
        }

        public static Task<string> XmlSerializeAsync(
            object value,
            XmlWriterSettings settings = default)
        {
            return Task.Run(() => XmlSerialize(value, settings));
        }
    }

    public class CustomDateContractResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            var contract = base.CreateContract(objectType);
            var isOk = objectType == typeof(DateTime);

            if (isOk)
            {
                contract.Converter = new ZerosIsoDateTimeConverter("yyyy-MM-dd hh:mm:ss", "0000-00-00 00:00:00");
            }

            return contract;
        }
    }

    public class ZerosIsoDateTimeConverter : IsoDateTimeConverter
    {
        private readonly string _zeroDateString;

        public ZerosIsoDateTimeConverter(string dateTimeFormat, string zeroDateString)
        {
            DateTimeFormat = dateTimeFormat;
            _zeroDateString = zeroDateString;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString() == _zeroDateString ? DateTime.MinValue : base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}