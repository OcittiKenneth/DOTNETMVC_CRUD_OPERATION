using System;
using System.Collections.Generic;
using System.Text;
using TEST.PROJECT;
using TEST.REPP;

namespace TEST.Service
{
    public class UserService:IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<UserProfile> userProfileRepository;

        public UserService(IRepository<User> userRepository,
            IRepository<UserProfile> userProfileRepository)
        {
            this.userRepository = userRepository;
            this.userProfileRepository = userProfileRepository;
        }

        public void DeleteUser(long id)
        {
            UserProfile userProfile = userProfileRepository.Get(id);
            userProfileRepository.Remove(userProfile);
            User user = userRepository.Get(id);
            userRepository.Remove(user);

        }

        public User GetUser(long id)
        {
            return userRepository.Get(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        public void InsertUser(User user)
        {
            userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }
    }
}
