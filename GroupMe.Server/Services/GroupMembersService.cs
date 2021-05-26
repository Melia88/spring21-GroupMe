using System;
using System.Collections.Generic;
using GroupMe.Models;
using GroupMe.Repositories;

namespace GroupMe.Services
{
  public class GroupMembersService
  {
    private readonly GroupMembersRepository _gmRepo;

    public GroupMembersService(GroupMembersRepository gmRepo)
    {
      _gmRepo = gmRepo;
    }

    public List<GroupMemberViewModel> GetGroupMembers(int groupId)
    {
      return _gmRepo.GetMembers(groupId);
    }
    internal GroupMember CreateGroupMember(GroupMember gm)
    {
      return _gmRepo.Create(gm);
    }

    public void DeleteGroup(int groupId, string accountId)
    {
      // steps get group by id
      // if(group.creatorId == accountId) good to delete
      // throw new System.Exception
    }


  }
}