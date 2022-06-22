using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vk.Models;
using Vk.Models.Error;
using Vk.Models.Views.EntitiesVk;

namespace Vk.Services
{
    public class GroupServices
    {
        private ApplicationContext context;

        public GroupServices()
        {
            context = new ApplicationContext();
        }

        public string GetInfoGroups(Group group, out ApiErrorResult apiErrorResult)
        {
            apiErrorResult = default;
            var token = context.TokenVk.FirstOrDefault(t => t.TokenValue != default);
            if (token == null)
            {
                apiErrorResult = new ApiErrorResult { GlobalError = "Отсутсвует токен в базе данных" };
                return default;
            }

            var uri = $"https://api.vk.com/method/groups.getById?access_token={token.TokenValue}" +
                $"&group_ids={group.group_ids}&group_id={group.group_id}&fields={group.fields}&v=5.131&";

            var client = new RestClient();
            var request = new RestRequest(uri, Method.Get);
            var response = client.GetAsync(request);

            var result = response.Result.Content;

            var responseGroup = JsonConvert.DeserializeObject<Models.Views.EntitiesVk.Response.ResponseGroup>(result);
            if (responseGroup == default)
            {
                apiErrorResult = new ApiErrorResult { GlobalError = "Произошла ошибка получении данных" };
            }

            foreach (var g in responseGroup.response.items)
            {
                var groupDb = new Models.Database.VkEntities.GroupVkDatabase(g);
                context.Add(groupDb);
            }
            context.SaveChanges();

            return $"Информация о группе(ах){group.group_ids} успешно получена";
        }

        internal object Get()
        {
            var groupsDb = context.Groups
                .AsNoTracking().ToList();

            return groupsDb;
        }

        public object GetMembers(GetMember getMember, out ApiErrorResult apiErrorResult)
        {
            apiErrorResult = default;

            var token = context.TokenVk.FirstOrDefault(t => t.TokenValue != default);
            if (token == null)
            {
                apiErrorResult = new ApiErrorResult { GlobalError = "Отсутсвует токен в базе данных" };
                return default;
            }
            switch (getMember.Max)
            {
                case 1:
                    return DownloadMembers(getMember, token);

                case 0:
                    GetMembersRange(getMember, token, out apiErrorResult);
                    break;
            }
            var result = DownloadMembers(getMember, token);

            return result;
        }

        private string GetMembersRange(GetMember getMember, Models.Database.AuthTokenVk token, out ApiErrorResult apiErrorResult)
        {
            apiErrorResult = default;

            int offset = 0;

            if (getMember.count > 1000)
                offset = getMember.count / 1000;

            int circleCount = 1;
            if (getMember.count > 1000)
                circleCount = getMember.count / 1000;

            for (int i = 0; i <= circleCount; i++)
            {
                var uri = $"https://api.vk.com/method/groups.getMembers?access_token={token.TokenValue}" +
                        $"&offset={offset}&group_id={getMember.group_id}&count={getMember.count}&fields={getMember.fields}&v=5.131";

                var client = new RestClient();
                var request = new RestRequest(uri, Method.Get);
                var response = client.GetAsync(request);
            }
            return null;
        }

        public object GetFriends(Friends friends, out ApiErrorResult apiErrorResult)
        {
            switch (friends.CheckBox)
            {
                case true:
                    apiErrorResult = null;
                    return RangeGetFriend(friends);

                case false:
                    break;
            }

            apiErrorResult = default;
            var token = context.TokenVk.FirstOrDefault(t => t.TokenValue != default);
            if (token == null)
            {
                apiErrorResult = new ApiErrorResult { GlobalError = "Отсутсвует токен в базе данных" };
                return default;
            }
            var getFriendsCount = context.Members.Count();
            var countMembers = context.Members.AsNoTracking().FirstOrDefault(g => g.groupId == friends.groupId);

            if (getFriendsCount == default)
            {
                apiErrorResult = new ApiErrorResult { GlobalError = "Нет подписчиков в базе данных" };
                return default;
            }

