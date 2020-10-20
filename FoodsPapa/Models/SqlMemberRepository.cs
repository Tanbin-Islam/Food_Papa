using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodsPapa.Models
{
    public class SqlMemberRepository : IMemberRepository
    {
        private readonly FoodDbContext _context;

        public SqlMemberRepository(FoodDbContext context)
        {
            _context = context;
        }
        public Member AddMember(Member objMember)
        {
            _context.members.Add(objMember);
            _context.SaveChanges();
            return objMember;
        }

        public Member DeleteMember(int id)
        {
            Member deleteMember = GetMemberDeatils(id);
            if (deleteMember != null)
            {
                _context.members.Remove(deleteMember);
                _context.SaveChanges();
            }
            return deleteMember;
        }

        public Member GetMemberDeatils(int id)
        {
            return _context.members.FirstOrDefault(e => e.MemberId == id);
        }

        public IEnumerable<Member> GetMembers()
        {
            return _context.members;
        }

        public Member UpdateMember(Member changeMember)
        {
            var upmember = _context.members.Attach(changeMember);
            upmember.State = EntityState.Modified;
            _context.SaveChanges();
            return changeMember;
        }
    }
}
