import Swal from 'sweetalert2'
import { AppState } from '../AppState'
import router from '../router'
import { api } from './AxiosService'

class GroupsService {
  async getGroups() {
    const res = await api.get('api/groups')
    AppState.groups = res.data
  }

  async joinGroup(g) {
    await api.post('api/groupmembers', {
      groupId: g.id
    })
    Swal.fire({
      title: `You have joined ${g.name}`,
      toast: true
    })
    router.push({ name: 'GroupMembersPage', params: { id: g.id } })
  }
}

export const groupsService = new GroupsService()
