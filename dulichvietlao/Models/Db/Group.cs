using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dulichvietlao.Models.Db
{
    [Table("Group")]
    public class Group
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string GroupAddress { get; set; }
        public string GroupPhone { get; set; }
        public string Representative { get; set; }
        public int NumberJoin { get; set; }
        public int MembershipId { get; set; }

    }
}
