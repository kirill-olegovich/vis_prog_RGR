using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace RGR.Models
{
    public class YAML_Loader : ICollectionProjectLoader
    {
        public IEnumerable<Class_Project> YAML_Load()
        {
            if (File.Exists(@"..\..\..\all_proj.yaml"))
            {
                string fileString = File.ReadAllText(@"..\..\..\all_proj.yaml");
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .WithTagMapping("!project", typeof(Class_Project))
                    .Build();
                var stringDeserializ = deserializer.Deserialize<List<Class_Project>>(fileString);
                if (stringDeserializ == null)
                {
                    stringDeserializ = new List<Class_Project>();
                }
                return stringDeserializ;
            }
            return Enumerable.Empty<Class_Project>();
        }
    }
}
