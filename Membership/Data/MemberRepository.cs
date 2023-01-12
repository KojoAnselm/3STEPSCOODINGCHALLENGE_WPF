using Membership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Data
{
    public class MemberRepository : IMemberRepository
    {
        private MemberDbContext _db;

        public MemberRepository()
        {
            _db = new MemberDbContext();
        }
        public List<Member> GetAllMembers()
        {
            return _db.Members.ToList();
        }
    }
}
