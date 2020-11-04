using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrickingLibrary.Api.Models;

namespace TrickingLibrary.Api
{
    public class TrickyStore
    {
        private readonly List<Trick> _tricks;

        public TrickyStore()
        {
            _tricks = new List<Trick>();
        }

        public IEnumerable<Trick> All => _tricks;

        public void Add(Trick trick)
        {
            trick.Id = _tricks.Count + 1;
            _tricks.Add(trick);
        }
    }
}