            for (int i = 1/*countMembers.MemberDatabaseId*/; i < getFriendsCount; i++)
            {
                if (i != 1)
                    countMembers.MemberDatabaseId++;

                var circleMemberId = context.Members.AsNoTracking()
                    .Where(c => c.groupId == friends.groupId)
                    .FirstOrDefault(c => c.MemberDatabaseId == i);

                var uri = $"https://api.vk.com/method/friends.get?access_token={token.TokenValue}" +
                    $"&user_id={circleMemberId.id}&count={friends.count}&offset={friends.offset}" + $"&fields={friends.fields}&v=5.131";

                var client = new RestClient();
                var request = new RestRequest(uri, Method.Get);
                var response = client.GetAsync(request);
                if (response.Result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    break;
                }

                var result = response.Result.Content;

                var deserialize = JsonConvert.DeserializeObject<Models.Views.EntitiesVk.Response.FriendResponse>(result);
                if (deserialize.response == default)
                    continue;
                if (deserialize.response.items != default)
                {
                    foreach (var t in deserialize.response.items)
                    {
                        var friend = new Models.Database.VkEntities.FriendsVk(t);
                        friend.MemberId = new Models.Database.VkEntities.Members();
                        friend.MemberId = circleMemberId;

                        if (t.city != null)
                        {
                            friend.city = new Models.Database.IntermediateProp.City(t.city);
                        }

                        if (t.country != null)
                        {
                            friend.country = new Models.Database.IntermediateProp.Country(t.country);
                        }

                        if (t.last_seen != null)
                        {
                            friend.last_seen = new Models.Database.IntermediateProp.LastSeen(t.last_seen);
                        }

                        if (t.universities != null && t.universities.Count > 0)
                        {
                            friend.universities = new List<Models.Database.IntermediateProp.University> { new Models.Database.IntermediateProp.University(t.universities[0]) };
                        }
                        if (t.schools != null && t.schools.Count > 0)
                        {
                            friend.schools = new List<Models.Database.IntermediateProp.School> { new Models.Database.IntermediateProp.School(t.schools[0]) };
                        }

                        if (t.relatives != null && t.relatives.Count > 0)
                        {
                            friend.relatives = new List<Models.Database.IntermediateProp.Relative> { new Models.Database.IntermediateProp.Relative(t.relatives[0]) };
                        }

                        if (t.relation_partner != null)
                        {
                            friend.relation_partner = new Models.Database.IntermediateProp.RelationPartner(t.relation_partner);
                        }
                        //members.FriendsVks.Add(friend);
                        //context.FriendsVks.Add(friend);
                        circleMemberId.FriendsVks.Add(friend);
                        context.Members.Update(circleMemberId);
                    }
                    context.SaveChanges();
                }
            }

            context.SaveChanges();
            return $"Друзья подписчиков получены";
        }

        internal object GetUsersCountFriends(out ApiErrorResult apiErrorResult)
        {
            apiErrorResult = default;

            var usersRange = context.Members
                .OrderByDescending(u => u.FriendsVks.Count)
                .Take(5).ToList();
            if (usersRange == default)
            {
                apiErrorResult = new ApiErrorResult { GlobalError = "Нет параметров в базе данных" };
                return default;
            }

            return usersRange;
        }

        internal object GetUsers(Models.Views.GetRangeUsers getRangeUsers, out ApiErrorResult apiErrorResult)
        {
            apiErrorResult = default;

            var usersRange = context.Members
                .Where(m => m.MemberDatabaseId >= getRangeUsers.RangeMin)
                .Where(m => m.MemberDatabaseId <= getRangeUsers.RangeMax)
                .OrderBy(m => m.first_name).OrderBy(m => m.last_name).ToList();

            return usersRange;
        }

        public string GetGroupsFriends(GetFriendsGroup getGoupsById, out ApiErrorResult apiErrorResult)
        {
            apiErrorResult = default;

            var token = context.TokenVk.FirstOrDefault(t => t.TokenValue != default);
            if (token == null)
            {
                apiErrorResult = new ApiErrorResult { GlobalError = "Отсутсвует токен в базе данных" };
                return default;
            }

            //var searchIdCount = context.Members.AsNoTracking().Where(s => s.MemberDatabaseId == getGoupsById.user_id)
            //    .Where(i => i.id != default)
            //    .Include(c => c.FriendsVks).Include(c => c.FriendsVks);

            var test = context.Members.Include(f => f.FriendsVks)
                .Where(c => c.groupId == getGoupsById.groupId).ToList();

            var friendCount = context.FriendsVks.Count();

            for (int i = 0; i < test.Count(); i++)
            {
                for (int k = 0; k < test[i].FriendsVks.Count; k++)
                {
                    var uri = $"https://api.vk.com/method/groups.get?access_token={token.TokenValue}" +
                   $"&user_id={test[i].FriendsVks[k].id}&extended={getGoupsById.extended}" + $"&fields={getGoupsById.fields}&v=5.131";

                    var client = new RestClient();
                    var request = new RestRequest(uri, Method.Get);
                    var response = client.GetAsync(request);

                    var result = response.Result.Content;

                    var deserialaize = JsonConvert.DeserializeObject<Models.Views.EntitiesVk.Response.ResponseGroup>(result);
                    if (deserialaize.response == default)
                        continue;
                    foreach (var g in deserialaize.response.items)
                    {
                        var group = new Models.Database.VkEntities.GroupVkDatabase(g);
                        group.FriendsVk = test[i].FriendsVks[k];
                        context.Groups.Add(group);
                    }
                }

                context.SaveChanges();
            }

            var test123 = context.Members.Include(g => g.FriendsVks).ThenInclude(g => g.GroupVkDatabase);

            return "Ok";
        }

