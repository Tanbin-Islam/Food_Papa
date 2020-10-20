using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodsPapa.Models
{
    public class MockMemberRepository : IMemberRepository
    {
        private readonly List<Member> _memberList;

        public MockMemberRepository()
        {
            _memberList = new List<Member>()
            {
                new Member(){MemberId=1, MemberName="Tanbin",Email="tanbin@gmail.com",Address="Dhaka",Phone=123654},
                new Member(){MemberId=2, MemberName="Ritu",Email="ritu@gmail.com",Address="Pabna",Phone=123654},
                new Member(){MemberId=3, MemberName="Tania",Email="tania@gmail.com",Address="Dhaka",Phone=123654}
            };
        }
        public Member AddMember(Member objMember)
        {
            objMember.MemberId = _memberList.Max(e => e.MemberId) + 1;
            _memberList.Add(objMember);
            return objMember;
        }

        public Member DeleteMember(int id)
        {
            Member member = _memberList.FirstOrDefault(e => e.MemberId == id);
            if (member != null)
            {
                _memberList.Remove(member);
            }
            return member;
        }

        public Member GetMemberDeatils(int id)
        {
            Member member = this._memberList.FirstOrDefault(e => e.MemberId == id);
            return member;
        }

        public IEnumerable<Member> GetMembers()
        {
            return _memberList;
        }

        public Member UpdateMember(Member changeMember)
        {
            Member member = _memberList.FirstOrDefault(e => e.MemberId == changeMember.MemberId);
            if (member != null)
            {
                member.MemberName = changeMember.MemberName;
                member.Email = changeMember.Email;
                member.Address = changeMember.Address;
                member.Address = changeMember.Address;
                member.Phone = changeMember.Phone;
                
            }
            return member;
        }
    }
}
