using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodsPapa.ViewModels
{
    public class EditMemberVM:MemberVM
    {
        public int MemberId { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
