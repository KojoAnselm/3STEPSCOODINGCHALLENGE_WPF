using Membership.Model;
using System.Collections.Generic;

namespace Membership.Data
{
    public interface IMemberRepository
    {
        List<Member> GetAllMembers();
    }
}