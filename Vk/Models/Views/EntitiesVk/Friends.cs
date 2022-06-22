using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Views.EntitiesVk
{
    public class Friends
    {
        public bool CheckBox { get; set; }
        public int MaxRange { get; set; }
        public int FullMembers { get; set; }
        public int MinRange { get; set; }

        public int user_id { get; set; }

        public string groupId { get; set; }
        public int count { get; set; }

        public int offset { get; set; }

        public string fields { get; set; } = "bdate,can_post,can_see_all_posts, can_see_audio, can_write_private_message,city,common_count, connections,contacts,country, domain,education,has_mobile, last_seen,lists,online,online_mobile,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_50," +
            "photo_max,photo_max_orig, relation, relatives,schools,sex,site,status,universities";
    }
}