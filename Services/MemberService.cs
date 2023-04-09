using StokTakip.EntityFramework;
using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Services
{
    public interface IMemberService
    {
        List<Member> GetMembers();

        bool ChangePassword(string username, string password);
    }
    public class MemberService : IMemberService
    {
        MainContext dbContext = new MainContext();

        public bool ChangePassword(string username, string password)
        {
            Member uye = dbContext.Members.Where(x => x.Username == username).FirstOrDefault();
            if(uye != null)
            {
                uye.Password = password;
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public List<Member> GetMembers()
        {
            return dbContext.Members.ToList<Member>();
        }
    }
}
