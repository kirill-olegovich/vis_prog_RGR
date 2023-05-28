using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace RGR.Models
{
    public class YAML_Saver : ICollectionProjectSaver
    {
        public void SaveYAML(Class_Project collection)
        {
            var serializer = new SerializerBuilder()
                 .WithNamingConvention(CamelCaseNamingConvention.Instance)
                 .WithTagMapping("!project", typeof(Class_Project))
                 .WithIndentedSequences()
                 .Build();
            var yaml = serializer.Serialize(collection);
            using (StreamWriter writer = new StreamWriter(@"..\..\..\all_proj.yaml", true))
            {
                writer.WriteLine(yaml);
            }
        }
    }
}
