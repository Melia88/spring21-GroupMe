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
  public class GroupsController : ControllerBase
  {
    private readonly GroupsService _gs;
    private readonly GroupMembersService _gms;

    public GroupsController(GroupsService gs, GroupMembersService gms)
    {
      _gs = gs;
      _gms = gms;
    }

    [HttpGet]
    public ActionResult<List<Group>> Get()
    {
      try
      {
        List<Group> groups = _gs.GetGroups();
        return Ok(groups);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // TODO GetMembersByGroupId
    [HttpGet("{id}/groupmembers")]
    [Authorize]
    public async Task<ActionResult<List<GroupMemberViewModel>>> GetGroupMembers(int groupId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        // var AccountId = userInfo.Id;
        IEnumerable<GroupMemberViewModel> groupmembers = _gms.GetGroupMembers(groupId);
        return Ok(groupmembers);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}