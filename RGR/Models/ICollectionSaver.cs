using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models
{
    public interface ICollectionSaver
    {
        void Save(Class_Project project, string path);
    }
}
