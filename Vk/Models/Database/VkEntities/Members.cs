using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vk.Models.Database.IntermediateProp;

namespace Vk.Models.Database.VkEntities
{
    public class Members
    {
        [Key]
        public int MemberDatabaseId { get; set; }

        public string groupId { get; set; }
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

        public List<Database.VkEntities.FriendsVk> FriendsVks { get; set; } = new List<FriendsVk>();

        public Members()
        {
        }

        public Members(Models.Views.EntitiesVk.Response.Members members)
        {
            id = members.id;
            domain = members.domain;
            bdate = members.bdate;
            photo_200 = members.photo_200;
            photo_max = members.photo_max;
            photo_200_orig = members.photo_200_orig;
            photo_400_orig = members.photo_400_orig;
            photo_max_orig = members.photo_max_orig;
            has_mobile = members.has_mobile;
            can_post = members.can_post;
            can_see_all_posts = members.can_see_all_posts;
            can_see_audio = members.can_see_audio;
            can_write_private_message = members.can_write_private_message;
            site = members.site;
            status = members.status;
            common_count = members.common_count;
            sex = members.sex;
            photo_50 = members.photo_50;
            photo_100 = members.photo_100;
            online = members.online;
            first_name = members.first_name;
            last_name = members.last_name;
            can_access_closed = members.can_access_closed;
            is_closed = members.is_closed;
            university = members.university;
            faculty = members.faculty;
            faculty_name = members.faculty_name;
            graduation = members.graduation;
            education_status = members.education_status;
            relation = members.relation;
            education_form = members.education_form;
            skype = members.skype;
            mobile_phone = members.mobile_phone;
            home_phone = members.home_phone;
            twitter = members.twitter;
        }
    }
}