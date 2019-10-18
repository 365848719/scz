using System;
using Xunit;

namespace Scz.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public interface IUserRepository
    {
        bool Add(User user);
    }

    public class UserManager
    {
        IUserRepository userRepository;

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool CreateUser(User user)
        {
            if (user.Age < 0 || string.IsNullOrEmpty(user.Name))
            {
                throw new FormatException("Age or Name is inValid ! ");
            }

            return true;
        }
    }
}
