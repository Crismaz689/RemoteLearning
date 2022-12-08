import { Role } from "./role.enum";

export class RoleMapper {
    static RoleMapping(roleName: string | null): Role {
        switch (roleName) {
            case 'Admin': return Role.Admin;
            case 'Tutor': return Role.Tutor;
            case 'User': return Role.User;
            default: return Role.Undefined;
        }
    }
}