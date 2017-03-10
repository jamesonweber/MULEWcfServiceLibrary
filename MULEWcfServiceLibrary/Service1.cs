using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MULEWcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string checkLogin(string username)
        {
            using (muleEntities1 db = new muleEntities1())
            {
                var user = db.users.Where(o => o.email.ToLower().Equals(username));
                if (user.Any())
                    return user.FirstOrDefault().password;
                else
                    return "";
            }
        }

        public List<String> getGroups(String username)
        {
            UserManager UM = new UserManager();
            int id = UM.getUserId(username);

            List<String> groupnames = new List<String>();

            using (muleEntities1 db = new muleEntities1())
            {
                var usergroups =
                    (from ug in db.user_group
                     join g in db.groups on ug.group_id equals g.group_id
                     where ug.user_id == id
                     select g).OrderBy(x => x.group_name).ToList();

                foreach(group g in usergroups)
                {
                    groupnames.Add(g.group_name);
                }

                return groupnames;
            }
        }

        public bool uploadPosts(DataPost dp)
        {
            using (muleEntities1 db = new muleEntities1())
            {

                UserManager UM = new UserManager();

                int u_id = UM.getUserId(dp.user_name);
                int g_id = UM.getGroupId(dp.group_name);
                int nextSeed = UM.getPostId();

                post p = new post();
                p.post_id = nextSeed;
                p.user_id = u_id;
                p.post_status = dp.description;
                p.post_date = Convert.ToDateTime(dp.datetime);
                p.group_id = g_id;
                db.posts.Add(p);
                db.SaveChanges();

                positioning pos = new positioning();
                pos.post_id = nextSeed;
                pos.region = "";
                pos.latitude = 0;
                pos.longitude = 0;
                pos.northing = dp.northings;
                pos.easting = dp.eastings;
                pos.euv_depth = dp.depth;
                db.positionings.Add(pos);
                db.SaveChanges();

                sensor sen = new sensor();
                sen.post_id = nextSeed;
                sen.avg_primary_data = dp.avg;
                sen.sd = dp.sd;
                sen.sem = dp.sem;
                sen.meta_data = dp.metaData;
                db.sensors.Add(sen);
                db.SaveChanges();

                return true;
            }

        }


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
