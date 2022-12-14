using System;
using System.Collections.Generic;

#nullable disable

namespace MyProjectSm.Models
{
    public partial class UserTbl
    {
        public UserTbl()
        {
            LikeTbls = new HashSet<LikeTbl>();
            Mergeings = new HashSet<Mergeing>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int? ContactNo { get; set; }
        public byte[] ProfileImage { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<LikeTbl> LikeTbls { get; set; }
        public virtual ICollection<Mergeing> Mergeings { get; set; }
    }
}
