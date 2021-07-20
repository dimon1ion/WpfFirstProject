using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFirstProject.Model;

namespace WpfFirstProject.Service
{
    public interface IFileService
    {
        List<Movie> Open(string fileName);
        void Save(string fileName, List<Movie> movies);
    }
}
