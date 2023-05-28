using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models
{
    public interface ICollectionLoader
    {
        Class_Project Load(string path);
    }
}
