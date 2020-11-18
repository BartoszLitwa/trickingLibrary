using System.Collections.Generic;

namespace TrickingLibrary.Models
{
    public class Difficulty : BaseModel<string>
    {
        public string Name { get; set; }
        public string Descrption { get; set; }
        public IList<Trick> Tricks { get; set; }
    }
}