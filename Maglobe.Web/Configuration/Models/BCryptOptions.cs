using BCrypt.Net;

namespace Maglobe.Web.Configuration.Models
{
    public class BCryptOptions
    {
        public HashType HashType { get; set; }

        public int WorkFactor { get; set; }
    }
}
