using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MULEWcfServiceLibrary
{
    class UserManager
    {
        public int getUserId(string email)
        {
            using (muleEntities1 db = new muleEntities1())
            {
                var user = db.users.Where(o => o.email.Equals(email));
                if (user.Any())
                    return user.FirstOrDefault().user_id;
                else
                    return -1;
            }
        }

        public int getPostId()
        {
            using (muleEntities1 db = new muleEntities1())
            {
                var post = db.posts.OrderByDescending(o => o.post_id).FirstOrDefault();
                if (post != null)
                    return post.post_id + 1;
                else
                    return 1;
            }
        }

        public int getGroupId(string name)
        {
            using (muleEntities1 db = new muleEntities1())
            {
                var group = db.groups.Where(o => o.group_name.ToLower().Equals(name));
                if (group.Any())
                    return group.FirstOrDefault().group_id;
                else
                    return -1;
            }
        }
    }
}
