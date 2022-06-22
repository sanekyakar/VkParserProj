using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Vk.Models.Database.IntermediateProp;

namespace Vk.Models.Database.VkEntities
{
    public class FriendsVk
    {
        [Key]
        public int FriendsVkDatabase { get; set; }

        public int id { get; set; }
        public string domain { get; set; }
        public string bdate { get; set; }
        public City city { get; set; }
        public Country country { get; set; }
        public string photo_200 { get; set; }
        public string photo_max { get; set; }
        public string photo_200_orig { get; set; }
        public string photo_400_orig { get; set; }
        public string photo_max_orig { get; set; }
        public int has_mobile { get; set; }
        public int can_post { get; set; }
        public int can_see_all_posts { get; set; }
        public int can_see_audio { get; set; }
        public int can_write_private_message { get; set; }
        public string site { get; set; }
        public string status { get; set; }
        public LastSeen last_seen { get; set; }
        public int common_count { get; set; }
        public int sex { get; set; }
        public string photo_50 { get; set; }
        public string photo_100 { get; set; }
        public int online { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool can_access_closed { get; set; }
        public bool is_closed { get; set; }
        public int? university { get; set; }
        public string university_name { get; set; }
        public int? faculty { get; set; }
        public string faculty_name { get; set; }
        public int? graduation { get; set; }
        public string education_status { get; set; }
        public int? relation { get; set; }
        public List<University> universities { get; set; }
        public List<School> schools { get; set; }
        public List<Relative> relatives { get; set; }
        public string education_form { get; set; }
        public string skype { get; set; }
        public string mobile_phone { get; set; }
        public string home_phone { get; set; }
        public RelationPartner relation_partner { get; set; }
        public string twitter { get; set; }

        [ForeignKey("Member")]
        public Models.Database.VkEntities.Members MemberId { get; set; }

        public List<Models.Database.VkEntities.GroupVkDatabase> GroupVkDatabase { get; set; } = new List<GroupVkDatabase>();

        public FriendsVk()
        {
        }

        public FriendsVk(Models.Views.EntitiesVk.Response.Friends friends)
        {
            id = friends.id;
            domain = friends.domain;
            bdate = friends.bdate;
            photo_200 = friends.photo_200;
            photo_max = friends.photo_max;
            photo_200_orig = friends.photo_200_orig;
            photo_400_orig = friends.photo_400_orig;
            photo_max_orig = friends.photo_max_orig;
            has_mobile = friends.has_mobile;
            can_post = friends.can_post;
            can_see_all_posts = friends.can_see_all_posts;
            can_see_audio = friends.can_see_audio;
            can_write_private_message = friends.can_write_private_message;
            site = friends.site;
            status = friends.status;
            common_count = friends.common_count;
            sex = friends.sex;
            photo_50 = friends.photo_50;
            photo_100 = friends.photo_100;
            online = friends.online;
            first_name = friends.first_name;
            last_name = friends.last_name;
            can_access_closed = friends.can_access_closed;
            is_closed = friends.is_closed;
            university = friends.university;
            faculty = friends.faculty;
            faculty_name = friends.faculty_name;
            graduation = friends.graduation;
            education_status = friends.education_status;
            relation = friends.relation;
            education_form = friends.education_form;
            skype = friends.skype;
            mobile_phone = friends.mobile_phone;
            home_phone = friends.home_phone;
            twitter = friends.twitter;
        }
    }
}