using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reddit.Net.Json;

namespace Reddit.Net.Things
{
    public class Thing : IThing
    {
        #region Inherited Properties
        public RedditApi Api { get; set; }

        public string Id { get; set; }

        public string FullName { get; set; }

        #endregion
    }
}