        private async Task<string> RangeGetFriend(Models.Views.EntitiesVk.Friends friends)
        {
            for (int i = friends.MinRange; i < friends.MaxRange; i++)
            {
                var friend = context.Members.FirstOrDefault(f => f.MemberDatabaseId == i);
                var token = context.TokenVk.FirstOrDefault(t => t.TokenValue != default);
                if (token == null)
                {
                    return default;
                }

                var uri = $"https://api.vk.com/method/friends.get?access_token={token.TokenValue}" +
                $"&user_id={friend}&count={friends.count}&offset={friends.offset}" + $"&fields={friends.fields}&v=5.131";

                var client = new RestClient();
                var request = new RestRequest(uri, Method.Get);
                var response = client.GetAsync(request);

                var result = response.Result.Content;

                var deserialaize = JsonConvert.DeserializeObject<Models.Views.EntitiesVk.Response.FriendResponse>(result);
            }
            return null;
        }

        private async Task<string> DownloadMembers(Models.Views.EntitiesVk.GetMember getMember, Models.Database.AuthTokenVk token)
        {
            int offset = getMember.offset;
            int counterForeeach = 0;
            for (int i = 1; i < getMember.count; i++)
            {
                if (i > 1)
                    offset += 1000;

                var uri = $"https://api.vk.com/method/groups.getMembers?access_token={token.TokenValue}" +
                   $"&offset={offset}&group_id={getMember.group_id}&count={1000}&fields={getMember.fields}&v=5.131";
                var client = new RestClient();
                var request = new RestRequest(uri, Method.Get);
                double forCounter = i % 3;
                if (forCounter == 0)
                    await Task.Delay(1000);

                var response = client.GetAsync(request);

                var result = response.Result.Content;

                var deserialize = JsonConvert.DeserializeObject<Models.Views.EntitiesVk.Response.ResponseMembers>(result);
                if (deserialize == default)
                    continue;
                foreach (var t in deserialize.Response.items)
                {
                    counterForeeach++;
                    var countResponse = deserialize.Response.items.Count;

                    var members = new Models.Database.VkEntities.Members(t);
                    members.groupId = getMember.group_id;

                    if (t.city != null)
                    {
                        members.city = new Models.Database.IntermediateProp.City(t.city);
                    }

                    if (t.country != null)
                    {
                        members.country = new Models.Database.IntermediateProp.Country(t.country);
                    }

                    if (t.last_seen != null)
                    {
                        members.last_seen = new Models.Database.IntermediateProp.LastSeen(t.last_seen);
                    }

                    if (t.universities != null && t.universities.Count > 0)
                    {
                        members.universities = new List<Models.Database.IntermediateProp.University> { new Models.Database.IntermediateProp.University(t.universities[0]) };
                    }
                    if (t.schools != null && t.schools.Count > 0)
                    {
                        members.schools = new List<Models.Database.IntermediateProp.School> { new Models.Database.IntermediateProp.School(t.schools[0]) };
                    }

                    if (t.relatives != null && t.relatives.Count > 0)
                    {
                        members.relatives = new List<Models.Database.IntermediateProp.Relative> { new Models.Database.IntermediateProp.Relative(t.relatives[0]) };
                    }

                    if (t.relation_partner != null)
                    {
                        members.relation_partner = new Models.Database.IntermediateProp.RelationPartner(t.relation_partner);
                    }

                    context.Members.Add(members);
                    ;
                }
                context.SaveChanges();
            }
            return $"Загружено {getMember.count} Участников";
        }

        private void SaveChanges(List<Models.Database.VkEntities.Members> listMembers)
        {
            context.Members.AddRange(listMembers);
            context.SaveChanges();
            context.Dispose();
        }
    }
}