using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodsPapa.Models
{
   public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberDeatils(int id);
        Member AddMember(Member objMember);
        Member UpdateMember(Member changeMember);
        Member DeleteMember(int id);
    }
}
