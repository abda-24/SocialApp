using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.Recommend
{
    public class RecommendedUserDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? ProfileImageUrl { get; set; }

       
        public int MutualFriendsCount { get; set; }

     
        public string? Reason { get; set; }
    }
}
