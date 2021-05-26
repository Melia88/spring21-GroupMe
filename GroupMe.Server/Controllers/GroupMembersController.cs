using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using GroupMe.Models;
using GroupMe.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroupMe.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GroupMembersController : ControllerBase
  {
    private readonly GroupMembersService _gms;

    public GroupMembersController(GroupMembersService gms)
    {
      _gms = gms;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<GroupMember>> CreateAsync([FromBody] GroupMember gm)
    {
      try
      {
        // REVIEW enforce the current user context
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        gm.AccountId = userInfo.Id;
        var newGm = _gms.CreateGroupMember(gm);
        return Ok(newGm);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // // TODO GetMembersByGroupId
    // [HttpGet("{id/groupmembers}")]
    // [Authorize]
    // public async Task<ActionResult<List<GroupMemberViewModel>>> GetMembersByGroupId(int id)
    // {
    //   try
    //   {
    //     Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
    //     // var AccountId = userInfo.Id;
    //     IEnumerable<GroupMemberViewModel> groupmembers = _gms.GetGroupMembers(id);
    //     return Ok(groupmembers);
    //   }
    //   catch (System.Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }


    // TODO DeleteMembers
    //  ---- Members can delete themselves AND Group creator can delete members
    // call from whatever server has this path Get by Id()
    //  ---- Verify user Identity groupId == userInfo.id || accountId
    // 

  }
}