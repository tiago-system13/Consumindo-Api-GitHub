using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacao
{
   public class Proprietario
    {
        public string login { get; set; }
        public string name { get; set; }
        public string avatar_url { get; set; }
        public string email { get; set; }
        public string company { get; set; }
        public string bio { get; set; }
        public int public_repos { get; set; }
        public int followers { get; set; }
        public int following { get; set; }
    }
}
