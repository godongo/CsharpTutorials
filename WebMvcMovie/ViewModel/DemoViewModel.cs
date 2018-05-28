using System.Collections.Generic;
using System.Linq;

namespace WebMvcMovie.ViewModel
{
    public class DemoViewModel
    {
        public string OMDMarquesConcat { get; set; }
        IEnumerable<string> OtherMakesDealerMarques { get => OMDMarquesConcat.Split(',').AsEnumerable<string>(); }
    }
}
