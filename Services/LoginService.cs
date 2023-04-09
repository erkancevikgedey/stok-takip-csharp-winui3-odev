using Microsoft.UI.Xaml;
using StokTakip.EntityFramework;
using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace StokTakip.Services
{
    interface ILoginService
    {
        bool LoginApp(string username, string password);
    }
    internal class LoginService : ILoginService
    {
        private readonly IMemberService _memberService;


        public LoginService()
        {
            _memberService = new MemberService();
        }

        public bool LoginApp(string username, string password)
        {
            List<Member> members = _memberService.GetMembers();
            var member = members.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            bool status = member != null ? true : false;
            
            return status;
        }
    }
}
